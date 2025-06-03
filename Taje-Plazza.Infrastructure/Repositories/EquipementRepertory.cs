using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taj_Plazza.Core.DataAcess;
using Taje__Plazza.Domain.Interface;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Infrastructure.Repositories
{
    public class EquipementRepertory :GenericRepository<Equipement>,IEquipementRepository
    {

        public EquipementRepertory(ApplicationDbContext context):base(context) 
        {
            
        }

        protected override IQueryable<Equipement> IncludeAll()
            {
                return _dbSet
                    .Include(e => e.Locations)
                    .Include(e => e.Maintenances);
            }

            public async Task<IEnumerable<Equipement>> ObtenirEquipementsDisponiblesAsync(DateTime dateDebut, DateTime dateFin)
            {
                if (dateDebut >= dateFin)
                    throw new ArgumentException("La date de début doit être antérieure à la date de fin");

                var equipementsOccupes = await _context.LocationsEquipements
                    .Where(l => l.Statut != "Annulée" &&
                               ((l.DateDebut <= dateDebut && l.DateFin > dateDebut) ||
                                (l.DateDebut < dateFin && l.DateFin >= dateFin) ||
                                (l.DateDebut >= dateDebut && l.DateFin <= dateFin)))
                    .Select(l => l.EquipementId)
                    .Distinct()
                    .ToListAsync();

                var equipementsEnMaintenance = await _context.MaintenancesEquipements
                    .Where(m => (m.DateDebut <= dateDebut && m.DateFin > dateDebut) ||
                               (m.DateDebut < dateFin && m.DateFin >= dateFin) ||
                               (m.DateDebut >= dateDebut && m.DateFin <= dateFin))
                    .Select(m => m.EquipementId)
                    .Distinct()
                    .ToListAsync();

                return await _dbSet
                    .Where(e => !equipementsOccupes.Contains(e.Id) &&
                               !equipementsEnMaintenance.Contains(e.Id) &&
                               e.EstActif)
                    .OrderBy(e => e.Nom)
                    .ToListAsync();
            }

            public async Task<IEnumerable<Equipement>> ObtenirEquipementsParTypeAsync(string type)
            {
                if (string.IsNullOrWhiteSpace(type))
                    throw new ArgumentException("Le type d'équipement est requis");

                return await _dbSet
                    .Where(e => e.Type == type && e.EstActif)
                    .OrderBy(e => e.Nom)
                    .ToListAsync();
            }

            public async Task<IEnumerable<Equipement>> ObtenirEquipementsEnMaintenanceAsync()
            {
                var maintenant = DateTime.Now;
                var equipementsEnMaintenance = await _context.MaintenancesEquipements
                    .Where(m => m.DateDebut <= maintenant && m.DateFin >= maintenant)
                    .Select(m => m.EquipementId)
                    .Distinct()
                    .ToListAsync();

                return await _dbSet
                    .Where(e => equipementsEnMaintenance.Contains(e.Id))
                    .OrderBy(e => e.Nom)
                    .ToListAsync();
            }

            public async Task<bool> VerifierDisponibiliteLocationAsync(Guid equipementId, DateTime dateDebut, DateTime dateFin)
            {
                if (equipementId == Guid.Empty)
                    throw new ArgumentException("L'identifiant de l'équipement est invalide");
                if (dateDebut >= dateFin)
                    throw new ArgumentException("La date de début doit être antérieure à la date de fin");

                // Vérifier si l'équipement existe et est actif
                var equipement = await _dbSet.FindAsync(equipementId);
                if (equipement == null || !equipement.EstActif)
                    return false;

                // Vérifier les locations existantes
                var locationExistante = await _context.LocationsEquipements
                    .AnyAsync(l => l.EquipementId == equipementId &&
                                  l.Statut != "Annulée" &&
                                  ((l.DateDebut <= dateDebut && l.DateFin > dateDebut) ||
                                   (l.DateDebut < dateFin && l.DateFin >= dateFin) ||
                                   (l.DateDebut >= dateDebut && l.DateFin <= dateFin)));

                // Vérifier les maintenances planifiées
                var maintenanceExistante = await _context.MaintenancesEquipements
                    .AnyAsync(m => m.EquipementId == equipementId &&
                                  ((m.DateDebut <= dateDebut && m.DateFin > dateDebut) ||
                                   (m.DateDebut < dateFin && m.DateFin >= dateFin) ||
                                   (m.DateDebut >= dateDebut && m.DateFin <= dateFin)));

                return !locationExistante && !maintenanceExistante;
            }

            public async Task<LocationEquipement> AjouterLocationAsync(Guid equipementId, Guid reservationId, DateTime dateDebut, DateTime dateFin)
            {
                if (equipementId == Guid.Empty)
                    throw new ArgumentException("L'identifiant de l'équipement est invalide");
                if (reservationId == Guid.Empty)
                    throw new ArgumentException("L'identifiant de la réservation est invalide");
                if (dateDebut >= dateFin)
                    throw new ArgumentException("La date de début doit être antérieure à la date de fin");

                if (!await VerifierDisponibiliteLocationAsync(equipementId, dateDebut, dateFin))
                    throw new InvalidOperationException("L'équipement n'est pas disponible pour cette période");

                var equipement = await _dbSet.FindAsync(equipementId);
                if (equipement == null)
                    throw new KeyNotFoundException($"Aucun équipement trouvé avec l'ID {equipementId}");

                var location = new LocationEquipement
                {
                    Id = Guid.NewGuid(),
                    EquipementId = equipementId,
                    ReservationId = reservationId,
                    DateDebut = dateDebut,
                    DateFin = dateFin,
                    Statut = "En cours",
                    DateCreation = DateTime.Now,
                    MontantLocation = await CalculerCoutLocationAsync(equipementId, dateDebut, dateFin)
                };

                await _context.LocationsEquipements.AddAsync(location);
                await _context.SaveChangesAsync();
                return location;
            }

            public async Task<bool> AnnulerLocationAsync(Guid locationId, string motifAnnulation)
            {
                if (locationId == Guid.Empty)
                    throw new ArgumentException("L'identifiant de la location est invalide");
                if (string.IsNullOrWhiteSpace(motifAnnulation))
                    throw new ArgumentException("Le motif d'annulation est requis");

                var location = await _context.LocationsEquipements.FindAsync(locationId);
                if (location == null)
                    throw new KeyNotFoundException($"Aucune location trouvée avec l'ID {locationId}");

                location.Statut = "Annulée";
                location.MotifAnnulation = motifAnnulation;
                location.DateModification = DateTime.Now;
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<bool> ModifierPeriodeLocationAsync(Guid locationId, DateTime nouvelleDateDebut, DateTime nouvelleDateFin)
            {
                if (locationId == Guid.Empty)
                    throw new ArgumentException("L'identifiant de la location est invalide");
                if (nouvelleDateDebut >= nouvelleDateFin)
                    throw new ArgumentException("La date de début doit être antérieure à la date de fin");

                var location = await _context.LocationsEquipements.FindAsync(locationId);
                if (location == null)
                    throw new KeyNotFoundException($"Aucune location trouvée avec l'ID {locationId}");

                // Vérifier la disponibilité pour la nouvelle période
                if (!await VerifierDisponibiliteLocationAsync(location.EquipementId, nouvelleDateDebut, nouvelleDateFin))
                    return false;

                location.DateDebut = nouvelleDateDebut;
                location.DateFin = nouvelleDateFin;
                location.DateModification = DateTime.Now;
                location.MontantLocation = await CalculerCoutLocationAsync(location.EquipementId, nouvelleDateDebut, nouvelleDateFin);
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<IEnumerable<LocationEquipement>> ObtenirLocationsEnCoursAsync()
            {
                var maintenant = DateTime.Now;
                return await _context.LocationsEquipements
                    .Include(l => l.Equipement)
                    .Include(l => l.Reservation)
                    .Where(l => l.DateDebut <= maintenant && l.DateFin >= maintenant && l.Statut != "Annulée")
                    .OrderBy(l => l.DateFin)
                    .ToListAsync();
            }

            public async Task<IEnumerable<LocationEquipement>> ObtenirLocationsParPeriodeAsync(DateTime dateDebut, DateTime dateFin)
            {
                if (dateDebut >= dateFin)
                    throw new ArgumentException("La date de début doit être antérieure à la date de fin");

                return await _context.LocationsEquipements
                    .Include(l => l.Equipement)
                    .Include(l => l.Reservation)
                    .Where(l => l.DateDebut >= dateDebut && l.DateFin <= dateFin)
                    .OrderBy(l => l.DateDebut)
                    .ToListAsync();
            }

            public async Task<IEnumerable<LocationEquipement>> ObtenirLocationsParReservationAsync(Guid reservationId)
            {
                if (reservationId == Guid.Empty)
                    throw new ArgumentException("L'identifiant de la réservation est invalide");

                return await _context.LocationsEquipements
                    .Include(l => l.Equipement)
                    .Where(l => l.ReservationId == reservationId)
                    .OrderBy(l => l.DateDebut)
                    .ToListAsync();
            }

            public async Task<bool> AjouterMaintenanceAsync(MaintenanceEquipement maintenance)
            {
                if (maintenance == null)
                    throw new ArgumentNullException(nameof(maintenance));
                if (maintenance.EquipementId == Guid.Empty)
                    throw new ArgumentException("L'identifiant de l'équipement est invalide");
                if (maintenance.DateDebut >= maintenance.DateFin)
                    throw new ArgumentException("La date de début doit être antérieure à la date de fin");

                // Vérifier si l'équipement est disponible pour la maintenance
                if (!await VerifierDisponibiliteLocationAsync(maintenance.EquipementId, maintenance.DateDebut, maintenance.DateFin))
                    return false;

                maintenance.Id = Guid.NewGuid();
                maintenance.DateCreation = DateTime.Now;
                await _context.MaintenancesEquipements.AddAsync(maintenance);
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<IEnumerable<MaintenanceEquipement>> ObtenirHistoriqueMaintenanceAsync(Guid equipementId)
            {
                if (equipementId == Guid.Empty)
                    throw new ArgumentException("L'identifiant de l'équipement est invalide");

                return await _context.MaintenancesEquipements
                    .Where(m => m.EquipementId == equipementId)
                    .OrderByDescending(m => m.DateDebut)
                    .ToListAsync();
            }

            public async Task<bool> AjouterPlanificationMaintenanceAsync(Guid equipementId, DateTime dateDebut, DateTime dateFin, string type)
            {
                if (equipementId == Guid.Empty)
                    throw new ArgumentException("L'identifiant de l'équipement est invalide");
                if (dateDebut >= dateFin)
                    throw new ArgumentException("La date de début doit être antérieure à la date de fin");
                if (string.IsNullOrWhiteSpace(type))
                    throw new ArgumentException("Le type de maintenance est requis");

                var maintenance = new MaintenanceEquipement
                {
                    Id = Guid.NewGuid(),
                    EquipementId = equipementId,
                    DateDebut = dateDebut,
                    DateFin = dateFin,
                    Type = type,
                    Statut = "Planifiée",
                    DateCreation = DateTime.Now
                };

                return await AjouterMaintenanceAsync(maintenance);
            }

            public async Task<decimal> CalculerCoutLocationAsync(Guid equipementId, DateTime dateDebut, DateTime dateFin)
            {
                if (equipementId == Guid.Empty)
                    throw new ArgumentException("L'identifiant de l'équipement est invalide");
                if (dateDebut >= dateFin)
                    throw new ArgumentException("La date de début doit être antérieure à la date de fin");

                var equipement = await _dbSet.FindAsync(equipementId);
                if (equipement == null)
                    throw new KeyNotFoundException($"Aucun équipement trouvé avec l'ID {equipementId}");

                var nombreJours = (dateFin - dateDebut).Days;
                return equipement.TarifJournalier * nombreJours;
            }

            public async Task<Dictionary<string, decimal>> ObtenirStatistiquesLocationAsync(DateTime dateDebut, DateTime dateFin)
            {
                if (dateDebut >= dateFin)
                    throw new ArgumentException("La date de début doit être antérieure à la date de fin");

                return await _context.LocationsEquipements
                    .Include(l => l.Equipement)
                    .Where(l => l.DateDebut >= dateDebut && l.DateFin <= dateFin && l.Statut != "Annulée")
                    .GroupBy(l => l.Equipement.Type)
                    .Select(g => new { Type = g.Key, Revenu = g.Sum(l => l.MontantLocation) })
                    .ToDictionaryAsync(x => x.Type, x => x.Revenu);
            }

            public async Task<double> ObtenirTauxUtilisationAsync(Guid equipementId, DateTime dateDebut, DateTime dateFin)
            {
                if (equipementId == Guid.Empty)
                    throw new ArgumentException("L'identifiant de l'équipement est invalide");
                if (dateDebut >= dateFin)
                    throw new ArgumentException("La date de début doit être antérieure à la date de fin");

                var totalJours = (dateFin - dateDebut).Days;
                var joursUtilises = await _context.LocationsEquipements
                    .Where(l => l.EquipementId == equipementId &&
                               l.Statut != "Annulée" &&
                               l.DateDebut.Date >= dateDebut.Date &&
                               l.DateFin.Date <= dateFin.Date)
                    .Select(l => new { debut = l.DateDebut.Date, fin = l.DateFin.Date })
                    .ToListAsync();

                var joursUniques = joursUtilises
                    .SelectMany(l => Enumerable.Range(0, (l.fin - l.debut).Days + 1)
                        .Select(offset => l.debut.AddDays(offset)))
                    .Distinct()
                    .Count();

                return (double)joursUniques / totalJours * 100;
            }
        }
}
