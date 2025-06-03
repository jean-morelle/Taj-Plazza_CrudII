using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Domain.Models
{
    public class LocationEquipement : BaseEntity
    {
        [Required]
        [ForeignKey("Reservation")]
        public Guid ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }

        [Required]
        [ForeignKey("Equipement")]
        public Guid EquipementId { get; set; }
        public virtual Equipement Equipement { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateDebut { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateFin { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantite { get; set; }

        [Required]
        [StringLength(50)]
        public string Statut { get; set; } = "En cours";

        [StringLength(500)]
        public string? MotifAnnulation { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontantLocation { get; set; }

        [StringLength(500)]
        public string? Commentaires { get; set; }

        [NotMapped]
        public TimeSpan DureeLocation => DateFin - DateDebut;

        [NotMapped]
        public decimal MontantTotal => MontantLocation * Quantite;
    }
} 