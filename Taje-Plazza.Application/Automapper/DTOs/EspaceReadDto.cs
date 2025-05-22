using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;

namespace Taje_Plazza.Application.Automapper.DTOs
{
    public class EspaceReadDto
    {
        public Guid Id { get; set; }
        public string NomEquipement { get; set; } = string.Empty;
        public string TypeEquipement { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string Capacite { get; set; } = string.Empty;
        public string TypeEspace { get; set; } = string.Empty;
    }
}
