using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taj_Plazza.Core.DataAcess;
using Taje__Plazza.Domain.Interface;
using Taje__Plazza.Domain.Models;

namespace Taje_Plazza.Infrastructure.Repertory
{
    public class EquipementRepertory:IEquipementRepertory
    {
        private readonly ApplicationDbContext applicationDbContext;

        public EquipementRepertory(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AjouterEquipement(Equipement equipement)
        {
            applicationDbContext.Equipements.Add(equipement);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task MettreAjoursEquipementAsync(Equipement equipement)
        {
            applicationDbContext.Equipements.Update(equipement);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<Equipement> ObtenirEquipement(Guid equipementId)
        {
            var equipement = await applicationDbContext.Equipements.FirstOrDefaultAsync(x=>x.Id==equipementId);
            return equipement == null ?throw new Exception() :  equipement;
        }

        public async Task<IEnumerable<Equipement>> ObtenirTousLesEquipemntsAsync()
        {
            var equipement = await applicationDbContext.Equipements.ToListAsync();
            return equipement;
        }

        public async Task SupprimerEquipement(Guid equipementId)
        {
            var equipement = await applicationDbContext.Equipements.FirstOrDefaultAsync(x=>x.Id==equipementId);
            if (equipement == null) throw new Exception();
            else  applicationDbContext.Equipements.Remove(equipement);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
 