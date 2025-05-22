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
    public class EvenementRepertory:IEvenementRepertory
    {
        private readonly ApplicationDbContext applicationDbContext;

        public EvenementRepertory(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AjouterEvenementAsync(Evenement evenement)
        {
            applicationDbContext.Evenements.Add(evenement);
            await SaveChangeAsync();
        }

        public async Task MettreAjoursEvenementAsync(Evenement evenement)
        {
            applicationDbContext.Evenements.Update(evenement);
            await SaveChangeAsync();
        }

        public async Task<Evenement> ObtenirEvenementParIdAsync(Guid evenementId)
        {
            var evenement = await applicationDbContext.Evenements.FirstOrDefaultAsync(x=>x.Id == evenementId);
            return evenement == null ? throw new Exception() : evenement;
        }

        public async Task<IEnumerable<Evenement>> ObtenirTousLesEvenementAsync()
        {
            var evenements = await applicationDbContext.Evenements.Include(x => x.Client).Include(x => x.Client).ToListAsync();
            return evenements;
        }

        public async Task SaveChangeAsync()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task SupprimerEvenementAsync(Guid evenementId)
        {
            var evenement = await applicationDbContext.Evenements.FirstOrDefaultAsync(x => x.Id == evenementId);
            if (evenement is null)
                throw new Exception();
           else applicationDbContext.Evenements.Remove(evenement);
            await SaveChangeAsync();
        }
    }
}
