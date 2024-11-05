using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taj_Plazza.Core.DTOs;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza_CrudII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices clientServices;
        private readonly IMapper mapper;

        public ClientController(IClientServices clientServices, IMapper mapper)
        {
            this.clientServices = clientServices;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            try
            {
                var client = await clientServices.GetClients();

                return Ok(client);
            }
            catch
            {
                // Gérez l'exception ici (par exemple, en renvoyant un code d'erreur approprié).
                return StatusCode(500, "Erreur lors de la récupération des clients.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await clientServices.GetClient(id);

            return Ok(client);
        }


        [HttpPost]
        public async Task<ActionResult<Client>> AddClient(ClientDto clientDto)
        {
            var client = mapper.Map<Client>(clientDto);

            await clientServices.AddClient(client);


            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, ClientDto clientDto)
        {
            var client = await clientServices.GetClient(id);

            if (client == null)
            {
                return NotFound("Client not found.");
            }

            // Map the incoming DTO to the existing client entity
            mapper.Map(clientDto, client);

            await clientServices.UpdateClient(client);

            return Ok("Mise à jour avec succès.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await clientServices.GetClient(id);

            if (client == null)
            {
                return NotFound("Client not found.");
            }

            await clientServices.DeleteClient(id);

            return NoContent();
        }


    }
}



