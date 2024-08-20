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

        public async Task Create(Client client)
        {
            await  clientRepertory.Create(client);
        }

        public async Task Delete(int clientId)
        {
           await  clientRepertory.Delete(clientId);
        }

        public Task<IEnumerable<Client>> GetAll()
        {
           return this.clientRepertory.GetAll();
        }

        public Task<Client> GetById(int clientId)
        {
            var client = clientRepertory.GetById(clientId);
            return client;
        }

        public async Task Update(Client client)
        {
           await clientRepertory.Update(client);
            
        }
    }
}
