using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje__Plazza.Domain.Models
{
    public class Facture:BaseEntiy
    {
        [Required]
        public DateTime InvoiceDate { get; set; }

        public string? PaymentStatus { get; set; }

        [ForeignKey("Reservation")]
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; } = new Reservation();

        [ForeignKey("Client")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; } = new Client();

        [ForeignKey("Space")]
        public Guid SpaceId { get; set; }
        public Espace Space { get; set; } = new Espace();

        public decimal TotalAmount { get; set; }
    }
}
