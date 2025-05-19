using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje__Plazza.Domain.Models
{
    public class Evenement
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; } = new Client();
        public Guid EspaceId { get; set; }
        public Espace Espace { get; set; } = new Espace();
        public string Nom { get; set; } = string.Empty;
        public DateTime DateEvenement { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public TypeDEvenement TypeEvenement { get; set; } 
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<LocationDEquipement> LocationDequipements { get; set; } = new List<LocationDEquipement>();

    }
}
