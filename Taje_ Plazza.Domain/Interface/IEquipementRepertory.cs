using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;

namespace Taje__Plazza.Domain.Interface
{
    public interface IEquipementRepertory
    {
        Task<IEnumerable<Equipement>> ObtenirTousLesEquipemntsAsync();
        Task<Equipement>ObtenirEquipement(Guid equipementId);
        Task AjouterEquipement(Equipement equipement);
        Task SupprimerEquipement(Guid equipementId);
        Task MettreAjoursEquipementAsync(Equipement equipement);
    }
}
