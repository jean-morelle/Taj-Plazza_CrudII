using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;

namespace Taje__Plazza.Domain.Interface
{
    public interface IFactureRepertory
    {
        Task<IEnumerable<Facture>> ObtenirTousLesFacturesAsync();
        Task<Facture> ObtenirFactureParIdAsync(Guid id);
        Task AjouterFactureAsync(Facture facture);
        Task MettreAJourFactureAsync(Facture facture);
        Task SupprimerFactureAsync(Guid id);
    }
}
