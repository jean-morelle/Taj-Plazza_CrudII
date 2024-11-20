using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;
using Taje__Plazza.Domain.Interface;

namespace Taje_Plazza.Application.Services
{
    public class ReservationServices :IReservationServices
    {
        private readonly IReservationRepertory reservationRepertory;

        public ReservationServices(IReservationRepertory reservationRepertory)
        {
            this.reservationRepertory = reservationRepertory;
        }

        public async Task AddReservation(Reservation reservation)
        {
            await reservationRepertory.AddReservation(reservation);
        }

        public async Task Delete(int reservationId)
        {
            await reservationRepertory.DeleteReservation(reservationId);
            
        }

        public async Task<Reservation> GetReservationById(int reservationId)
        {
            var reservation = await reservationRepertory.GetReservationById(reservationId);
            return reservation;
        }

        public async Task<List<Reservation>> GetReservations()
        {
           var reservation = await reservationRepertory.GetAllReservations();
            return reservation;
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            await reservationRepertory.UpdateReservation(reservation);
        }
    }
}
