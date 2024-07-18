using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Repertory;

public class ReservationRepository : IReservationRepository
{
    public Task<IEnumerable<Reservation>> GetReservationsAsync(string? filter)
    {
        throw new NotImplementedException();
    }

    public Task<Reservation> GetReservationByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Categorie>> GetCategoriesAsync(string? filter)
    {
        throw new NotImplementedException();
    }

    public Task<Categorie> GetCategorieByReservationIdAsync(int reservationId)
    {
        throw new NotImplementedException();
    }
}