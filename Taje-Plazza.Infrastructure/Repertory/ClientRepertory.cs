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
    public class ClientRepertory:IClientRepertory
    {
        private readonly IClientRepertory clientRepertory;
        private readonly ApplicationDbContext applicationDbContext;

        public ClientRepertory(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AjouterClientAsync(Client client)
        {
            applicationDbContext.Clients.Add(client);
            await SaveChangeAsync();

        }

        public async Task ModifierClientAsync(Client client)
        {
            applicationDbContext.Clients.Update(client);
            await SaveChangeAsync();
        }

        public async Task<Client> ObtenirClientParEmailAsync(string email)
        {
            var client = await applicationDbContext.Clients.FindAsync(email);
            return client ?? throw new KeyNotFoundException($"Client with email {email} not found.");

        }

        public async Task<Client> ObtenirClientParIdAsync(Guid clientId)
        {
           var client = await applicationDbContext.Clients.FindAsync(clientId);
            return client ?? throw new KeyNotFoundException($"Client with ID {clientId} not found.");
        }

        public async Task<Client> ObtenirClientParNomAsync(string nom)
        {
            var client = await applicationDbContext.Clients.FindAsync(nom);
            return client ?? throw new KeyNotFoundException($"Client with name {nom} not found.");

        }

        public async Task<IEnumerable<Client>> ObtenirTousLesClientsAsync()
        {
            var clients = await applicationDbContext.Clients.ToListAsync();
            return clients ?? throw new KeyNotFoundException("No clients found.");
        }

        public async Task SaveChangeAsync()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task SupprimerClientAsync(Guid clientId)
        {
            var client = await applicationDbContext.Clients.FindAsync(clientId);
            if (client == null)
            {
                throw new KeyNotFoundException($"Client with ID {clientId} not found.");
            }
            applicationDbContext.Clients.Remove(client);
            await SaveChangeAsync();
        }
    }
}
