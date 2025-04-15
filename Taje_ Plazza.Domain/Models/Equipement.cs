using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje__Plazza.Domain.Models
{
    public class Equipement
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = string.Empty; // Nom de l'équipement (ex : Table, Fourchette)
        public bool Inclus { get; set; } // Indique si l'équipement est fourni gratuitement avec la réservation
        public decimal? PrixLocation { get; set; } // Prix pour louer cet équipement supplémentaire (nullable)
    }

}
