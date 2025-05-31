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

        public EquipementServices(IEquipementRepertory equipementRepertory)
        {
            this.equipementRepertory = equipementRepertory;
        }

        public Task AjouterEquipement(Equipement equipement)
        {
            equipementRepertory.AjouterEquipement(equipement);
            return equipementRepertory.SaveChangeAsync();
        }

        public Task MettreAjoursEquipementAsync(Equipement equipement)
        {
            equipementRepertory.MettreAjoursEquipementAsync(equipement);
            return equipementRepertory.SaveChangeAsync();
        }

        public Task<Equipement> ObtenirEquipement(Guid equipementId)
        {
            var equipement = equipementRepertory.ObtenirEquipement(equipementId);
            return equipement;
        }

        public Task<IEnumerable<Equipement>> ObtenirTousLesEquipemntsAsync()
        {
            var equipements = equipementRepertory.ObtenirTousLesEquipemntsAsync();
            return equipements;
        }

        public async Task SaveChangeAsync()
        {
            await equipementRepertory.SaveChangeAsync();
        }

        public async Task SupprimerEquipement(Guid equipementId)
        {
            await equipementRepertory.SupprimerEquipement(equipementId);
            await SaveChangeAsync();
        }
    }
}
