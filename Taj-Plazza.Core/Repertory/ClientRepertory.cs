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

        public async Task Create(Client client)
        {
            dbContext.Clients.Add(client);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int clientId)
        {
            var removeOfclient = await dbContext.Clients.FindAsync(clientId);

            if (removeOfclient != null)
            {
                dbContext.Clients.Remove(removeOfclient);
                await  dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("client not found");
            }
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await dbContext.Clients.ToListAsync();
        }

        public async Task<Client> GetById(int clientId)
        {
            return await dbContext.Clients.FindAsync(clientId);
        }

        public async Task<Client> GetByName(string name)
        {
            return await dbContext.Clients.FirstOrDefaultAsync(c => c.NomComplete == name);
        }

        public async Task Update(Client client)
        {
            dbContext.Clients.Update(client);
            await dbContext.SaveChangesAsync();
        }

    }

}
