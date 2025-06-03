using Microsoft.EntityFrameworkCore;
using Taj_Plazza.Core.DataAcess;
using Taje__Plazza.Domain.Interface;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Infrastructure.Repositories
{
    public class FactureRepository : GenericRepository<Facture>, IFactureRepository
    {
        public FactureRepository(ApplicationDbContext context) : base(context)
        {
        }

        protected override IQueryable<Facture> IncludeAll()
        {
            return _dbSet
                .Include(f => f.Client)
                .Include(f => f.Reservation)
                    .ThenInclude(r => r.EquipementsReserves)
                .Include(f => f.Espace);
        }

        public async Task<IEnumerable<Facture>> ObtenirFacturesParClientAsync(Guid clientId)
        {
            if (clientId == Guid.Empty)
                throw new ArgumentException("L'identifiant du client est invalide");

            return await IncludeAll()
                .Where(f => f.ClientId == clientId)
                .OrderByDescending(f => f.DateFacture)
                .ToListAsync();
        }

        public async Task<IEnumerable<Facture>> ObtenirFacturesParPeriodeAsync(DateTime dateDebut, DateTime dateFin)
        {
            if (dateDebut > dateFin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            return await IncludeAll()
                .Where(f => f.DateFacture >= dateDebut && f.DateFacture <= dateFin)
                .OrderByDescending(f => f.DateFacture)
                .ToListAsync();
        }

        public async Task<IEnumerable<Facture>> ObtenirFacturesImpayeesAsync()
        {
            return await IncludeAll()
                .Where(f => f.StatutPaiement == "En attente" || f.StatutPaiement == "Partiel")
                .OrderBy(f => f.DateEcheance)
                .ToListAsync();
        }

        public async Task<IEnumerable<Facture>> ObtenirFacturesEnRetardAsync()
        {
            var maintenant = DateTime.Now;
            return await IncludeAll()
                .Where(f => f.DateEcheance < maintenant && 
                           (f.StatutPaiement == "En attente" || f.StatutPaiement == "Partiel"))
                .OrderBy(f => f.DateEcheance)
                .ToListAsync();
        }

        public async Task<IEnumerable<Facture>> ObtenirFacturesParStatutAsync(string statut)
        {
            if (string.IsNullOrWhiteSpace(statut))
                throw new ArgumentException("Le statut est requis");

            return await IncludeAll()
                .Where(f => f.StatutPaiement == statut)
                .OrderByDescending(f => f.DateFacture)
                .ToListAsync();
        }

        public async Task<decimal> CalculerTotalFacturesAsync(DateTime dateDebut, DateTime dateFin)
        {
            if (dateDebut > dateFin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            return await _dbSet
                .Where(f => f.DateFacture >= dateDebut && 
                           f.DateFacture <= dateFin && 
                           f.StatutPaiement != "Annulée")
                .SumAsync(f => f.MontantTotal);
        }

        public async Task<decimal> CalculerTotalImpayeAsync()
        {
            return await _dbSet
                .Where(f => (f.StatutPaiement == "En attente" || f.StatutPaiement == "Partiel") &&
                           f.StatutPaiement != "Annulée")
                .SumAsync(f => f.MontantRestantDu);
        }

        public async Task<decimal> CalculerMontantTotalAsync(Guid factureId)
        {
            if (factureId == Guid.Empty)
                throw new ArgumentException("L'identifiant de la facture est invalide");

            var facture = await IncludeAll()
                .FirstOrDefaultAsync(f => f.Id == factureId);

            if (facture == null)
                throw new KeyNotFoundException($"Aucune facture trouvée avec l'ID {factureId}");

            decimal montantTotal = facture.MontantTotal;

            // Ajout des pénalités de retard si applicable
            if (facture.DateEcheance < DateTime.Now && facture.StatutPaiement != "Payée")
            {
                var joursRetard = (int)(DateTime.Now - facture.DateEcheance).TotalDays;
                if (joursRetard > 0)
                {
                    decimal tauxPenalite = 0.1m; // 10% par jour de retard
                    montantTotal += facture.MontantTotal * tauxPenalite * joursRetard;
                }
            }

            return montantTotal;
        }

        public async Task<decimal> CalculerMontantRestantAsync(Guid factureId)
        {
            if (factureId == Guid.Empty)
                throw new ArgumentException("L'identifiant de la facture est invalide");

            var facture = await _dbSet.FindAsync(factureId);
            if (facture == null)
                throw new KeyNotFoundException($"Aucune facture trouvée avec l'ID {factureId}");

            return facture.MontantRestantDu;
        }

        public async Task<Facture> GenererFactureAsync(Guid reservationId)
        {
            if (reservationId == Guid.Empty)
                throw new ArgumentException("L'identifiant de la réservation est invalide");

            var reservation = await _context.Set<Reservation>()
                .Include(r => r.Client)
                .Include(r => r.Espace)
                .Include(r => r.EquipementsReserves)
                .FirstOrDefaultAsync(r => r.Id == reservationId);

            if (reservation == null)
                throw new KeyNotFoundException($"Aucune réservation trouvée avec l'ID {reservationId}");

            var facture = new Facture
            {
                Id = Guid.NewGuid(),
                ReservationId = reservationId,
                ClientId = reservation.ClientId,
                EspaceId = reservation.EspaceId,
                DateFacture = DateTime.Now,
                DateEcheance = DateTime.Now.AddDays(30),
                MontantTotal = reservation.MontantTotal,
                MontantRestantDu = reservation.MontantTotal,
                StatutPaiement = "En attente",
                Reference = $"FAC-{DateTime.Now:yyyyMMdd}-{reservationId.ToString().Substring(0, 8)}",
                DateCreation = DateTime.Now
            };

            await _dbSet.AddAsync(facture);
            await _context.SaveChangesAsync();
            return facture;
        }

        public async Task EnregistrerPaiementAsync(Guid factureId, decimal montant, string methodePaiement)
        {
            if (factureId == Guid.Empty)
                throw new ArgumentException("L'identifiant de la facture est invalide");
            if (montant <= 0)
                throw new ArgumentException("Le montant du paiement doit être supérieur à zéro");
            if (string.IsNullOrWhiteSpace(methodePaiement))
                throw new ArgumentException("La méthode de paiement est requise");

            var facture = await _dbSet.FindAsync(factureId);
            if (facture == null)
                throw new KeyNotFoundException($"Aucune facture trouvée avec l'ID {factureId}");

            if (montant > facture.MontantRestantDu)
                throw new InvalidOperationException("Le montant du paiement ne peut pas être supérieur au montant restant dû");

            facture.MontantRestantDu -= montant;
            facture.StatutPaiement = facture.MontantRestantDu == 0 ? "Payée" : "Partiel";
            facture.DernierPaiement = DateTime.Now;
            facture.MethodePaiement = methodePaiement;
            facture.DateModification = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateStatutPaiementAsync(Guid factureId, string nouveauStatut)
        {
            if (factureId == Guid.Empty)
                throw new ArgumentException("L'identifiant de la facture est invalide");
            if (string.IsNullOrWhiteSpace(nouveauStatut))
                throw new ArgumentException("Le nouveau statut est requis");

            var facture = await _dbSet.FindAsync(factureId);
            if (facture == null)
                throw new KeyNotFoundException($"Aucune facture trouvée avec l'ID {factureId}");

            facture.StatutPaiement = nouveauStatut;
            facture.DateModification = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AnnulerFactureAsync(Guid factureId, string motifAnnulation)
        {
            if (factureId == Guid.Empty)
                throw new ArgumentException("L'identifiant de la facture est invalide");
            if (string.IsNullOrWhiteSpace(motifAnnulation))
                throw new ArgumentException("Le motif d'annulation est requis");

            var facture = await _dbSet.FindAsync(factureId);
            if (facture == null)
                throw new KeyNotFoundException($"Aucune facture trouvée avec l'ID {factureId}");

            facture.StatutPaiement = "Annulée";
            facture.MotifAnnulation = motifAnnulation;
            facture.DateModification = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Dictionary<string, decimal>> ObtenirStatistiquesPaiementAsync(DateTime dateDebut, DateTime dateFin)
        {
            if (dateDebut > dateFin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            return await _dbSet
                .Where(f => f.DateFacture >= dateDebut && f.DateFacture <= dateFin)
                .GroupBy(f => f.StatutPaiement)
                .Select(g => new { Statut = g.Key, Total = g.Sum(f => f.MontantTotal) })
                .ToDictionaryAsync(x => x.Statut, x => x.Total);
        }

        public async Task<Dictionary<string, decimal>> ObtenirRevenusParMethodePaiementAsync(DateTime debut, DateTime fin)
        {
            if (debut > fin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            return await _dbSet
                .Where(f => f.DateFacture >= debut && 
                           f.DateFacture <= fin && 
                           f.StatutPaiement == "Payée")
                .GroupBy(f => f.MethodePaiement)
                .Select(g => new { Methode = g.Key, Total = g.Sum(f => f.MontantTotal) })
                .ToDictionaryAsync(x => x.Methode, x => x.Total);
        }

        public async Task<Dictionary<DateTime, decimal>> ObtenirChiffreAffaireParJourAsync(DateTime debut, DateTime fin)
        {
            if (debut > fin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            return await _dbSet
                .Where(f => f.DateFacture.Date >= debut.Date && 
                           f.DateFacture.Date <= fin.Date && 
                           f.StatutPaiement != "Annulée")
                .GroupBy(f => f.DateFacture.Date)
                .Select(g => new { Date = g.Key, Total = g.Sum(f => f.MontantTotal) })
                .ToDictionaryAsync(x => x.Date, x => x.Total);
        }

        public async Task<double> ObtenirTauxReglementAsync(DateTime debut, DateTime fin)
        {
            if (debut > fin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            var factures = await _dbSet
                .Where(f => f.DateFacture >= debut && 
                           f.DateFacture <= fin && 
                           f.StatutPaiement != "Annulée")
                .ToListAsync();

            if (!factures.Any())
                return 0;

            var facturesPayees = factures.Count(f => f.StatutPaiement == "Payée");
            return (double)facturesPayees / factures.Count * 100;
        }
    }
} 