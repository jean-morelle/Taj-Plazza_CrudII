using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Interfaces
{
    public interface IclientServicesCore
    {
        Task AddClientAsync(Client newClient);
        Task DeleteClientAsync(int clientId);
        Task<List<Client>> GetClientsAsync();
        Task<Client> GetClientAsync(int clientId);
        Task UpdateClientAsync( Client client);
    }
}
