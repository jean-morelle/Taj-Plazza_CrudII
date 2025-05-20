using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje_Plazza.Application.Automapper.DTOs
{
    public class AddClientDto
    {
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string NumeroDeTelephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
    }
}
