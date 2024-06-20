using Taj_Plazza_CrudII.Models;

namespace Taj_Plazza_CrudII.Interface
{
    public interface IclientRepertory
    {
        Task<IEnumerable<Client>> GetAll();

        Task<Client> GetById(int clientId);

        Task Delete(int clientId);

        Task Create(Client client);

        Task Update(Client client);

    }
}
