using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;

namespace Taje__Plazza.Domain.Interface
{
    public interface IEspaceRepertory
    {
        Task<IEnumerable<Espace>> ObtenirTousLesEspaceAsync();
        Task<Espace> ObtenirEspaceAsync(Guid espaceId);
        Task AjouterEspaceAsync(Espace espace);
        Task SupprimerEspaceAsync(Guid espaceId);
        Task MettreAjourEspaceAsync(Espace espace);
        Task SaveChangeAsync();

    }
}
