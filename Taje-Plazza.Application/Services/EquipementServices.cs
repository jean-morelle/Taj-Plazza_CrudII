using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Interface;
using Taje__Plazza.Domain.Models;

namespace Taje_Plazza.Application.Services
{
    public class EquipementServices:IEquipementServices
    {
        private readonly IEquipementRepertory equipementRepertory;

        public EquipementServices(IEquipementRepertory equipementRepertory )
        {
            this.equipementRepertory = equipementRepertory;
        }

        public async Task AjouterEquipement(Equipement equipement)
        {
            await equipementRepertory.AjouterEquipement( equipement );
        }

        public async Task MettreAjoursEquipementAsync(Equipement equipement)
        {
            await equipementRepertory.MettreAjoursEquipementAsync(equipement);
        }

        public async Task<Equipement> ObtenirEquipement(Guid equipementId)
        {
           var equipement = await equipementRepertory.ObtenirEquipement(equipementId);
            return equipement;
        }

        public async Task<IEnumerable<Equipement>> ObtenirTousLesEquipemntsAsync()
        {
            var equipement = await equipementRepertory.ObtenirTousLesEquipemntsAsync();
            return equipement;
        }

        public async Task SupprimerEquipement(Guid equipementId)
        {
            await equipementRepertory.SupprimerEquipement(equipementId);
            
        }
    }
}
