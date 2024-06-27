using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Interface;

public interface IClientServices
{
    Task Create(Client client);
    Task Delete(int clientId);
    Task<IEnumerable<Client>> GetAll();
    Task<Client> GetById(int clientId);
    Task Update(Client client);
    Task<Client> GetByName(string name);
}