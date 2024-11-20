using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.DataAcess;
using Taj_Plazza.Core.Models;
using Taje__Plazza.Domain.Interface;

namespace Taje_Plazza.Infrastructure.Repertory
{
    public class ReservationRepertory :IReservationRepertory
    {
        private readonly ApplicationDbContext dbContext;

        public ReservationRepertory(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddReservation(Reservation addReservation)
        {
           dbContext.Reservations.Add(addReservation);
           await dbContext.SaveChangesAsync();
        }

        public async Task DeleteReservation(int reservationId)
        {
            var reservation = await dbContext.Reservations.FindAsync(reservationId);

            if(reservation != null)
            {
                dbContext.Reservations.Remove(reservation);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
            
        }

        public async Task<List<Reservation>> GetAllReservations()
        {
            var reservation = await dbContext.Reservations.ToListAsync();
            return reservation;
        }

        public async Task<Reservation> GetReservationById(int reservationId)
        {
            var reservation = await dbContext.Reservations.FirstOrDefaultAsync(reservation =>reservation.Id ==reservationId);
            return reservation;
        }

        public async Task UpdateReservation(Reservation updateReservation)
        {
           dbContext.Reservations.Update(updateReservation);
           await dbContext.SaveChangesAsync();
           
        }
    }
}
