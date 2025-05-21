using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        private readonly ApplicationDbContext applicationDbContext;

        public ClientRepertory(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AjouterClientAsync(Client client)
        {
           await applicationDbContext.Clients.AddAsync(client);
            await SaveChangeAsync();
        }

        public async Task ModifierClientAsync(Client client)
        {
            applicationDbContext.Clients.Update(client);
            await SaveChangeAsync();
        }

        public async Task<Client> ObtenirClientParIdAsync(Guid clientId)
        {
            var client = await applicationDbContext.Clients.FirstOrDefaultAsync(x=>x.Id ==clientId);
            if (client is null) throw new Exception($"Pardon cet{client} n existe pas dans notre Base de Donnee");
            else return client;
        }

        public async Task<Client> ObtenirClientParNomAsync(string nom)
        {
            var client = await applicationDbContext.Clients.FindAsync(nom);
            if (client is null) throw new Exception($"cet nom {client} n existe pas dans notre Base de donnee");
            else return client;
        }

        public async Task<IEnumerable<Client>> ObtenirTousLesClientsAsync()
        {
            var clients = await applicationDbContext.Clients.ToListAsync();
            if (clients is null) throw new Exception("oof les donnees sont vides");
            return clients;
        }

        public async Task SaveChangeAsync()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task SupprimerClientAsync(Guid id)
        {
            var client = await applicationDbContext.Clients.FirstOrDefaultAsync(x=>x.Id ==id);
            if (client is null) throw new Exception($"Cet nom {client} n existe pas dans notre Base de donnes");
            else applicationDbContext.Clients.Remove(client);
            await SaveChangeAsync();
        }
    }
}
