using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taje__Plazza.Domain.Interface;
using Taje_Plazza.Application.Services;

namespace Taj_Plazza_CrudII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvenementController : ControllerBase
    {
        private readonly IEvenementServices evenementServices;

        public EvenementController(IEvenementServices evenementServices)
        {
            this.evenementServices = evenementServices;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {

            var evenement = await evenementServices.GetAllEvenementAsync();
            return Ok(evenement);
        }

        [HttpGet("All")]

        public async Task<IActionResult> GetEvenementByClientId(int clientId)
        {
            var evenements = await evenementServices.GetClientEvenementAsync(clientId);

            if (evenements == null || evenements.Count == 0)
            {
                return NotFound();
            }
            return Ok(evenements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvenement(int id)
        {
            var evenement = await evenementServices.GetEvenementByIdAsync(id);
            if (evenement == null)
            {
                return NotFound();
            }
            return Ok(evenement);
        }


    }
}
