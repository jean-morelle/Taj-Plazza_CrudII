using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje__Plazza.Domain.Models
{
    public class LocationDEquipement:BaseEntiy
    {

        [ForeignKey("Event")]
        public Guid EventId { get; set; }
        public Evenement Event { get; set; } = new Evenement();

        [ForeignKey("Equipment")]
        public Guid EquipmentId { get; set; }
        public Equipement Equipment { get; set; } = new Equipement();

        public int Quantity { get; set; }

        [Required]
        public DateTime RentalDate { get; set; }

    }
}
