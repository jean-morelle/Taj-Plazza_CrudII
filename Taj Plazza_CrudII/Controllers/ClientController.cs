using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taj_Plazza_CrudII.Interface;
using Taj_Plazza_CrudII.Models;

namespace Taj_Plazza_CrudII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepertory iclientRepertory;
        private readonly IMapper mapper;

        public ClientController(IClientRepertory iclientRepertory,IMapper mapper)
        {
            this.iclientRepertory = iclientRepertory;
            this.mapper = mapper;
        }

        [HttpGet("Required ClientAll")]

        public async Task<IActionResult> GetAll() {

            await Task.Delay(1000);
            var Getclients = await iclientRepertory.GetAll();
            return Ok(Getclients);
        
        }

        [HttpGet("Required CliendById")]

        public async Task<IActionResult>GetById(int clientId)
        {
            await Task.Delay(1000);
            var GetclientById = await iclientRepertory.GetById(clientId);

            if (GetclientById != null)
            {
                return Ok(GetclientById);
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpPost("Add-client")]
        public async Task<IActionResult> Create(Client newclient)
        {
            var clientModel = mapper.Map<Client>(newclient);
            try
            {
                var existingClient = await iclientRepertory.GetById(clientModel.Id);
                if (existingClient != null)
                {
                    return Conflict("Cet utilisateur avec le même nom existe");
                }
                else
                {
                    await iclientRepertory.Create(clientModel);
                    return CreatedAtAction(nameof(GetById), new { clienId = clientModel.Id }, clientModel);
                }
            }
            catch (Exception ex)
            {
                // Gérez l'exception ici (par exemple, journalisation ou renvoi d'une réponse d'erreur)
                return StatusCode(500, "Une erreur s'est produite lors de la création de l'utilisateur.");
            }
        }
        [HttpPatch ("Update client")]
        public async Task<IActionResult> Update(Client newclient) {

            var clientModel = mapper.Map<Client>(newclient);

            var existingClient = await iclientRepertory.GetById(clientModel.Id);

            if (existingClient == null)
            {
                return Conflict("Cet utilisateur avec le même nom existe");
            }

            existingClient.Id = clientModel.Id;
            existingClient.Nom = clientModel.Nom;
            existingClient.Prenom = clientModel.Prenom;
            existingClient.Num_Telephone = clientModel.Num_Telephone;
            existingClient.Domicile = clientModel.Domicile;
            existingClient.Reservations = clientModel.Reservations;

           await iclientRepertory.Update(clientModel);
           return Ok("L'utilisateur a été mis à jour avec succès.");
        }

        [HttpDelete ("Delete client")]

        public  async Task<IActionResult> Delete(int clientId)
        {
            var existingClient = await iclientRepertory.GetById(clientId);

            if(existingClient is null)
            {
                return NotFound();
            }

            else
            {
               await iclientRepertory.Delete(clientId);
                return NoContent();
            }
        }
    }
}
