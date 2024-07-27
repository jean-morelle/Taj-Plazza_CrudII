using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.DTOs;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Interface
{
    public interface IBookingServices
    {
        Task<EvenementReserver> CreateBookingAsync(EvenementReserverToAddDto bookingAddDto);
        Task<EvenementReserver> UpdateNbrDePersonneAsync(int id, EvenementReserverNbrPersonUpdateDto patchDoc);
        Task<EvenementReserver> DeleteBookingByIdAsync(int evenReserverId);
        Task<EvenementReserver> GetBookingByIdAsync(int id);
        Task<IEnumerable<EvenementReserver>> GetBookingsReserverByClientIdAsync(int clientId);
        bool Save();
    }
}
