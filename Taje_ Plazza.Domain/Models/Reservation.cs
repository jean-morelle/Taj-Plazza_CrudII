using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje__Plazza.Domain.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; } = new Client();
        public Guid EvenementId { get; set; }
        public Evenement Evenement { get; set; } = new Evenement();
        public DateTime DateReservation { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public ICollection<Facture>Factures { get; set; }  = new List<Facture>();
    }
}
