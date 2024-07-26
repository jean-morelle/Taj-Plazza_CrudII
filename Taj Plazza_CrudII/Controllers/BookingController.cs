using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza_CrudII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository booking;

        public BookingController(IBookingRepository booking)
        {
            this.booking = booking;
        }

        //[HttpGet("{clientId}")]
        //public async Task<IActionResult> Get(int clientId)
        //{

        //    var bookings = await booking.GetBookingsReserverByClientIdAsync(clientId);


        //    // Retourner la liste des réservations trouvées avec un code 200 OK
        //    return Ok(bookings);


        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mm = await booking.GetBookingByIdAsync(id);
            return Ok(mm);
        }

    }
}
