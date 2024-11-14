using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IClientRepertory clientRepertory;

        public ClientServices(IClientRepertory clientRepertory)
        {
            this.clientRepertory = clientRepertory;
        }

        public async Task AddClient(Client newClient)
        {
            await  clientRepertory.AddClient(newClient);
        }

        public async Task DeleteClient(int clientId)
        {
           await  clientRepertory.DeleteClient(clientId);
        }

        public Task<List<Client>> GetClients()
        {
           return this.clientRepertory.GetClients();
        }

        public Task<Client> GetClient(int clientId)
        {
            var client = clientRepertory.GetClient(clientId);
            return client;
        }

        public async Task UpdateClient(Client client)
        {
           await clientRepertory.UpdateClient(client);
            
        }
    }
}
