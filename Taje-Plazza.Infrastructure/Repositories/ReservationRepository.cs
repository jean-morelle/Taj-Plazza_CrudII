using Microsoft.EntityFrameworkCore;
using Taj_Plazza.Core.DataAcess;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Domain.Interface;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Infrastructure.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
        }

        protected override IQueryable<Reservation> IncludeAll()
        {
            return _dbSet
                .Include(r => r.Client)
                .Include(r => r.Espace)
                .Include(r => r.EquipementsReserves)
                    .ThenInclude(er => er.Equipement);
        }

        public async Task<IEnumerable<Reservation>> ObtenirReservationsParPeriodeAsync(DateTime dateDebut, DateTime dateFin)
        {
            if (dateDebut > dateFin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            return await IncludeAll()
                .Where(r => r.DateDebut >= dateDebut && r.DateFin <= dateFin)
                .OrderBy(r => r.DateDebut)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> ObtenirReservationsParClientAsync(Guid clientId)
        {
            if (clientId == Guid.Empty)
                throw new ArgumentException("L'identifiant du client est invalide");

            return await IncludeAll()
                .Where(r => r.ClientId == clientId)
                .OrderByDescending(r => r.DateDebut)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> ObtenirReservationsParEspaceAsync(Guid espaceId)
        {
            if (espaceId == Guid.Empty)
                throw new ArgumentException("L'identifiant de l'espace est invalide");

            return await IncludeAll()
                .Where(r => r.EspaceId == espaceId)
                .OrderByDescending(r => r.DateDebut)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> ObtenirReservationsEnCoursAsync()
        {
            var maintenant = DateTime.Now;
            return await IncludeAll()
                .Where(r => r.DateDebut <= maintenant && r.DateFin >= maintenant && r.Statut != "Annulée")
                .OrderBy(r => r.DateFin)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> ObtenirReservationsAVenirAsync()
        {
            var maintenant = DateTime.Now;
            return await IncludeAll()
                .Where(r => r.DateDebut > maintenant && r.Statut != "Annulée")
                .OrderBy(r => r.DateDebut)
                .ToListAsync();
        }

        public async Task<bool> VerifierDisponibiliteAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin)
        {
            if (espaceId == Guid.Empty)
                throw new ArgumentException("L'identifiant de l'espace est invalide");
            if (dateDebut >= dateFin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            return !await VerifierChevauchementReservationsAsync(espaceId, dateDebut, dateFin);
        }

        public async Task<bool> VerifierChevauchementReservationsAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin, Guid? reservationIdExclue = null)
        {
            if (espaceId == Guid.Empty)
                throw new ArgumentException("L'identifiant de l'espace est invalide");
            if (dateDebut >= dateFin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            var query = _dbSet.Where(r => r.EspaceId == espaceId &&
                                        r.Statut != "Annulée" &&
                                        ((r.DateDebut <= dateDebut && r.DateFin > dateDebut) ||
                                         (r.DateDebut < dateFin && r.DateFin >= dateFin) ||
                                         (r.DateDebut >= dateDebut && r.DateFin <= dateFin)));

            if (reservationIdExclue.HasValue)
            {
                query = query.Where(r => r.Id != reservationIdExclue.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<bool> VerifierSolvabiliteClientAsync(Guid clientId)
        {
            if (clientId == Guid.Empty)
                throw new ArgumentException("L'identifiant du client est invalide");

            return await _context.Set<Facture>()
                .Where(f => f.ClientId == clientId && f.StatutPaiement == "Impayé")
                .CountAsync() == 0;
        }

        public async Task<Reservation> AjouterReservationCompleteAsync(Reservation reservation, IEnumerable<Guid> equipementIds)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));
            if (equipementIds == null)
                throw new ArgumentNullException(nameof(equipementIds));

            // Vérifier la disponibilité de l'espace
            if (await VerifierChevauchementReservationsAsync(reservation.EspaceId, reservation.DateDebut, reservation.DateFin))
                throw new InvalidOperationException("L'espace n'est pas disponible pour cette période");

            // Vérifier la solvabilité du client
            if (!await VerifierSolvabiliteClientAsync(reservation.ClientId))
                throw new InvalidOperationException("Le client a des factures impayées");

            // Ajouter les équipements
            foreach (var equipementId in equipementIds)
            {
                reservation.EquipementsReserves.Add(new LocationEquipement
                {
                    EquipementId = equipementId,
                    ReservationId = reservation.Id,
                    DateDebut = reservation.DateDebut,
                    DateFin = reservation.DateFin
                });
            }

            await _dbSet.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<bool> AjouterOptionsReservationAsync(Guid reservationId, IEnumerable<string> options)
        {
            if (reservationId == Guid.Empty)
                throw new ArgumentException("L'identifiant de la réservation est invalide");
            if (options == null || !options.Any())
                throw new ArgumentException("Les options sont requises");

            var reservation = await _dbSet.FindAsync(reservationId);
            if (reservation == null)
                throw new KeyNotFoundException($"Aucune réservation trouvée avec l'ID {reservationId}");

            foreach (var option in options)
            {
                reservation.Options.Add(option);
            }

            reservation.DateModification = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AjouterEquipementsReservationAsync(Guid reservationId, IEnumerable<Guid> equipementIds)
        {
            if (reservationId == Guid.Empty)
                throw new ArgumentException("L'identifiant de la réservation est invalide");
            if (equipementIds == null || !equipementIds.Any())
                throw new ArgumentException("Les équipements sont requis");

            var reservation = await _dbSet
                .Include(r => r.EquipementsReserves)
                .FirstOrDefaultAsync(r => r.Id == reservationId);

            if (reservation == null)
                throw new KeyNotFoundException($"Aucune réservation trouvée avec l'ID {reservationId}");

            foreach (var equipementId in equipementIds)
            {
                reservation.EquipementsReserves.Add(new LocationEquipement
                {
                    EquipementId = equipementId,
                    ReservationId = reservationId,
                    DateDebut = reservation.DateDebut,
                    DateFin = reservation.DateFin
                });
            }

            reservation.DateModification = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AjouterServicesSupplementairesAsync(Guid reservationId, IEnumerable<string> services)
        {
            if (reservationId == Guid.Empty)
                throw new ArgumentException("L'identifiant de la réservation est invalide");
            if (services == null || !services.Any())
                throw new ArgumentException("Les services sont requis");

            var reservation = await _dbSet.FindAsync(reservationId);
            if (reservation == null)
                throw new KeyNotFoundException($"Aucune réservation trouvée avec l'ID {reservationId}");

            foreach (var service in services)
            {
                reservation.ServicesSupplementaires.Add(service);
            }

            reservation.DateModification = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ModifierReservationAsync(Guid reservationId, DateTime nouvelleDateDebut, DateTime nouvelleDateFin)
        {
            if (reservationId == Guid.Empty)
                throw new ArgumentException("L'identifiant de la réservation est invalide");
            if (nouvelleDateDebut >= nouvelleDateFin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            var reservation = await _dbSet.FindAsync(reservationId);
            if (reservation == null)
                throw new KeyNotFoundException($"Aucune réservation trouvée avec l'ID {reservationId}");

            if (await VerifierChevauchementReservationsAsync(reservation.EspaceId, nouvelleDateDebut, nouvelleDateFin, reservationId))
                return false;

            reservation.DateDebut = nouvelleDateDebut;
            reservation.DateFin = nouvelleDateFin;
            reservation.DateModification = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ConfirmerReservationAsync(Guid reservationId)
        {
            if (reservationId == Guid.Empty)
                throw new ArgumentException("L'identifiant de la réservation est invalide");

            var reservation = await _dbSet.FindAsync(reservationId);
            if (reservation == null)
                throw new KeyNotFoundException($"Aucune réservation trouvée avec l'ID {reservationId}");

            reservation.Statut = "Confirmée";
            reservation.DateModification = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AnnulerReservationAsync(Guid reservationId, string motifAnnulation)
        {
            if (reservationId == Guid.Empty)
                throw new ArgumentException("L'identifiant de la réservation est invalide");
            if (string.IsNullOrWhiteSpace(motifAnnulation))
                throw new ArgumentException("Le motif d'annulation est requis");

            var reservation = await _dbSet.FindAsync(reservationId);
            if (reservation == null)
                throw new KeyNotFoundException($"Aucune réservation trouvée avec l'ID {reservationId}");

            reservation.Statut = "Annulée";
            reservation.MotifAnnulation = motifAnnulation;
            reservation.DateModification = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePointsFideliteAsync(Guid clientId, int points)
        {
            if (clientId == Guid.Empty)
                throw new ArgumentException("L'identifiant du client est invalide");

            var client = await _context.Set<Client>()
                .FirstOrDefaultAsync(c => c.Id == clientId);

            if (client == null)
                throw new KeyNotFoundException($"Aucun client trouvé avec l'ID {clientId}");

            client.PointsFidelite += points;
            client.DateModification = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Espace>> ObtenirEspacesDisponiblesAsync(DateTime dateDebut, DateTime dateFin, int? capaciteMinimum = null)
        {
            if (dateDebut >= dateFin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            var espacesOccupes = await _dbSet
                .Where(r => r.Statut != "Annulée" &&
                           ((r.DateDebut <= dateDebut && r.DateFin > dateDebut) ||
                            (r.DateDebut < dateFin && r.DateFin >= dateFin) ||
                            (r.DateDebut >= dateDebut && r.DateFin <= dateFin)))
                .Select(r => r.EspaceId)
                .Distinct()
                .ToListAsync();

            var query = _context.Set<Espace>()
                .Where(e => !espacesOccupes.Contains(e.Id) && e.EstActif);

            if (capaciteMinimum.HasValue)
            {
                query = query.Where(e => e.Capacite >= capaciteMinimum.Value);
            }

            return await query.OrderBy(e => e.Nom).ToListAsync();
        }

        public async Task<IEnumerable<DateTime>> ObtenirCreneauxDisponiblesAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin)
        {
            if (espaceId == Guid.Empty)
                throw new ArgumentException("L'identifiant de l'espace est invalide");
            if (dateDebut >= dateFin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            var creneauxDisponibles = new List<DateTime>();
            var reservations = await _dbSet
                .Where(r => r.EspaceId == espaceId && 
                           r.Statut != "Annulée" &&
                           r.DateDebut.Date >= dateDebut.Date && 
                           r.DateFin.Date <= dateFin.Date)
                .OrderBy(r => r.DateDebut)
                .ToListAsync();

            var dateActuelle = dateDebut.Date;
            while (dateActuelle <= dateFin.Date)
            {
                if (!reservations.Any(r => r.DateDebut.Date == dateActuelle))
                {
                    creneauxDisponibles.Add(dateActuelle);
                }
                dateActuelle = dateActuelle.AddDays(1);
            }

            return creneauxDisponibles;
        }

        public async Task<decimal> CalculerMontantTotalReservationsAsync(DateTime dateDebut, DateTime dateFin)
        {
            if (dateDebut > dateFin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            return await _dbSet
                .Where(r => r.DateDebut >= dateDebut && r.DateFin <= dateFin && r.Statut != "Annulée")
                .SumAsync(r => r.MontantTotal);
        }

        public async Task<Dictionary<string, int>> ObtenirStatistiquesParEspaceAsync(DateTime debut, DateTime fin)
        {
            if (debut > fin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            return await _dbSet
                .Where(r => r.DateDebut >= debut && r.DateFin <= fin && r.Statut != "Annulée")
                .GroupBy(r => r.Espace.Nom)
                .Select(g => new { Espace = g.Key, Nombre = g.Count() })
                .ToDictionaryAsync(x => x.Espace, x => x.Nombre);
        }

        public async Task<Dictionary<DateTime, int>> ObtenirOccupationParJourAsync(DateTime debut, DateTime fin)
        {
            if (debut > fin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            return await _dbSet
                .Where(r => r.DateDebut.Date >= debut.Date && r.DateDebut.Date <= fin.Date && r.Statut != "Annulée")
                .GroupBy(r => r.DateDebut.Date)
                .Select(g => new { Date = g.Key, Nombre = g.Count() })
                .ToDictionaryAsync(x => x.Date, x => x.Nombre);
        }

        public async Task<Dictionary<string, decimal>> ObtenirRevenusParEspaceAsync(DateTime debut, DateTime fin)
        {
            if (debut > fin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            return await _dbSet
                .Where(r => r.DateDebut >= debut && r.DateFin <= fin && r.Statut != "Annulée")
                .GroupBy(r => r.Espace.Nom)
                .Select(g => new { Espace = g.Key, Revenu = g.Sum(r => r.MontantTotal) })
                .ToDictionaryAsync(x => x.Espace, x => x.Revenu);
        }

        public async Task<double> ObtenirTauxOccupationAsync(Guid espaceId, DateTime debut, DateTime fin)
        {
            if (espaceId == Guid.Empty)
                throw new ArgumentException("L'identifiant de l'espace est invalide");
            if (debut > fin)
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");

            var totalJours = (fin - debut).Days + 1;
            var joursOccupes = await _dbSet
                .Where(r => r.EspaceId == espaceId && 
                           r.Statut != "Annulée" &&
                           r.DateDebut.Date >= debut.Date && 
                           r.DateFin.Date <= fin.Date)
                .Select(r => new { debut = r.DateDebut.Date, fin = r.DateFin.Date })
                .ToListAsync();

            var joursUniques = joursOccupes
                .SelectMany(r => Enumerable.Range(0, (r.fin - r.debut).Days + 1)
                    .Select(offset => r.debut.AddDays(offset)))
                .Distinct()
                .Count();

            return (double)joursUniques / totalJours * 100;
        }
    }
} 