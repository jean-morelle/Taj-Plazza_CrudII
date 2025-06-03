using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Domain.Models;

namespace Taje__Plazza.Domain.Interface
{
    interface IMaintenaceServices
    {
        // Méthodes de consultation
        Task<IEnumerable<Maintenance>> ObtenirMaintenancesParEspaceAsync(Guid espaceId);
        Task<IEnumerable<Maintenance>> ObtenirMaintenancesParEquipementAsync(Guid equipementId);
        Task<IEnumerable<Maintenance>> ObtenirMaintenancesEnCoursAsync();
        Task<IEnumerable<Maintenance>> ObtenirMaintenancesPlanifieesAsync(DateTime dateDebut, DateTime dateFin);

        // Méthodes de planification
        Task<Maintenance> AjouterMaintenanceEspaceAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin, string type);
        Task<Maintenance> AjouterMaintenanceEquipementAsync(Guid equipementId, DateTime dateDebut, DateTime dateFin, string type);

        // Méthodes de gestion d'état
        Task<bool> ModifierStatutMaintenanceAsync(Guid maintenanceId, string nouveauStatut);
        Task<bool> AjouterRapportMaintenanceAsync(Guid maintenanceId, string rapport);
        Task<bool> CloturerMaintenanceAsync(Guid maintenanceId, string resultat);

        // Méthodes de vérification
        Task<bool> VerifierDisponibiliteEspaceAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin);
        Task<bool> VerifierDisponibiliteEquipementAsync(Guid equipementId, DateTime dateDebut, DateTime dateFin);
        Task<DateTime?> ObtenirProchaineDateMaintenanceAsync(Guid espaceId);

        // Méthodes de gestion du personnel
        Task<Personnel> GetPersonnelByEmailAsync(string email);
        Task<IEnumerable<Personnel>> GetPersonnelByRoleAsync(string role);
        Task<bool> AssignerRolePersonnelAsync(Guid personnelId, string role);
        Task<bool> UpdateDisponibilitePersonnelAsync(Guid personnelId, bool disponible);
        Task<Dictionary<string, int>> GetCompetencesPersonnelAsync(Guid personnelId);

        // Méthodes de recherche
        Task<IEnumerable<Maintenance>> GetMaintenancesByEspaceAsync(Guid espaceId);
        Task<IEnumerable<Maintenance>> GetMaintenancesByPersonnelAsync(Guid personnelId);
        Task<IEnumerable<Maintenance>> GetMaintenancesByPeriodAsync(DateTime debut, DateTime fin);
        Task<IEnumerable<Maintenance>> GetMaintenancesByTypeAsync(string type);
        Task<IEnumerable<Maintenance>> GetMaintenancesByStatutAsync(string statut);

        // Méthodes de gestion
        Task<bool> AjouterAffectationPersonnelAsync(Guid maintenanceId, Guid personnelId);
        Task<bool> EnregistrerFinMaintenanceAsync(Guid maintenanceId, DateTime dateFin, string commentaires);
        Task<bool> AjouterCoutMaintenanceAsync(Guid maintenanceId, decimal cout);
        Task<bool> PlanifierMaintenanceAsync(Guid espaceId, DateTime dateDebut, string type);

        // Méthodes de planification
        Task<bool> IsPersonnelDisponibleAsync(Guid personnelId, DateTime date);
        Task<bool> IsEspaceDisponiblePourMaintenanceAsync(Guid espaceId, DateTime date);
        Task<IEnumerable<Personnel>> GetPersonnelDisponibleAsync(DateTime date);
        Task<IEnumerable<DateTime>> GetCreneauxDisponiblesAsync(Guid espaceId, DateTime debut, DateTime fin);

        // Méthodes de gestion des horaires
        Task<bool> AjouterHorairePersonnelAsync(Guid personnelId, DateTime date, TimeSpan debut, TimeSpan fin);
        Task<IEnumerable<KeyValuePair<DateTime, TimeSpan>>> GetHorairesPersonnelAsync(Guid personnelId, DateTime debut, DateTime fin);
        Task<bool> ModifierHorairePersonnelAsync(Guid personnelId, DateTime date, TimeSpan nouveauDebut, TimeSpan nouvelleFin);

        // Méthodes de statistiques
        Task<Dictionary<string, decimal>> GetCoutsParEspaceAsync(DateTime debut, DateTime fin);
        Task<double> GetDureeMoyenneMaintenanceAsync(string type);
        Task<Dictionary<string, int>> GetFrequenceMaintenanceParEspaceAsync(DateTime debut, DateTime fin);
        Task<Dictionary<string, double>> GetTauxReussiteParPersonnelAsync(DateTime debut, DateTime fin);
    }
}
