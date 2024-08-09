using System.Net.Http.Json;
using Taj_Plazza.Core.DTOs;

namespace Taj_Plazza.Services
{
    public class ClientHpServices : IClientHpServices
    {
        private readonly HttpClient httpClient;

        public ClientHpServices( HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        async Task<IEnumerable<ReadClientDto>> IClientHpServices.GetAll()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<ReadClientDto>>("api/GetClient");
        }
    }
}
