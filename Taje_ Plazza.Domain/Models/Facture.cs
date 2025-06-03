using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje_Plazza.Domain.Models;

namespace Taje__Plazza.Domain.Models
{
    public class Facture : BaseEntity
    {
        [Required]
        public DateTime DateFacture { get; set; }

        [Required]
        public DateTime DateEcheance { get; set; }

        public string? StatutPaiement { get; set; }

        [Required]
        public string Reference { get; set; }

        public decimal MontantTotal { get; set; }
        public decimal MontantRestantDu { get; set; }

        public DateTime? DernierPaiement { get; set; }
        public string? MethodePaiement { get; set; }
        public string? MotifAnnulation { get; set; }

        [ForeignKey("Reservation")]
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; } = new Reservation();

        [ForeignKey("Client")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; } = new Client();

        [ForeignKey("Espace")]
        public Guid EspaceId { get; set; }
        public Espace Espace { get; set; } = new Espace();
    }
}
