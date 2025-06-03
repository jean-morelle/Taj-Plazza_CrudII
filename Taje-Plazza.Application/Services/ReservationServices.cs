using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Interface;
using Taje_Plazza.Domain.Interface;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Application.Services
{
    public class ReservationServices:IReservationService
    {
        private readonly IReservationRepository reservationRepository;
        private readonly IEquipementRepository equipementRepository;
        private readonly IEspaceRepository espaceRepository;

        public ReservationServices(IReservationRepository reservationRepository ,IEquipementRepository equipementRepository,IEspaceRepository espaceRepository)
        {
            this.reservationRepository = reservationRepository;
            this.equipementRepository = equipementRepository;
            this.espaceRepository = espaceRepository;
        }

        public async Task<bool> AjouterEquipementsReservationAsync(Guid reservationId, IEnumerable<Guid> equipementIds)
        {
          var ajouterEquipementsReservationAsync =  await reservationRepository.AjouterEquipementsReservationAsync(reservationId, equipementIds);
          return ajouterEquipementsReservationAsync;
        }

        public async Task<bool> AjouterOptionsReservationAsync(Guid reservationId, IEnumerable<string> options)
        {
            var ajouterOptionsReservationAsync =await reservationRepository.AjouterOptionsReservationAsync(reservationId,options);
            return ajouterOptionsReservationAsync;
        }

        public async Task<Reservation> AjouterReservationCompleteAsync(Reservation reservation, IEnumerable<Guid> equipementIds)
        {
            var ajouterReservationCompleteAsync = await reservationRepository.AjouterReservationCompleteAsync(reservation,equipementIds);
            return ajouterReservationCompleteAsync;
        }

        public async Task<bool> AjouterServicesSupplementairesAsync(Guid reservationId, IEnumerable<string> services)
        {
            var ajouterServicesSupplementairesAsync = await reservationRepository.AjouterServicesSupplementairesAsync(reservationId, services);
            return ajouterServicesSupplementairesAsync;
        }

        public async Task<bool> AnnulerReservationAsync(Guid reservationId, string motifAnnulation)
        {
            var annulerReservationAsync = await reservationRepository.AnnulerReservationAsync(reservationId, motifAnnulation);
            return annulerReservationAsync;
        }

        public async Task<decimal> CalculerMontantTotalReservationsAsync(DateTime dateDebut, DateTime dateFin)
        {
            var calculerMontantTotalReservationsAsync = await reservationRepository.CalculerMontantTotalReservationsAsync(dateDebut, dateFin);
            return calculerMontantTotalReservationsAsync;
        }

        public async Task<bool> ConfirmerReservationAsync(Guid reservationId)
        {
            var confirmerReservation = await reservationRepository.ConfirmerReservationAsync(reservationId);
            return confirmerReservation;
        }

        public async Task<bool> ModifierReservationAsync(Guid reservationId, DateTime nouvelleDateDebut, DateTime nouvelleDateFin)
        {
           var modifierReservationAsync = await reservationRepository.ModifierReservationAsync(reservationId, nouvelleDateDebut,nouvelleDateFin);
            return modifierReservationAsync;
        }

        public async Task<IEnumerable<DateTime>> ObtenirCreneauxDisponiblesAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin)
        {
            var obtenirCreneauxDisponibiliteAsync = await reservationRepository.ObtenirCreneauxDisponiblesAsync(espaceId, dateDebut, dateFin);
            return obtenirCreneauxDisponibiliteAsync;
        }

        public async Task<IEnumerable<Espace>> ObtenirEspacesDisponiblesAsync(DateTime dateDebut, DateTime dateFin, int? capaciteMinimum = null)
        {
           var obtenirEspacesDisponibleAsync = await reservationRepository.ObtenirEspacesDisponiblesAsync(dateDebut, dateFin, capaciteMinimum);
            return obtenirEspacesDisponibleAsync;
        }

        public async Task<Dictionary<DateTime, int>> ObtenirOccupationParJourAsync(DateTime debut, DateTime fin)
        {
            var obtenirOccupationParJoursAsync = await reservationRepository.ObtenirOccupationParJourAsync(debut, fin);
            return obtenirOccupationParJoursAsync;
        }

        public async Task<IEnumerable<Reservation>> ObtenirReservationsAVenirAsync()
        {
            var obtenirReservationsAvenirAsync = await reservationRepository.ObtenirReservationsAVenirAsync();
            return obtenirReservationsAvenirAsync;
        }

        public async Task<IEnumerable<Reservation>> ObtenirReservationsEnCoursAsync()
        {
         var obtenirReservationsEnCoursAsync = await reservationRepository.ObtenirReservationsEnCoursAsync();
            return obtenirReservationsEnCoursAsync;
        }

        public async Task<IEnumerable<Reservation>> ObtenirReservationsParClientAsync(Guid clientId)
        {
            var obtenirReservationsParClientAsync = await reservationRepository.ObtenirReservationsParClientAsync(clientId);
            return obtenirReservationsParClientAsync;
        }

        public async Task<IEnumerable<Reservation>> ObtenirReservationsParEspaceAsync(Guid espaceId)
        {
            var obtenirReservationsParEspaceAsync = await reservationRepository.ObtenirReservationsParEspaceAsync(espaceId);
            return obtenirReservationsParEspaceAsync;
        }

        public async Task<IEnumerable<Reservation>> ObtenirReservationsParPeriodeAsync(DateTime dateDebut, DateTime dateFin)
        {
            var obtenirReservationsParPeriodeAsync = await reservationRepository.ObtenirReservationsParPeriodeAsync(dateDebut, dateFin);
            return obtenirReservationsParPeriodeAsync;
        }

        public async Task<Dictionary<string, decimal>> ObtenirRevenusParEspaceAsync(DateTime debut, DateTime fin)
        {
           var obtenirRevenusParEspaceAsync = await reservationRepository.ObtenirRevenusParEspaceAsync(debut, fin);
            return obtenirRevenusParEspaceAsync ;
        }

        public async Task<Dictionary<string, int>> ObtenirStatistiquesParEspaceAsync(DateTime debut, DateTime fin)
        {
           var obtenirStatistiquesParEspaceAsync = await reservationRepository.ObtenirStatistiquesParEspaceAsync(debut.Date, fin.Date);
            return obtenirStatistiquesParEspaceAsync;
        }

        public async Task<double> ObtenirTauxOccupationAsync(Guid espaceId, DateTime debut, DateTime fin)
        {
            var obtenirTauxOccupationAsync = await reservationRepository.ObtenirTauxOccupationAsync(espaceId, debut.Date, fin.Date);
            return obtenirTauxOccupationAsync ;
        }

        public async Task<bool> UpdatePointsFideliteAsync(Guid clientId, int points)
        {
           var updatePointsFideliteAsync = await reservationRepository.UpdatePointsFideliteAsync(clientId,points);
            return updatePointsFideliteAsync ;
        }

        public async Task<bool> VerifierChevauchementReservationsAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin, Guid? reservationIdExclue = null)
        {
            var verifierChevauchementReservationsAsync = await reservationRepository.VerifierChevauchementReservationsAsync(espaceId, dateDebut.Date, dateFin.Date);
            return verifierChevauchementReservationsAsync ;
        }

        public async Task<bool> VerifierDisponibiliteAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin)
        {
           var verifierDisponibiliteAsync = await reservationRepository.VerifierDisponibiliteAsync(espaceId,dateDebut.Date, dateFin.Date);
            return verifierDisponibiliteAsync ;
        }

        public async Task<bool> VerifierSolvabiliteClientAsync(Guid clientId)
        {
            var VerifierSolvabiliteClientAsync = await reservationRepository.VerifierSolvabiliteClientAsync(clientId);
            return VerifierSolvabiliteClientAsync ;
        }
    }
}
