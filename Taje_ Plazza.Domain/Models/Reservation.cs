using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje__Plazza.Domain.Models
{
    public class Reservation:BaseEntiy
    {

        [Required]
        public DateTime ReservationDate { get; set; }

        public decimal AmountPaid { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [Required]
        [ForeignKey("Client")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; } = new Client();

        [Required]
        [ForeignKey("Space")]
        public Guid SpaceId { get; set; }
        public Espace Space { get; set; } = new Espace();

        public ICollection<Facture> Invoices { get; set; } = new List<Facture>();
    }
}
