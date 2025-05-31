using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje_Plazza.Application.Automapper.Dtos
{
    public class EspaceDto
    {
        [Required]
        public string? Name { get; set; }

        public int Capacity { get; set; }

        public string? Type { get; set; }
    }
}
