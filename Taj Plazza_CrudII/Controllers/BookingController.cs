using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Taj_Plazza.Core.DTOs;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza_CrudII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingServices bookingServices;
        private readonly IMapper mapper1;

        public BookingController( IBookingServices bookingServices,IMapper mapper1)
        {
            this.bookingServices = bookingServices;
            this.mapper1 = mapper1;
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
        public async Task<IActionResult>Create(EvenementReserverToAddDto reserverToAddDto)
        {
            var evenReservationModel = mapper1.Map<EvenementReserver>(reserverToAddDto);
            // Validation des d onnées entrantes
            if (!ModelState.IsValid)
            {
                
                return BadRequest(ModelState);
            }

            try
            {
               
                var evenReservation = bookingServices.GetBookingByIdAsync(evenReservationModel.Id);
                if (evenReservation != null)
                {
                    
                    return Conflict("Un evenReservation avec ce nom  existe déjà.");
                }


                  await  bookingServices.CreateBookingAsync(reserverToAddDto);
                        bookingServices.Save();
               
                return CreatedAtAction(nameof(GetAllBookings), new { id = evenReservationModel.Id }, evenReservationModel);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"Une erreur s'est produite lors de la création : {ex.Message}");
            }
        }

    }
}
    
