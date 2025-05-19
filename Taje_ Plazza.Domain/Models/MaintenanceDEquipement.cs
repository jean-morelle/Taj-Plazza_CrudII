using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje__Plazza.Domain.Models
{
    public class MaintenanceDEquipement
    {
        public Guid Id { get; set; }
        public Guid EquipementId { get; set; }
        public Equipement Equipement { get; set; } = new Equipement();
        public DateTime DateDebutMaintenance { get; set; }
        public DateTime DateFinMaintenance { get; set; }
        public string TypeMaintenance { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool EstTerminee { get; set; } = false;
    }
}
