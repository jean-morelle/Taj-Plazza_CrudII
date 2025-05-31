using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Interface;
using Taje__Plazza.Domain.Models;

namespace Taje_Plazza.Application.Services
{
    public class FactureServices : IFactureServices
    {
        private readonly IFactureRepertory factureRepertory;

        public FactureServices(IFactureRepertory factureRepertory)
        {
            this.factureRepertory = factureRepertory;
        }

        public async Task AjouterFactureAsync(Facture facture)
        {
            await factureRepertory.AjouterFactureAsync(facture);
        }

        public async Task MettreAJourFactureAsync(Facture facture)
        {
            await factureRepertory.MettreAJourFactureAsync(facture);
        }

        public Task<Facture> ObtenirFactureParIdAsync(Guid id)
        {
            var facture = factureRepertory.ObtenirFactureParIdAsync(id);
            return facture;
        }

        public async Task<IEnumerable<Facture>> ObtenirTousLesFacturesAsync()
        {
            var facture = await factureRepertory.ObtenirTousLesFacturesAsync();
            return facture;
        }

        public async Task SupprimerFactureAsync(Guid id)
        {
            await factureRepertory.SupprimerFactureAsync(id);
        }
    }
}
