using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Domain.Interface
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        // Méthodes de recherche et consultation
        Task<IEnumerable<Reservation>> ObtenirReservationsParPeriodeAsync(DateTime dateDebut, DateTime dateFin);
        Task<IEnumerable<Reservation>> ObtenirReservationsParClientAsync(Guid clientId);
        Task<IEnumerable<Reservation>> ObtenirReservationsParEspaceAsync(Guid espaceId);
        Task<IEnumerable<Reservation>> ObtenirReservationsEnCoursAsync();
        Task<IEnumerable<Reservation>> ObtenirReservationsAVenirAsync();

        // Méthodes de vérification
        Task<bool> VerifierDisponibiliteAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin);
        Task<bool> VerifierChevauchementReservationsAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin, Guid? reservationIdExclue = null);
        Task<bool> VerifierSolvabiliteClientAsync(Guid clientId);

        // Méthodes d'ajout et modification
        Task<Reservation> AjouterReservationCompleteAsync(Reservation reservation, IEnumerable<Guid> equipementIds);
        Task<bool> AjouterOptionsReservationAsync(Guid reservationId, IEnumerable<string> options);
        Task<bool> AjouterEquipementsReservationAsync(Guid reservationId, IEnumerable<Guid> equipementIds);
        Task<bool> AjouterServicesSupplementairesAsync(Guid reservationId, IEnumerable<string> services);
        Task<bool> ModifierReservationAsync(Guid reservationId, DateTime nouvelleDateDebut, DateTime nouvelleDateFin);

        // Méthodes de gestion
        Task<bool> ConfirmerReservationAsync(Guid reservationId);
        Task<bool> AnnulerReservationAsync(Guid reservationId, string motifAnnulation);
        Task<bool> UpdatePointsFideliteAsync(Guid clientId, int points);

        // Méthodes de disponibilité
        Task<IEnumerable<Espace>> ObtenirEspacesDisponiblesAsync(DateTime dateDebut, DateTime dateFin, int? capaciteMinimum = null);
        Task<IEnumerable<DateTime>> ObtenirCreneauxDisponiblesAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin);

        // Méthodes de calcul et statistiques
        Task<decimal> CalculerMontantTotalReservationsAsync(DateTime dateDebut, DateTime dateFin);
        Task<Dictionary<string, int>> ObtenirStatistiquesParEspaceAsync(DateTime debut, DateTime fin);
        Task<Dictionary<DateTime, int>> ObtenirOccupationParJourAsync(DateTime debut, DateTime fin);
        Task<Dictionary<string, decimal>> ObtenirRevenusParEspaceAsync(DateTime debut, DateTime fin);
        Task<double> ObtenirTauxOccupationAsync(Guid espaceId, DateTime debut, DateTime fin);
    }
} 