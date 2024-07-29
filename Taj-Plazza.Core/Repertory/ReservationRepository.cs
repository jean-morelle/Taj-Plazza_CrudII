using Microsoft.EntityFrameworkCore;
using Taj_Plazza.Core.DataAcess;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Repertory;

public class ReservationRepository : IReservationRepository
{
    private readonly ApplicationDbContext dbContext;

    public ReservationRepository( ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IEnumerable<Reservation>> GetReservationsAsync(string? filter)
    {
        // Commence par récupérer toutes les réservations
        IQueryable<Reservation> query = dbContext.Reservations;

        // Applique le filtre si spécifié
        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(r => r.AccessoireAjouter.Contains(filter));
                                   
        }

        // Exécute la requête de manière asynchrone et retourne les résultats
        return await query.ToListAsync();
    }

    public async Task<Reservation> GetReservationByIdAsync(int id)
    {
        var reservation = await dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == id);

        return reservation;
    }

    public async Task<IEnumerable<Categorie>> GetCategoriesAsync(string? filter)
    {
        IQueryable<Categorie> query =  dbContext.Categories;

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(c => c.NomCategorie.Contains(filter));
        }

        return await query.ToListAsync();
            
            
    }

    public async Task<Categorie> GetCategorieByReservationIdAsync(int reservationId)
    {
        var reservation = await dbContext.Reservations
            .Include(x => x.Categorie)
            .FirstOrDefaultAsync(r => r.Id == reservationId);
        //if (reservation == null)
        //{
        //    // Gérer le cas où la réservation n'est pas trouvée
        //    throw new KeyNotFoundException($"Reservation with ID {reservationId} not found.");
        //}

        return reservation.Categorie;
    }
}