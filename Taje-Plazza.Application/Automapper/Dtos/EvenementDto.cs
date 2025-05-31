using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje_Plazza.Application.Automapper.Dtos
{
    public class EvenementDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string? EventType { get; set; }
    }
}
