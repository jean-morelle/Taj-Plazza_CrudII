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
    public class EquipementRepertory : IEquipementRepertory
    {
        private readonly ApplicationDbContext applicationDbContext;

        public EquipementRepertory(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AjouterEquipement(Equipement equipement)
        {
            applicationDbContext.Equipements.Add(equipement);
            await SaveChangeAsync();
        }

        public async Task MettreAjoursEquipementAsync(Equipement equipement)
        {
            applicationDbContext.Equipements.Update(equipement);
            await SaveChangeAsync();
        }

        public async Task<Equipement> ObtenirEquipement(Guid equipementId)
        {
           var equipement = await applicationDbContext.Equipements.FindAsync(equipementId);
            return equipement ?? throw new KeyNotFoundException($"Equipement with ID {equipementId} not found.");
        }

        public async Task<IEnumerable<Equipement>> ObtenirTousLesEquipemntsAsync()
        {
            var equipements = await applicationDbContext.Equipements.ToListAsync();
            return equipements;
        }

        public async Task SaveChangeAsync()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task SupprimerEquipement(Guid equipementId)
        {
            var equipement = await applicationDbContext.Equipements.FindAsync(equipementId);
            if (equipement == null)
            {
                throw new KeyNotFoundException($"Equipement with ID {equipementId} not found.");
            }
            applicationDbContext.Equipements.Remove(equipement);
            await SaveChangeAsync();
        }
    }
}
