using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;

namespace Taje_Plazza.Application.Automapper.DTOs
{
    public class AddEspaceDto
    {
        public Guid EquipementId { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Capacite { get; set; } = string.Empty;
        public string TypeEspace { get; set; } = string.Empty;
    }
}
