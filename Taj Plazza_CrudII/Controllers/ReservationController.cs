using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;
using Taj_Plazza.Core.Repertory;
using Taj_Plazza.Core.Services;

namespace Taj_Plazza_CrudII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationServices reservationServices;

        public ReservationController(IReservationServices reservationServices)
        {
            this.reservationServices = reservationServices;
        }

        [HttpGet]

        public async Task<IActionResult> GetCategories(string? filter)
        {
            var categories = await reservationServices.GetCategoriesAsync(filter);

            if (categories == null || !categories.Any())
            {
                return NotFound("Aucune catégorie trouvée.");
            }

            return Ok(categories);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult>GetCategoryById(int id)
        //{
        //    var categorie = await reservationServices.GetCategorieByIdAsync(id);
        //    return Ok(categorie);
        //}

        [HttpGet("{id}")]

        public async Task<IActionResult>GetReservationById(int id)
        {
            var reservation = await reservationServices.GetReservationByIdAsync(id);

            if(reservation is null)
            {
                return NotFound("Aucune reservation trouvée");
            }
            else
            {
                return Ok(reservation);
            }
        }
        [HttpGet]
        [Route("GetReservation")]
        public async Task<IActionResult> GetReservation(string? filter)
        {
            var reservation = await reservationServices.GetReservationsAsync(filter);

            if (reservation == null || !reservation.Any())
            {
                return NotFound("Aucune reservation trouvée.");
            }

            return Ok(reservation);
        }

    }
}
