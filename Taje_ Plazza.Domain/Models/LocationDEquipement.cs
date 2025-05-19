using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje__Plazza.Domain.Models
{
    public class LocationDEquipement
    {
        public Guid Id { get; set; }
        public Guid EquipementId { get; set; }
        public Equipement Equipement { get; set; } = new Equipement();
        public Guid EvenementId { get; set; }
        public Evenement Evenement { get; set; } = new Evenement();
        public int Quantite { get; set; }
        public DateTime DateDeLocation { get; set; }

    }
}
