using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Interface
{
    public interface IClientServices
    {
        Task<IEnumerable<Client>> GetAll();

        Task<Client> GetById(int clientId);

        Task<Client> GetByName(string name);

        Task Delete(int clientId);

        Task Create(Client client);

        Task Update(Client client);
    }
}
