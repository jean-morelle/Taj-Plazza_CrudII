using Taj_Plazza.Core.DTOs;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Repertory;

public class BookingRepository : IBookingRepository
{
    public Task<EvenementReserver> CreateBookingAsync(EvenementReserverToAddDto bookingAddDto)
    {
        throw new NotImplementedException();
    }

    public Task<EvenementReserver> UpdateNbrDePersonneAsync(Guid id, EvenementReserverNbrPersonUpdateDto patchDoc)
    {
        throw new NotImplementedException();
    }

    public Task<EvenementReserver> DeleteBookingAsync(Guid orderLineId)
    {
        throw new NotImplementedException();
    }

    public Task<EvenementReserver> GetBookingByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EvenementReserver>> GetBookingsReserverByClientIdAsync(Guid clientId)
    {
        throw new NotImplementedException();
    }

    public bool Save()
    {
        throw new NotImplementedException();
    }
}