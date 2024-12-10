using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.DataAcess;
using Taj_Plazza.Core.Models;
using Taje__Plazza.Domain.Interface;

namespace Taje_Plazza.Infrastructure.Repertory
{
    public class EvenementRepertory :IEvenementRepertory
    {
        private readonly ApplicationDbContext dbContext;

        public EvenementRepertory(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddEvenementAsync(Evenement addEvenement)
        {
            await dbContext.Evenements.AddAsync(addEvenement);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteEvenementAsync(int evenementId)
        {
            var evenement = await dbContext.Evenements.FirstOrDefaultAsync(x=>x.Id ==evenementId); 
            if (evenement is not null) {

                 dbContext.Evenements.Remove(evenement);
                 await  dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<Evenement>> GetAllEvenementAsync()
        {
            var evenement = await dbContext.Evenements.ToListAsync();
            return evenement;
        }

        public async Task<List<Evenement>> GetClientEvenementAsync(int clientId)
        {
            var evenement = await dbContext.Evenements.Include(x => x.Client)
                 .Where(x => x.ClientId == clientId)
                 .ToListAsync();
            return evenement;
        }

        public async Task<Evenement> GetEvenementByIdAsync(int evenementId)
        {
            var evenement = await dbContext.Evenements.FindAsync(evenementId);
            return evenement;
        }

        public async Task UpdateEvenementAsync(Evenement updateEvenement)
        {
            dbContext.Evenements.Update(updateEvenement);
            await dbContext.SaveChangesAsync();
        }
    }
}
