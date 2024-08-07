using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.DataAcess;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Services
{
    public class ReservationServices : IReservationServices
    {
        private readonly IReservationRepository reservationRepository;

        public ReservationServices(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public Task<Categorie> GetCategorieByIdAsync(int reservationId)
        {
          return  reservationRepository.GetCategorieByIdAsync(reservationId);
        }

        public Task<IEnumerable<Categorie>> GetCategoriesAsync(string? filter)
        {
            return reservationRepository.GetCategoriesAsync(filter);
        }

        public Task<Reservation> GetReservationByIdAsync(int id)
        {
            return reservationRepository.GetReservationByIdAsync(id);
        }

        public Task<IEnumerable<Reservation>> GetReservationsAsync(string? filter)
        {
            return reservationRepository.GetReservationsAsync(filter);
        }
    }
}
