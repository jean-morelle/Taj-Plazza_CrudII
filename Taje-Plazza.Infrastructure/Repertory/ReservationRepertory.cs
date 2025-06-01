using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taj_Plazza.Core.DataAcess;
using Taje__Plazza.Domain.Interface;
using Taje__Plazza.Domain.Models;

namespace Taje_Plazza.Infrastructure.Repertory
{
    public class ReservationRepertory : IReservationRepertory
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ReservationRepertory(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
            applicationDbContext.Reservations.Add(reservation);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(Guid id)
        {
            var reservation = await applicationDbContext.Reservations.FindAsync(id);
            if (reservation != null)
            {
                applicationDbContext.Reservations.Remove(reservation);
                await applicationDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Reservation not found.");
            }
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            var reservations = await applicationDbContext.Reservations.ToListAsync();
            if (reservations == null || !reservations.Any())
            {
                throw new KeyNotFoundException("No reservations found.");
            }
            return reservations;
        }

        public async Task<Reservation> GetReservationByClientNameAsync(string clientName)
        {
            var reservationByClientName = await applicationDbContext.Reservations
                .Include(r => r.Client)
                .FirstOrDefaultAsync(r =>
                    r.Client.FirstName.Contains(clientName, StringComparison.OrdinalIgnoreCase) ||
                    r.Client.LastName.Contains(clientName, StringComparison.OrdinalIgnoreCase));

            return reservationByClientName ?? throw new KeyNotFoundException($"Reservation not found for client name: {clientName}");
        }

        public async Task<Reservation> GetReservationByIdAsync(Guid id)
        {
            var reservation = await applicationDbContext.Reservations.FindAsync(id);
            if (reservation == null)
            {
                throw new KeyNotFoundException("Reservation not found.");
            }
            return reservation;
        }

        public Task<Reservation> GetTeservationByDateAsync(DateTime date)
        {
            var reservation = applicationDbContext.Reservations
                .FirstOrDefaultAsync(r => r.ReservationDate.Date == date.Date);
            return reservation ?? throw new KeyNotFoundException("Reservation not found for the specified date.");
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            applicationDbContext.Reservations.Update(reservation);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
