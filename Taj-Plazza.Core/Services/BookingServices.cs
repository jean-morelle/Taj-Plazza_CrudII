using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.DTOs;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Services
{
    public class BookingServices :IBookingServices
    {
        private readonly IClientRepertory clientRepertory;
        private readonly IBookingRepository bookingRepository;

        public BookingServices(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public Task<EvenementReserver> CreateBookingAsync(EvenementReserverToAddDto bookingAddDto)
        {
            return bookingRepository.CreateBookingAsync(bookingAddDto);
        }

        public Task<EvenementReserver> DeleteBookingByIdAsync(int evenReserverId)
        {
            return bookingRepository.DeleteBookingByIdAsync(evenReserverId);
        }

        public Task<EvenementReserver> GetBookingByIdAsync(int id)
        {
            return bookingRepository.GetBookingByIdAsync(id);
        }

        public Task<IEnumerable<EvenementReserver>> GetBookingsReserverByClientIdAsync(int clientId)
        {
            return bookingRepository.GetBookingsReserverByClientIdAsync(clientId);
        }

        public bool Save()
        {
            return bookingRepository.Save();
        }

        public Task<EvenementReserver> UpdateNbrDePersonneAsync(int id, EvenementReserverNbrPersonUpdateDto patchDoc)
        {
            return bookingRepository.UpdateNbrDePersonneAsync(id, patchDoc);
        }
    }
}
