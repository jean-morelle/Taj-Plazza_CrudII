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
    public class Evenement : BaseEntity
    {
        [Required]
        public string? Nom { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string? TypeEvenement { get; set; }

        [ForeignKey("Reservation")]
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; } = new Reservation();
    }
}
