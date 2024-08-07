using System.Net.Http.Json;
using Taj_Plazza.Core.Models;
using Taj_Plazza.HtppInterface;

namespace Taj_Plazza.HttpServices
{
    public class ClientHttpServices : IClientHttpServices
    {
        private readonly HttpClient httpClient;

        public ClientHttpServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task Create(Client client)
        {
            throw new NotImplementedException();
        } 

        public Task Delete(int clientId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
    
                var client = await httpClient.GetFromJsonAsync<IEnumerable<Client>>("api/client/GetClientAll");
                return client;
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
