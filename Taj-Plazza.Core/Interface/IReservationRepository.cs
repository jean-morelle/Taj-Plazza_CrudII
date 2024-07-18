using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Interface
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetReservationsAsync(string? filter);
        Task<Reservation> GetReservationByIdAsync(int id);
        Task<IEnumerable<Categorie>> GetCategoriesAsync(string? filter);
        Task<Categorie> GetCategorieByReservationIdAsync(int reservationId);
    }
}
