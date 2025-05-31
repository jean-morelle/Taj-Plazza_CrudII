using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Interface;
using Taje__Plazza.Domain.Models;

namespace Taje_Plazza.Application.Services
{
    public class ClientServices:IClientServices
    {
        private readonly IClientRepertory clientRepertory;

        public ClientServices(IClientRepertory clientRepertory)
        {
            this.clientRepertory = clientRepertory;
        }

        public async Task AjouterClientAsync(Client client)
        {
            await clientRepertory.AjouterClientAsync(client);
            await clientRepertory.SaveChangeAsync();
        }

        public async Task ModifierClientAsync(Client client)
        {
            await clientRepertory.ModifierClientAsync(client);
            await clientRepertory.SaveChangeAsync();
        }

        public async Task<Client> ObtenirClientParEmailAsync(string email)
        {
            var client = await clientRepertory.ObtenirClientParEmailAsync(email);
            return client ?? throw new KeyNotFoundException($"Client with email {email} not found.");
        }

        public async Task<Client> ObtenirClientParIdAsync(Guid clientId)
        {
            var client = await clientRepertory.ObtenirClientParIdAsync(clientId);
            return client ?? throw new KeyNotFoundException($"Client with ID {clientId} not found.");
        }

        public async Task<Client> ObtenirClientParNomAsync(string nom)
        {
            var client = await clientRepertory.ObtenirClientParNomAsync(nom);
            return client ?? throw new KeyNotFoundException($"Client with name {nom} not found.");
        }

        public async Task<IEnumerable<Client>> ObtenirTousLesClientsAsync()
        {
            var clients = await clientRepertory.ObtenirTousLesClientsAsync();
            return clients ?? throw new KeyNotFoundException("No clients found.");
        }

        public async Task SaveChangeAsync()
        {
            await clientRepertory.SaveChangeAsync();
        }

        public async Task SupprimerClientAsync(Guid clientId)
        {
            await clientRepertory.SupprimerClientAsync(clientId);
            await clientRepertory.SaveChangeAsync();
        }
    }
}
