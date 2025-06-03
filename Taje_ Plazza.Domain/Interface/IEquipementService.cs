using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Domain.Interface
{
    public interface IEquipementService
    {
        // Méthodes de consultation
        Task<IEnumerable<Equipement>> ObtenirEquipementsDisponiblesAsync(DateTime dateDebut, DateTime dateFin);
        Task<IEnumerable<Equipement>> ObtenirEquipementsParTypeAsync(string type);
        Task<IEnumerable<Equipement>> ObtenirEquipementsEnMaintenanceAsync();

        // Méthodes de gestion des locations
        Task<bool> VerifierDisponibiliteLocationAsync(Guid equipementId, DateTime dateDebut, DateTime dateFin);
        Task<LocationEquipement> AjouterLocationAsync(Guid equipementId, Guid reservationId, DateTime dateDebut, DateTime dateFin);
        Task<bool> AnnulerLocationAsync(Guid locationId, string motifAnnulation);
        Task<bool> ModifierPeriodeLocationAsync(Guid locationId, DateTime nouvelleDateDebut, DateTime nouvelleDateFin);
        Task<IEnumerable<LocationEquipement>> ObtenirLocationsEnCoursAsync();
        Task<IEnumerable<LocationEquipement>> ObtenirLocationsParPeriodeAsync(DateTime dateDebut, DateTime dateFin);
        Task<IEnumerable<LocationEquipement>> ObtenirLocationsParReservationAsync(Guid reservationId);

        // Méthodes de gestion de la maintenance
        Task<bool> AjouterMaintenanceAsync(MaintenanceEquipement maintenance);
        Task<IEnumerable<MaintenanceEquipement>> ObtenirHistoriqueMaintenanceAsync(Guid equipementId);
        Task<bool> AjouterPlanificationMaintenanceAsync(Guid equipementId, DateTime dateDebut, DateTime dateFin, string type);

        // Méthodes de calcul
        Task<decimal> CalculerCoutLocationAsync(Guid equipementId, DateTime dateDebut, DateTime dateFin);
        Task<Dictionary<string, decimal>> ObtenirStatistiquesLocationAsync(DateTime dateDebut, DateTime dateFin);
        Task<double> ObtenirTauxUtilisationAsync(Guid equipementId, DateTime dateDebut, DateTime dateFin);
    }
} 