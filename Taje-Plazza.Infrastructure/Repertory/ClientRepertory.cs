using Microsoft.EntityFrameworkCore;
using Taj_Plazza.Core.DataAcess;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Repertory
{
    public class ClientRepertory : IClientRepertory
    {
        private readonly ApplicationDbContext dbContext;

        public ClientRepertory(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddClient(Client newClient)
        {
            dbContext.Clients.Add(newClient);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteClient(int clientId)
        {
            var client = await dbContext.Clients.FindAsync(clientId);

            if (client != null)
            {
                dbContext.Clients.Remove(client);
                await  dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("client not found");
            }
        }

        public async Task<List<Client>> GetClients()
        {
            return await dbContext.Clients.ToListAsync();
        }

        public async Task<Client> GetClient(int clientId)
        {
            var client = await dbContext.Clients.FindAsync(clientId);

            if (client != null)
            {
                return client;
            }

            throw new Exception("client not found!");
        }


        public async Task UpdateClient(Client updateClient)
        {
            dbContext.Clients.Update(updateClient);
            await dbContext.SaveChangesAsync();
        }

    }

}
