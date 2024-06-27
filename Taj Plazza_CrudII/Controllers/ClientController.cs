using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taj_Plazza.Core.DTOs.ClientDto;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza_CrudII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepertory repertory;
        private readonly IMapper mapper;

        public ClientController( IClientRepertory repertory,IMapper mapper)
        {
            this.repertory = repertory;
            this.mapper = mapper;
        }

        [HttpGet("Get Client")]
        public async Task<IActionResult> GetClientAll()
        {
            try
            {
                var clients = await repertory.GetAll();
                var clientDtos =  mapper.Map<IEnumerable<ReadClientDto>>(clients);
                return Ok(clientDtos);
            }
            catch (Exception ex)
            {
                // Gérez l'exception ici (par exemple, en renvoyant un code d'erreur approprié).
                return StatusCode(500, "Erreur lors de la récupération des clients.");
            }  
        }

        [HttpGet("{id}", Name = "GetClient")]
        public async Task<ActionResult<ReadClientDto>> GetClientById(int id)
        {
            var client = await repertory.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            var clientDto = mapper.Map<ReadClientDto>(client);

            return Ok(clientDto);
        }


        [HttpPost("AddClient")]
        public async Task<ActionResult<ReadClientDto>> AddClient(AddClientDto client)
        {
           // Vérifiez si le nom du client existe déjà dans la base de données

            var existingClient = await repertory.GetByName(client.NomComplete);
            if (existingClient != null)
            {
                // Le client existe déjà, vous pouvez renvoyer un message d'erreur approprié
                return BadRequest("Le client avec ce nom existe déjà.");
            }

            // Si le client n'existe pas, ajoutez-le à la base de données
            var clientModel = mapper.Map<Client>(client);
            await repertory.Create(clientModel);
            var clientReadDto = mapper.Map<ReadClientDto>(clientModel);
            return CreatedAtAction(nameof(GetClientById), new { id = clientReadDto.Id }, clientReadDto);
        }

        }
    }

