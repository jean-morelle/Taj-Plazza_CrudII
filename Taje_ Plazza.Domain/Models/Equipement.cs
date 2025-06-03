using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Domain.Models
{
    public class Equipement : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int QuantiteDisponible { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal TarifJournalier { get; set; }

        public string? Description { get; set; }
        
        [StringLength(50)]
        public string? NumeroSerie { get; set; }
        
        public string? Marque { get; set; }
        
        public string? Modele { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? DateAcquisition { get; set; }
        
        public string? EtatActuel { get; set; }

        public virtual ICollection<LocationEquipement> Locations { get; set; } = new List<LocationEquipement>();
        public virtual ICollection<MaintenanceEquipement> Maintenances { get; set; } = new List<MaintenanceEquipement>();
    }
}
