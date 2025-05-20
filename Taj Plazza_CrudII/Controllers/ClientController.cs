using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taje__Plazza.Domain.Interface;

namespace Taj_Plazza_CrudII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices clientServices;

        public ClientController(IClientServices clientServices)
        {
            this.clientServices = clientServices;
        }

        [HttpGet("Obtenir Tous Les Clients")]
        public async Task<IActionResult> ObtenirTousLesClientsAsync()
        {
            try
            {
                var clients = await clientServices.ObtenirTousLesClientsAsync();
                return Ok(clients);
            } catch (Exception ex) { 
                throw new Exception("oof les donnees sont vides");
            }
           
        }
    }
}
