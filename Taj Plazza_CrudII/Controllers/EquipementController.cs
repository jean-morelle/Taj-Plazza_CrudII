using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taj_Plazza_CrudII.Extention;
using Taje__Plazza.Domain.Interface;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Application.Automapper.DTOs;

namespace Taj_Plazza_CrudII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipementController : ControllerBase
    {
        private readonly IEquipementServices equipementServices;

        public EquipementController(IEquipementServices equipementServices)
        {
            this.equipementServices = equipementServices;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenirTousLesEquipements()
        {
            var equipement = await equipementServices.ObtenirTousLesEquipemntsAsync();
            var equipementDto = equipement.ConvertToDto();
            return Ok(equipementDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>ObtenirEquipementId(Guid equipementId)
        {
            var equipement = await equipementServices.ObtenirEquipement(equipementId);
            return Ok(equipement);
        }
        [HttpPost]
        public async Task<IActionResult> AjouterEquipement(AddEquipementDto addEquipementDto)
        {
            var equipement = addEquipementDto.ConvertToEntity();
             await equipementServices.AjouterEquipement(equipement);
            return CreatedAtAction(nameof(ObtenirEquipementId), new { id = equipement.Id },equipement);
        }
        [HttpPut]
        public async Task<IActionResult>MettreAjoursEquipement(Guid id,UpdateEquipementDto updateEquipementDto)
        {
            var equipements = await equipementServices.ObtenirEquipement(id);
            if(equipements is null)
            {
                return NotFound();
            }
            else
            {
                equipements.UpdateFromDto(updateEquipementDto);
                await equipementServices.MettreAjoursEquipementAsync(equipements);
                
            }
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult>SupprimerEquipement(Guid id)
        {
            var equipement = await equipementServices.ObtenirEquipement(id);
            if(equipement is null)
            {
                return NotFound();
            }
            else
            {
                await equipementServices.SupprimerEquipement(id);
            }
            return NoContent();
        }
    }
}
