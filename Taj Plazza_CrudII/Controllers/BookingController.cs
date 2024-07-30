 using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Taj_Plazza.Core.DTOs;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;
using Taj_Plazza.Core.Services;

namespace Taj_Plazza_CrudII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingServices bookingServices;
        private readonly IMapper mapper;

        public BookingController( IBookingServices bookingServices, IMapper mapper)
        {
            this.bookingServices = bookingServices;
            this.mapper = mapper;
        }

        [HttpGet()]
        [Route("{clientId}/GetAllBooking")]
        public async Task<IActionResult> GetAllBookings(int clientId)
        {
            try
            {
                var booking = await bookingServices.GetBookingsReserverByClientIdAsync(clientId);

                if(booking is null)
                {
                    return NotFound("No bookings found for the specified client");
                }
                else
                {
                    return Ok(booking);
                }
            }
            catch(Exception )
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetBookingById(int id)
        {
            try
            {
                var evenReservation = await bookingServices.GetBookingByIdAsync(id);

                if(evenReservation is null)
                {
                    return NotFound("No booking found for the specified client");
                }
                else
                {
                    return Ok(evenReservation);
                }
            }
            catch(Exception)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create( EvenementReserverToAddDto bookingToAddDto)
        {
            if (bookingToAddDto == null)
            {
                return BadRequest("Les données de réservation sont nulles.");
            }

            try
            {
               
                // Appeler un service pour enregistrer la réservation
             var evenBooking =   await bookingServices.CreateBookingAsync(bookingToAddDto);

                return Ok(evenBooking);
            }
            catch (AutoMapperMappingException ex)
            {
                // Gestion des erreurs spécifiques au mappage
                return BadRequest($"Erreur de mappage: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Gestion des erreurs générales
                return StatusCode(500, $"Erreur interne du serveur : {ex.Message}");
            }
        }

    }
}
    
