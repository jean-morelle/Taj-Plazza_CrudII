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
    public class FactureRepertory:IFactureRepertory
    {
        private readonly ApplicationDbContext applicationDbContext;

        public FactureRepertory(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AjouterFactureAsync(Facture facture)
        {
            applicationDbContext.Factures.Add(facture);
            await applicationDbContext.SaveChangesAsync();
        }

        public Task MettreAJourFactureAsync(Facture facture)
        {
            applicationDbContext.Factures.Update(facture);
            return applicationDbContext.SaveChangesAsync();
        }

        public async Task<Facture> ObtenirFactureParIdAsync(Guid id)
        {
            var facture = await applicationDbContext.Factures
                .FirstOrDefaultAsync(f => f.Id == id);
            return facture;
        }

        public async Task<IEnumerable<Facture>> ObtenirTousLesFacturesAsync()
        {
            var facture = await applicationDbContext.Factures.ToListAsync();
            return facture;
        }

        public async Task SupprimerFactureAsync(Guid id)
        {
            var facture = await applicationDbContext.Factures.FindAsync(id);
            if (facture != null)
            {
                applicationDbContext.Factures.Remove(facture);
                await applicationDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Facture not found.");
            }
        }
    }
}
