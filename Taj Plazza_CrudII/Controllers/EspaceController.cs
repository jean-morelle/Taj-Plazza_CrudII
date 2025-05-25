using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taj_Plazza_CrudII.Extention;
using Taje__Plazza.Domain.Interface;

namespace Taj_Plazza_CrudII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspaceController : ControllerBase
    {
        private readonly IEspaceServices espaceServices;
        private readonly IEquipementServices equipementServices;

        public EspaceController(IEspaceServices espaceServices, IEquipementServices equipementServices)
        {
            this.espaceServices = espaceServices;
            this.equipementServices = equipementServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEspaces()
        {
            var espaces = await espaceServices.ObtenirTousLesEspaceAsync();
            var equipements = await equipementServices.ObtenirTousLesEquipemntsAsync();
            var result = espaces.ConvertToDto(equipements);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEspaceById(Guid espaceId,Guid equipementId)
        {
            var espace = await espaceServices.ObtenirEspaceAsync(espaceId);
            var equipement = await equipementServices.ObtenirEquipement(equipementId);
            if (espace == null || equipement == null)
            {
                return NotFound();
            }
            var result = espace.ConvertTo(equipement);
            return Ok(result);
        }
    }
}