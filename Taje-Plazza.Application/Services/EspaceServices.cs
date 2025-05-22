using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Interface;
using Taje__Plazza.Domain.Models;

namespace Taje_Plazza.Application.Services
{
    public class EspaceServices:IEspaceServices
    {
        private readonly IEspaceRepertory espaceRepertory;

        public EspaceServices(IEspaceRepertory espaceRepertory)
        {
            this.espaceRepertory = espaceRepertory;
        }

        public async Task AjouterEspaceAsync(Espace espace)
        {
            await espaceRepertory.AjouterEspaceAsync(espace);
            await espaceRepertory.SaveChangeAsync();
        }

        public async Task MettreAjourEspaceAsync(Espace espace)
        {
            await espaceRepertory.MettreAjourEspaceAsync(espace);
            await espaceRepertory.SaveChangeAsync();
        }

        public async Task<Espace> ObtenirEspaceAsync(Guid espaceId)
        {
            var espace = await espaceRepertory.ObtenirEspaceAsync(espaceId);
            return espace;
        }

        public async Task<IEnumerable<Espace>> ObtenirTousLesEspaceAsync()
        {
            var espace = await espaceRepertory.ObtenirTousLesEspaceAsync();
            return espace;
        }

        public async Task SaveChangeAsync()
        {
            await espaceRepertory.SaveChangeAsync();
        }

        public async Task SupprimerEspaceAsync(Guid espaceId)
        {
            await espaceRepertory.SupprimerEspaceAsync(espaceId);
            await espaceRepertory.SaveChangeAsync();
        }
    }
}
