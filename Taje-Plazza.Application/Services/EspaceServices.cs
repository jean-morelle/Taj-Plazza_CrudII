using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Interface;
using Taje__Plazza.Domain.Models;

namespace Taje_Plazza.Application.Services
{
    public class EspaceServices: IEspaceServices
    {
        private readonly IEspaceRepertory espaceRepertory;

        public EspaceServices(IEspaceRepertory espaceRepertory)
        {
            this.espaceRepertory = espaceRepertory;
        }

        public Task AjouterEspaceAsync(Espace espace)
        {
            espaceRepertory.AjouterEspaceAsync(espace);
            return espaceRepertory.SaveChangeAsync();
        }

        public Task MettreAjourEspaceAsync(Espace espace)
        {
            espaceRepertory.MettreAjourEspaceAsync(espace);
            return espaceRepertory.SaveChangeAsync();
        }

        public Task<Espace> ObtenirEspaceAsync(Guid espaceId)
        {
            var espace = espaceRepertory.ObtenirEspaceAsync(espaceId);
            return espace;
        }

        public Task<IEnumerable<Espace>> ObtenirTousLesEspaceAsync()
        {
            var espaces = espaceRepertory.ObtenirTousLesEspaceAsync();
            return espaces;
        }

        public async Task SaveChangeAsync()
        {
            await espaceRepertory.SaveChangeAsync();
        }

        public async Task SupprimerEspaceAsync(Guid espaceId)
        {
            await espaceRepertory.SupprimerEspaceAsync(espaceId);
            await SaveChangeAsync();
        }
    }
}
