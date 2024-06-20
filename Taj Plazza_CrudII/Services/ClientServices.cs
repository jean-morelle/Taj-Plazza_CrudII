using Taj_Plazza_CrudII.Models;

namespace Taj_Plazza_CrudII.Services
{
    public class ClientServices :IclientServices
    {
        private readonly IclientServices iclientServices;

        public ClientServices( IclientServices iclientServices)
        {
            this.iclientServices = iclientServices;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await iclientServices.GetAll();
        }

        public async Task<Client> GetById(int id)
        {
            return await iclientServices.GetById(id);
        }
    }
}
