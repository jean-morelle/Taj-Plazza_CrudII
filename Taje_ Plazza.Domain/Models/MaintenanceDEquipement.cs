using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje__Plazza.Domain.Models
{
    public class MaintenanceDEquipement:BaseEntiy
    {

        [ForeignKey("Equipment")]
        public Guid EquipmentId { get; set; }
        public Equipement Equipment { get; set; } = new Equipement();

        [Required]
        public DateTime MaintenanceDate { get; set; }

        public string? Description { get; set; }
    }
}
