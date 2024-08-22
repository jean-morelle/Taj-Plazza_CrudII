using System.Net.Http.Json;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.HTTPCLient
{
    public class ClientHttpClient : IClientHttpClient
    {
        private readonly HttpClient httpClient;

        public ClientHttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Client>>("https://localhost:7145");
        }
    }
}
