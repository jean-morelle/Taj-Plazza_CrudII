
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Interface
{
    public interface IClientRepertory
    {
        Task<List<Client>> GetClients();

        Task<Client> GetClient(int clientId);

        Task DeleteClient(int clientId);

        Task AddClient(Client newClient);

        Task UpdateClient(Client updateClient);
    }
}
