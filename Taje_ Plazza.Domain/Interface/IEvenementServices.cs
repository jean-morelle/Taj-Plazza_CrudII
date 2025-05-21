using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;

namespace Taje__Plazza.Domain.Interface
{
    public interface IEvenementServices
    {
        Task<IEnumerable<Evenement>> ObtenirTousLesEvenementAsync();
        Task<Evenement> ObtenirEvenementParIdAsync(Guid evenementId);
        Task AjouterEvenementAsync(Evenement evenement);
        Task MettreAjoursEvenementAsync(Evenement evenement);
        Task SupprimerEvenementAsync(Guid evenementId);
        Task SaveChangeAsync();
    }
}
