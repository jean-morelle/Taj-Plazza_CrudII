using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;
using Taje__Plazza.Domain.Interface;

namespace Taje_Plazza.Application.Services
{
    public class EvenementServices :IEvenementServices
    {
        private readonly IEvenementRepertory evenementRepertory;

        public EvenementServices(IEvenementRepertory evenementRepertory)
        {
            this.evenementRepertory = evenementRepertory;
        }

        public async Task AddEvenementAsync(Evenement addEvenement)
        {
            await evenementRepertory.AddEvenementAsync(addEvenement);
        }

        public async Task DeleteEvenementAsync(int evenementId)
        {
          await evenementRepertory.DeleteEvenementAsync(evenementId);
        }

        public async Task<List<Evenement>> GetAllEvenementAsync()
        {
            var evenement = await evenementRepertory.GetAllEvenementAsync();
            return evenement;
        }

        public async Task<List<Evenement>> GetClientEvenementAsync(int clientId)
        {
            var evenement = await evenementRepertory.GetClientEvenementAsync(clientId);
            return evenement;
        }

        public async Task<Evenement> GetEvenementByIdAsync(int evenementId)
        {
            var evenement = await evenementRepertory.GetEvenementByIdAsync(evenementId);
            return evenement;
        }

        public async Task UpdateEvenementAsync(Evenement updateEvenement)
        {
            await evenementRepertory.UpdateEvenementAsync(updateEvenement);
        }
    }
}
