using Taj_Plazza_CrudII.Models;

namespace Taj_Plazza_CrudII.Services
{
    public interface IclientServices
    {
        Task<IEnumerable<Client>> GetAll();

        Task<Client> GetById (int id);
    }
}
