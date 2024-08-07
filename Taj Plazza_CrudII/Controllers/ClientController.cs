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
        private readonly IClientServices services;
        private readonly IMapper mapper;

        public ClientController( IClientServices services, IMapper mapper)
        {
            this.services = services;
            this.mapper = mapper;
        }

        [HttpGet("api/client")]
        public async Task<IActionResult> GetClientAll()
        {
            try
            {
                var clients = await services.GetAll();
                var clientDtos =  mapper.Map<IEnumerable<ReadClientDto>>(clients);
                return Ok(clientDtos);
            }
            catch(Exception e)
            {
                // Gérez l'exception ici (par exemple, en renvoyant un code d'erreur approprié).
                return StatusCode(500, e.Message);
            }  
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadClientDto>> GetClientById(int id)
        {
            try
            {
                var client = await services.GetById(id);

                var clientDto = mapper.Map<ReadClientDto>(client);

                return Ok(clientDto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ReadClientDto>> AddClient(AddClientDto client)
        {
           // Vérifiez si le nom du client existe déjà dans la base de données

            var existingClient = await services.GetByName(client.NomComplete);
            if (existingClient != null)
            {
                // Le client existe déjà, vous pouvez renvoyer un message d'erreur approprié
                return BadRequest("Le client avec ce nom existe déjà.");
            }

            // Si le client n'existe pas, ajoutez-le à la base de données
            var clientModel = mapper.Map<Client>(client);

            await services.Create(clientModel);

            var clientReadDto = mapper.Map<ReadClientDto>(clientModel);

            return CreatedAtAction(nameof(GetClientById), new { id = clientReadDto.Id }, clientReadDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReadClientDto>> DeleteClientById(int id)
        {
            try
            {
                var client = await services.GetById(id);

                await services.Delete(client.Id);

                var clientDto = mapper.Map<ReadClientDto>(client);

                return Ok(clientDto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReadClientDto>> UpdateClientById(int id, UpdateClientDto updateClient)
        {
            try
            {
                if (id != updateClient.Id)
                {
                    BadRequest();
                }
                var client = mapper.Map<Client>(updateClient);

                await services.Update(client);

                var successClientUpdated = mapper.Map<ReadClientDto>(client);

                return Ok(successClientUpdated);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}


