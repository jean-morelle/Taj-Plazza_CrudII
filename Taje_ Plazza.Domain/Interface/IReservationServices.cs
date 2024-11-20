using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taje__Plazza.Domain.Interface
{
    public interface IReservationServices
    {
        Task<List<Reservation>> GetReservations();
        Task<Reservation> GetReservationById(int reservationId);

        Task Delete(int reservationId);

        Task AddReservation (Reservation reservation);

        Task UpdateReservation (Reservation reservation);
    }
}
