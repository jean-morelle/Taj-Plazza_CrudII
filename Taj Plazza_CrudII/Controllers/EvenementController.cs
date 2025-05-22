using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taj_Plazza_CrudII.Extention;
using Taje__Plazza.Domain.Interface;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Application.Automapper.DTOs;
using Taje_Plazza.Application.Services;

namespace Taj_Plazza_CrudII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvenementController : ControllerBase
    {
        private readonly IEvenementServices evenementServices;
        private readonly IClientServices clientServices;
        private readonly IEspaceServices espaceServices;

        public EvenementController(IEvenementServices  evenementServices,IClientServices clientServices,IEspaceServices espaceServices)
        {
            this.evenementServices = evenementServices;
            this.clientServices = clientServices;
            this.espaceServices = espaceServices;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenirTousLesEvenements()
        {
            var evenements = await evenementServices.ObtenirTousLesEvenementAsync();
            var clients = await clientServices.ObtenirTousLesClientsAsync();
            var espaces = await espaceServices.ObtenirTousLesEspaceAsync();

            var evenementDto = evenements.ConvertToDto(clients,espaces); 
            return Ok(evenementDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenirEvenementParId(Guid evenementId)
        {
            var evenement = await evenementServices.ObtenirEvenementParIdAsync(evenementId);
            return evenement == null ? Ok(null) : Ok(evenement);
        }
        [HttpPost]
        public async Task<IActionResult> AjouterEvenement(AddEvenementDto evenementDto)
        {
            var evenement = evenementDto.ConvertToEntity();
            await evenementServices.AjouterEvenementAsync(evenement);
            return CreatedAtAction(nameof(ObtenirEvenementParId),new {id =evenement.Id},evenement);
        }
        [HttpDelete]
        public async Task<IActionResult> SupprimerEvenement(Guid evenementId)
        {
            var evenement = await evenementServices.ObtenirEvenementParIdAsync(evenementId);
            if (evenement == null) NotFound();
            else await evenementServices.SupprimerEvenementAsync(evenementId);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>MettreAjoursEvenement(Guid evenementId,UpdateEvenementDto updateEvenementDto)
        {
            var evenement = await evenementServices.ObtenirEvenementParIdAsync(evenementId);
            if( evenement == null ) NotFound();
             evenement.UpdateFromDto(updateEvenementDto);
            await evenementServices.MettreAjoursEvenementAsync(evenement);
            return NoContent();
        }
    }
}
