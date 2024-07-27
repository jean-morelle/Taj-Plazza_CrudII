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
    public async Task<EvenementReserver> CreateBookingAsync(EvenementReserverToAddDto bookingAddDto)
    {
        var evenementReserver = new EvenementReserver
        {
            EvenementId = bookingAddDto.EvenementId,
            ReservationId = bookingAddDto.ReservationId,
            NombreDePersonne = bookingAddDto.NombreDePersonne,
        };
        dbContext.EvenementReservers.Add(evenementReserver);
        await dbContext.SaveChangesAsync();
        return evenementReserver;
    }

    public async Task<EvenementReserver> UpdateNbrDePersonneAsync(int id, EvenementReserverNbrPersonUpdateDto patchDoc)
    {
        var evenementReserver = await dbContext.EvenementReservers.FindAsync(id);

        if(evenementReserver == null)
        {
            throw new KeyNotFoundException($"EvenementReserver with ID {id} not found.");
        }
        evenementReserver.NombreDePersonne = patchDoc.NombreDePersonne;
        await dbContext.SaveChangesAsync();
        return evenementReserver;
    }

    public async Task<EvenementReserver> DeleteBookingByIdAsync(int evenReserverId)
    {
        var evenReserver = await dbContext.EvenementReservers.FindAsync(evenReserverId);

        if (evenReserver != null)
        {

            dbContext.EvenementReservers.Remove(evenReserver);

            await dbContext.SaveChangesAsync();

        }
        else
        {
            throw new Exception("Not found !!!");
        }
        return null;
    }

     public async Task<EvenementReserver> GetBookingByIdAsync(int id)
    {
        var evenementReservation = await dbContext.EvenementReservers.FirstOrDefaultAsync(x=>x.Id ==id);
        return evenementReservation;
    }

    public async Task<IEnumerable<EvenementReserver>> GetBookingsReserverByClientIdAsync(int clientId)
    
    {
        // si je saisie l Id du client qui me sort les informations de la table d evenement et de reservation 

        //var evenement = await dbContext.Evenements.FirstOrDefaultAsync(evenement => evenement.ClientId == clientId);
        //if (evenement is not null)
        //{
        //    var eventReservation = await dbContext.EvenementReservers
        //        .Where(x => x.EvenementId == evenement.Id).Include(x => x.Reservation)
        //        .ToListAsync();
        //    return eventReservation;
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