
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Interface
{
    public interface IClientRepertory
    {
        Task<IEnumerable<Client>> GetAll();

        Task<Client> GetById(int clientId);

        Task Delete(int clientId);

        Task Create(Client client);

        Task Update(Client client);
    }
}
