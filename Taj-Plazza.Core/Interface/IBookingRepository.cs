using Taj_Plazza.Core.DTOs;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Interface
{
    public interface IBookingRepository
    {
        Task<EvenementReserver> CreateBookingAsync(EvenementReserverToAddDto bookingAddDto);
        Task<EvenementReserver> UpdateNbrDePersonneAsync(Guid id, EvenementReserverNbrPersonUpdateDto patchDoc);
        Task<EvenementReserver> DeleteBookingAsync(Guid orderLineId);
        Task<EvenementReserver> GetBookingByIdAsync(Guid id);
        Task<IEnumerable<EvenementReserver>> GetBookingsReserverByClientIdAsync(Guid clientId);
        bool Save();
    }
}
