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
        public Guid Id { get; set; }
      //  public Guid ClientId { get; set; }
        public string NomDuClient { get; set; } = string.Empty;
        public string PrenomDuClient { get; set; } = string.Empty;
        public string NomDesEspace { get; set; } = string.Empty;
        public string TypeEspace { get; set; } = string.Empty;
        public string Capacite { get; set; } = string.Empty;
        public string NomEspace { get; set; } = string.Empty;
        public string NomEvenement { get; set; } = string.Empty;
        public DateTime DateEvenement { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public TypeDEvenement TypeEvenement { get; set; }
      
    }
}
