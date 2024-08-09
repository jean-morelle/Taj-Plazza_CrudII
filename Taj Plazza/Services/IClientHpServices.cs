using Taj_Plazza.Core.DTOs;

namespace Taj_Plazza.Services
{
    public interface IClientHpServices
    {
        Task<IEnumerable<ReadClientDto>> GetAll();
    }
}
