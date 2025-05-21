using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Interface;
using Taje__Plazza.Domain.Models;

namespace Taje_Plazza.Application.Services
{
    public class EvenementServices:IEvenementServices
    {
        private readonly IEvenementRepertory evenementRepertory;

        public EvenementServices(IEvenementRepertory evenementRepertory)
        {
            this.evenementRepertory = evenementRepertory;
        }

        public async Task AjouterEvenementAsync(Evenement evenement)
        {
            await evenementRepertory.AjouterEvenementAsync(evenement);
            await SaveChangeAsync();
        }

        public async Task MettreAjoursEvenementAsync(Evenement evenement)
        {
           await evenementRepertory.MettreAjoursEvenementAsync (evenement);
            await SaveChangeAsync();
        }

        public async Task<Evenement> ObtenirEvenementParIdAsync(Guid evenementId)
        {
            var evenement = await evenementRepertory.ObtenirEvenementParIdAsync(evenementId);
            return evenement;
        }

        public async Task<IEnumerable<Evenement>> ObtenirTousLesEvenementAsync()
        {
            var evenements = await evenementRepertory.ObtenirTousLesEvenementAsync();
            return evenements;
        }

        public async Task SaveChangeAsync()
        {
            await evenementRepertory.SaveChangeAsync();
        }

        public async Task SupprimerEvenementAsync(Guid evenementId)
        {
            await evenementRepertory.SupprimerEvenementAsync(evenementId);
            await SaveChangeAsync();
        }
    }
}
