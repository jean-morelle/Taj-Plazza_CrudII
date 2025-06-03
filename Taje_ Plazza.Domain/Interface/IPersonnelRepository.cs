using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Domain.Interface;
using Taje_Plazza.Domain.Models;

namespace Taje__Plazza.Domain.Interface
{
    public interface IPersonnelRepository : IGenericRepository<Personnel>
    {
        Task<IEnumerable<Personnel>> ObtenirParFonctionAsync(string fonction);
        Task<IEnumerable<Personnel>> ObtenirPersonnelDisponibleAsync(DateTime dateDebut, DateTime dateFin);
        Task<IEnumerable<Evenement>> ObtenirAffectationsAsync(Guid personnelId, DateTime dateDebut, DateTime dateFin);
        Task<bool> VerifierDisponibiliteAsync(Guid personnelId, DateTime dateDebut, DateTime dateFin);
        Task EnregistrerCongeAsync(Guid personnelId, DateTime dateDebut, DateTime dateFin, string type);
        Task<IEnumerable<Personnel>> ObtenirPersonnelEnCongeAsync(DateTime date);
        Task<int> CalculerHeuresTravailleesAsync(Guid personnelId, DateTime dateDebut, DateTime dateFin);
        Task AjouterCompetenceAsync(Guid personnelId, string competence);
        Task<IEnumerable<string>> ObtenirCompetencesAsync(Guid personnelId);
        Task<IEnumerable<Personnel>> RechercherParCompetencesAsync(IEnumerable<string> competences);
        Task<Personnel> AjouterPersonnelCompletAsync(Personnel personnel, IEnumerable<string> competences);
        Task<bool> AjouterFormationAsync(Guid personnelId, string formation, DateTime date);
        Task<bool> AjouterDisponibiliteAsync(Guid personnelId, DateTime debut, DateTime fin);
        Task<bool> AjouterSpecialisationAsync(Guid personnelId, string specialisation);
        Task<bool> AjouterCertificationAsync(Guid personnelId, string certification, DateTime dateObtention);
    }
} 