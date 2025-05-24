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
    public class EspaceRepertory :IEspaceRepertory
    {
        private readonly ApplicationDbContext applicationDbContext;

        public EspaceRepertory(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AjouterEspaceAsync(Espace espace)
        {
            applicationDbContext.Espaces.Add(espace);
            await SaveChangeAsync();
        }

        public async Task MettreAjourEspaceAsync(Espace espace)
        {
            applicationDbContext.Espaces.Update(espace);
            await SaveChangeAsync();
        }

        public async Task<Espace> ObtenirEspaceAsync(Guid espaceId)
        {
            var espace = await applicationDbContext.Espaces.FirstOrDefaultAsync(x => x.Id == espaceId);
                 return espace == null ? throw new Exception() : espace;
        }

        public async Task<IEnumerable<Espace>> ObtenirTousLesEspaceAsync()
        {
            var espace = await applicationDbContext.Espaces.ToListAsync();
            return espace;
        }

        public async Task SaveChangeAsync()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task SupprimerEspaceAsync(Guid espaceId)
        {
            var espace = await applicationDbContext.Espaces.FindAsync(espaceId);
            if (espace is null)
            {
                throw new Exception();
            }
            else
            {
                applicationDbContext.Espaces.Update(espace);
                await SaveChangeAsync();
            }
        }
    }
}
