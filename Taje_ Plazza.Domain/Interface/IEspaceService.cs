using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Domain.Interface
{
    public interface IEspaceService
    {
        // Méthodes de recherche
        Task<IEnumerable<Espace>> GetEspacesByTypeAsync(string type);
        Task<IEnumerable<Espace>> GetEspacesByCapaciteAsync(int capaciteMinimum, int capaciteMaximum);
        Task<IEnumerable<Espace>> SearchEspacesAsync(string searchTerm);
        Task<IEnumerable<Espace>> GetEspacesDisponiblesAsync(DateTime dateDebut, DateTime dateFin);

        // Méthodes de disponibilité
        Task<bool> IsEspaceAvailableAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin);
        Task<IEnumerable<DateTime>> GetCreneauxDisponiblesAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin);
        Task<bool> ReserverEspaceAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin, Guid clientId);

        // Méthodes de gestion
        Task<bool> UpdateStatutEspaceAsync(Guid espaceId, string nouveauStatut);
        Task<bool> ModifierCapaciteAsync(Guid espaceId, int nouvelleCapacite);
        Task<bool> ModifierTarifAsync(Guid espaceId, decimal nouveauTarif);
        Task<bool> AjouterEquipementAsync(Guid espaceId, Guid equipementId);

        // Méthodes de maintenance
        Task<IEnumerable<Maintenance>> GetMaintenancesForEspaceAsync(Guid espaceId);
        Task<bool> IsEspaceEnMaintenanceAsync(Guid espaceId, DateTime date);
        Task<DateTime?> GetProchaineDateMaintenanceAsync(Guid espaceId);
        Task<bool> PlanifierMaintenanceAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin);

        // Méthodes de statistiques
        Task<int> GetTotalReservationsAsync(Guid espaceId);
        Task<decimal> GetTotalRevenusAsync(Guid espaceId);
        Task<double> GetTauxOccupationAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin);
        Task<Dictionary<DateTime, int>> GetOccupationParJourAsync(Guid espaceId, DateTime debut, DateTime fin);
        Task<Dictionary<string, decimal>> GetRevenusParPeriodeAsync(Guid espaceId, DateTime debut, DateTime fin);

        Task<IEnumerable<Espace>> ObtenirEspacesDisponiblesAsync(DateTime dateDebut, DateTime dateFin);
        Task<IEnumerable<Espace>> ObtenirEspacesParCapaciteAsync(int capaciteMinimum);
        Task<IEnumerable<Espace>> ObtenirEspacesParTypeAsync(string type);
        Task<bool> VerifierDisponibiliteEspaceAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin);
        Task<decimal> CalculerTauxOccupationAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin);
        Task<IEnumerable<Reservation>> ObtenirReservationsEspaceAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin);
        Task<decimal> CalculerRevenusEspaceAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin);
        Task<IEnumerable<Maintenance>> ObtenirHistoriqueMaintenanceAsync(Guid espaceId);

        // Méthodes d'ajout
        Task<Espace> AjouterEspaceCompletAsync(Espace espace, IEnumerable<Guid> equipementIds);
        Task<bool> AjouterConfigurationAsync(Guid espaceId, string configuration, int capacite);
        Task<bool> AjouterEquipementsFixesAsync(Guid espaceId, IEnumerable<Guid> equipementIds);
        Task<bool> AjouterRestrictionAccesAsync(Guid espaceId, string restriction);
        Task<bool> AjouterServiceAssocieAsync(Guid espaceId, string service, decimal cout);
    }
} 