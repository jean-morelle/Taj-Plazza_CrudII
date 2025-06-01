using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;

namespace Taje__Plazza.Domain.Interface
{
    internal interface IReservationServices
    {
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(Guid id);
        Task AddReservationAsync(Reservation reservation);
        Task UpdateReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(Guid id);
        Task<Reservation> GetReservationByDateAsync(DateTime date);
    }
}
