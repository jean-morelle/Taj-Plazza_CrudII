using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje_Plazza.Application.Automapper.Dtos
{
    public class ClientDto
    {
        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
