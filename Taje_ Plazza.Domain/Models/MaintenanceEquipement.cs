using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Domain.Models
{
    public class MaintenanceEquipement : BaseEntity
    {
        [Required]
        [ForeignKey("Equipement")]
        public Guid EquipementId { get; set; }
        public virtual Equipement Equipement { get; set; }

        [Required]
        [ForeignKey("Personnel")]
        public Guid PersonnelId { get; set; }
        public virtual Personnel Personnel { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateDebut { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateFin { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Statut { get; set; } = "Planifiée";

        [StringLength(1000)]
        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CoutMaintenance { get; set; }

        public string? PiecesChangees { get; set; }

        [StringLength(500)]
        public string? Resultats { get; set; }

        [StringLength(500)]
        public string? Recommandations { get; set; }

        [NotMapped]
        public TimeSpan DureeMaintenance => DateFin - DateDebut;
    }
} 