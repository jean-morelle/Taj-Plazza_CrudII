using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;

namespace Taje_Plazza.Application.Automapper.DTOs
{
    public class UpdateEvenementDto
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid EspaceId { get; set; }
        public string Nom { get; set; } = string.Empty;
        public DateTime DateEvenement { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public TypeDEvenement TypeEvenement { get; set; }
    }
}
