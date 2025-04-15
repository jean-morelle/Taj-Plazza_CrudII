using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje__Plazza.Domain.Models
{
    public class LocationIndependante
    {
        public Guid Id { get; set; } // Identifiant unique pour chaque location
        public DateTime DateLocation { get; set; } // Date de la location
        public string NomDuClient { get; set; } = string.Empty; // Nom du client qui loue
        public List<Equipement> EquipementsLoues { get; set; } = new List<Equipement>(); // Équipements loués
        public decimal TotalPrix { get; set; } // Calcul du total des équipements loués
    }
}
