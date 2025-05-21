using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taj_Plazza_CrudII.Extention;
using Taje__Plazza.Domain.Interface;
using Taje_Plazza.Application.Automapper.DTOs;

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
            var clients = await clientServices.ObtenirTousLesClientsAsync();
            var clientDto = clients.ConvertTodto();
            return Ok(clientDto);
        }
        [HttpGet("Obtenir Le client Par Son {id}")]
        public async Task<ActionResult<ClientReadDto>>ObtenirClientParId(Guid id)
        {
            var client = await clientServices.ObtenirClientParIdAsync(id);
            if (client == null)
                return NotFound();

            return Ok(client); 
        }
        [HttpPost("Ajouter un nouveau client")]
        public async Task<ActionResult> Create(AddClientDto dto)
        {
            var client = dto.ConvertToEntity(); // <== Appel à ton extension
            await clientServices.AjouterClientAsync(client);
            return CreatedAtAction(nameof(ObtenirClientParId), new { id = client.Id }, client);
        }
     
        [HttpPut("Mettre Ajours un client par Son {id}")]
        public async Task<ActionResult> Update(Guid id, UpdateClientDto dto)
        {
            var client = await clientServices.ObtenirClientParIdAsync(id);
            if (client == null)
                return NotFound();

            client.UpdateFromDto(dto); // <== Appel à ton extension
            await clientServices.ModifierClientAsync(client);
            return NoContent();
        }
        [HttpDelete(" Supprimer le client par Son{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var client = await clientServices.ObtenirClientParIdAsync(id);
            if (client == null)
                return NotFound(); 

            await clientServices.SupprimerClientAsync(id); 
            return NoContent();
        }

    }
}
