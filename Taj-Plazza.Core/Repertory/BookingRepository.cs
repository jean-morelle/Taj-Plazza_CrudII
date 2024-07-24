using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Taj_Plazza.Core.DataAcess;
using Taj_Plazza.Core.DTOs;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Repertory;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationDbContext dbContext;

    public BookingRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public Task<EvenementReserver> CreateBookingAsync(EvenementReserverToAddDto bookingAddDto)
    {
        throw new NotImplementedException();
    }

    public Task<EvenementReserver> UpdateNbrDePersonneAsync(int id, EvenementReserverNbrPersonUpdateDto patchDoc)
    {
        throw new NotImplementedException();
    }

    public async Task<EvenementReserver> DeleteBookingByIdAsync(int evenReserverId)
    {
    //    var evenReserver = await dbContext.EvenementReservers.FindAsync(evenReserverId);

    //    if (evenReserver != null)
    //    {

    //        dbContext.EvenementReservers.Remove(evenReserver);

    //        await dbContext.SaveChangesAsync();

    //    }
    //    else
    //    {
    //        throw new Exception();
    //    }
     throw new NotImplementedException();
}

public async Task<EvenementReserver> GetBookingByIdAsync(int id)
    {
        return await dbContext.EvenementReservers.FindAsync(id);
    }

    public async Task<IEnumerable<EvenementReserver>> GetBookingsReserverByClientIdAsync(int clientId)
    
    {
        // si je saisie l Id du client qui me sort les informations de la table d evenement et de reservation 

        //var inputClientId = dbContext.Evenements.FirstOrDefaultAsync(evenement => evenement.ClientId == clientId);
        //if (inputClientId is not null)
        //{

        //     return  await dbContext.EvenementReservers.ToListAsync();
        //}

        //else
        //{
        //    return Enumerable.Empty<EvenementReserver>();
        //};
        // A la fin returne moi la liste des evenementReserver
        var evenReserverList = await (
        from evenement in dbContext.Evenements
        join evenementReserver in dbContext.EvenementReservers
        on evenement.Id equals evenementReserver.EvenementId
        where evenement.ClientId == clientId
        select new EvenementReserver()
        {
            EvenementId = evenement.Id,
            ReservationId = evenementReserver.ReservationId,
            NombreDePersonne = evenementReserver.NombreDePersonne,
            Id = evenementReserver.Id,
        }).ToListAsync();
        return evenReserverList;

    }

    public bool Save()
    { 
        dbContext.SaveChanges();
        return true;
    }
}