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
        Task AddClient(Client newClient);
        Task DeleteClient(int clientId);
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClient(int clientId);
        Task UpdateClient(int clientId, Client client);
    }
}
