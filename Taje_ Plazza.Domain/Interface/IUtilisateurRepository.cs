using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Domain.Interface;

namespace Taje__Plazza.Domain.Interface
{
    public interface IUtilisateurRepository : IGenericRepository<Utilisateur>
    {
        Task<Utilisateur> ObtenirParEmailAsync(string email);
        Task<bool> VerifierEmailExisteAsync(string email);
        Task<IEnumerable<Utilisateur>> ObtenirParRoleAsync(string role);
        Task<bool> VerifierMotDePasseAsync(Guid userId, string motDePasse);
        Task ModifierMotDePasseAsync(Guid userId, string nouveauMotDePasse);
        Task ModifierRoleAsync(Guid userId, string nouveauRole);
        Task DesactiverCompteAsync(Guid userId);
        Task ActiverCompteAsync(Guid userId);
        Task<IEnumerable<Utilisateur>> ObtenirUtilisateursActifsAsync();
        Task<DateTime?> ObtenirDerniereConnexionAsync(Guid userId);
    }
} 