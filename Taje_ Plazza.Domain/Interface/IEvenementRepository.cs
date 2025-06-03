using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Domain.Interface;
using Taje_Plazza.Domain.Models;

namespace Taje__Plazza.Domain.Interface
{
    public interface IEvenementRepository : IGenericRepository<Evenement>
    {
        Task<IEnumerable<Evenement>> ObtenirEvenementsParPeriodeAsync(DateTime dateDebut, DateTime dateFin);
        Task<IEnumerable<Evenement>> ObtenirEvenementsParTypeAsync(string type);
        Task<IEnumerable<Evenement>> ObtenirEvenementsParEspaceAsync(Guid espaceId);
        Task<IEnumerable<Evenement>> ObtenirEvenementsAVenirAsync();
        Task<bool> VerifierDisponibiliteAsync(Guid espaceId, DateTime dateDebut, DateTime dateFin);
        Task<IEnumerable<Equipement>> ObtenirEquipementsRequitAsync(Guid evenementId);
        Task<decimal> CalculerCoutTotalAsync(Guid evenementId);
        Task AssignerPersonnelAsync(Guid evenementId, IEnumerable<Guid> personnelIds);
        Task<IEnumerable<Personnel>> ObtenirPersonnelAssigneAsync(Guid evenementId);
        Task<Evenement> AjouterEvenementCompletAsync(Evenement evenement, IEnumerable<Guid> personnelIds, IEnumerable<Guid> equipementIds);
        Task<bool> AjouterPrestationAsync(Guid evenementId, string prestation, decimal cout);
        Task<bool> AjouterParticipantAsync(Guid evenementId, string participant);
        Task<bool> AjouterProgrammationAsync(Guid evenementId, string activite, DateTime debut, DateTime fin);
        Task<bool> AjouterExigenceSpecialeAsync(Guid evenementId, string exigence);
    }
} 