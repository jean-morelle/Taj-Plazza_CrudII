using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Interface
{
    public interface IReservationServices
    {
        Task<IEnumerable<Reservation>> GetReservationsAsync(string? filter);
        Task<Reservation> GetReservationByIdAsync(int id);
        Task<IEnumerable<Categorie>> GetCategoriesAsync(string? filter);
        Task<Categorie> GetCategorieByReservationIdAsync(int reservationId);
    }
}
