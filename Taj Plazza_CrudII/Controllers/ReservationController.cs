using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Repertory;

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
    }
}
