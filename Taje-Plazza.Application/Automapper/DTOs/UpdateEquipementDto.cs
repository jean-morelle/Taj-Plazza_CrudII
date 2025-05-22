using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje_Plazza.Application.Automapper.DTOs
{
    public class UpdateEquipementDto
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int QuantiteDisponible { get; set; }
    }
}
