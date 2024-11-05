using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Interface;

public interface IClientServices
{
    Task AddClient(Client newClient);
    Task DeleteClient(int clientId);
    Task<IEnumerable<Client>> GetClients();
    Task<Client> GetClient(int clientId);
    Task UpdateClient(Client updateClient);
}