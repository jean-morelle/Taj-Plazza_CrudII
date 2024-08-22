using Taj_Plazza.Core.Models;

namespace Taj_Plazza.HTTPCLient
{
    public interface IClientHttpClient
    {
        Task<IEnumerable<Client>> GetClients();
    }
}
