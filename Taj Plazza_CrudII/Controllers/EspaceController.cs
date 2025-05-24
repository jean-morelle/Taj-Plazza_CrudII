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
    public class EspaceController : ControllerBase
    {
        private readonly IEspaceServices espaceServices;
        private readonly IEquipementServices services;

        public EspaceController(IEspaceServices espaceServices, IEquipementServices services)
        {
            this.espaceServices = espaceServices;
            this.services = services;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenirEspacesAsync()
        {
            var espaces = await espaceServices.ObtenirTousLesEspaceAsync();
            var equipements = await services.ObtenirTousLesEquipemntsAsync();
            var espaceDto = espaces.ConvertToDto(equipements);
            return Ok(espaceDto);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> ObtenirEspaceParId(Guid id)
        {
            var espace = await espaceServices.ObtenirEspaceAsync(id);
            return Ok(espace);
        }
        [HttpPost]
        public async Task<IActionResult> AjouterEspace(AddEspaceDto addEspaceDto)
        {
            var espace = addEspaceDto.ConvertToEntity();
            await espaceServices.AjouterEspaceAsync(espace);
            return   CreatedAtAction(nameof(ObtenirEspaceParId), new { id = espace.Id }, espace);
        }
        [HttpDelete]
        public async Task<IActionResult>SupprimerEspace(Guid id)
        {
            var espace = await espaceServices.ObtenirEspaceAsync(id);
            if (espace == null)
            {
                return NotFound();
            }
            else
            {
                await espaceServices.SupprimerEspaceAsync(id);
            }
            return NoContent();
        }
      
    }
}
