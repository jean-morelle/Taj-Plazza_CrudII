using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;

namespace Taje_Plazza.Application.Automapper.DTOs
{
    public class EvenementReadDto
    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; } = new Client();
        public Guid EspaceId { get; set; }
        public Espace Espace { get; set; } = new Espace();
        public string Nom { get; set; } = string.Empty;
        public DateTime DateEvenement { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public TypeDEvenement TypeEvenement { get; set; }
      
    }
}
