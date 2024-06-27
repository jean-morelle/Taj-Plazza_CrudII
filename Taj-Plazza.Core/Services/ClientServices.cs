using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Services
{
    public class ClientServices: IClientRepertory
    {
        private readonly IClientRepertory clientRepertory;

        public ClientServices(IClientRepertory clientRepertory)
        {
            this.clientRepertory = clientRepertory;
        }

        public Task Create(Client client)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetAll()
        {
           return this.clientRepertory.GetAll();
        }

        public Task<Client> GetById(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
