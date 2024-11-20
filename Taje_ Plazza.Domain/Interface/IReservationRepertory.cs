using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taje__Plazza.Domain.Interface
{
    public  interface IReservationRepertory
    {
        Task<Reservation> GetReservationById(int reservationId);
        Task<List<Reservation>> GetAllReservations();   

        Task AddReservation(Reservation addReservation);

        Task UpdateReservation(Reservation updateReservation);

        Task DeleteReservation(int reservationId);
    }
}
