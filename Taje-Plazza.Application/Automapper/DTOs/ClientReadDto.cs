using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;
using Taje__Plazza.Domain.Models;

namespace Taje_Plazza.Application.Automapper.DTOs
{
    public class ClientReadDto
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string NumeroDeTelephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;

    }
}
