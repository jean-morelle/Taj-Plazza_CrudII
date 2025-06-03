using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Domain.Models
{
    public class Personnel : Utilisateur
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateEmbauche { get; set; }

        [Required]
        [StringLength(50)]
        public string Poste { get; set; }

        [Required]
        [StringLength(50)]
        public string Departement { get; set; }

        [StringLength(20)]
        public string Statut { get; set; } = "Actif";

        [StringLength(50)]
        public string? NumeroEmploye { get; set; }

        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalaireBase { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateFinContrat { get; set; }

        public List<string> Competences { get; set; } = new List<string>();

        public List<string> Certifications { get; set; } = new List<string>();

        [StringLength(500)]
        public string? Notes { get; set; }

        public bool EstDisponible { get; set; } = true;

        public virtual ICollection<MaintenanceEquipement> MaintenancesEffectuees { get; set; } = new List<MaintenanceEquipement>();

        // Relations
       // public virtual ICollection<Maintenance> MaintenancesEffectuees { get; set; }
        public virtual ICollection<Reservation> ReservationsGerees { get; set; }
        public string RolePersonnel { get; set; }
    }
}

