using System;
using System.ComponentModel.DataAnnotations;
using Taje_Plazza.Domain.Models;

namespace Taje__Plazza.Domain.Models
{
    public class Maintenance : BaseEntity
    {
        [Required]
        public DateTime DateMaintenance { get; set; }

        [Required]
        public string TypeMaintenance { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Statut { get; set; }

        public decimal CoutMaintenance { get; set; }

        public string Commentaires { get; set; }

        public DateTime? DateFinMaintenance { get; set; }

        // Clés étrangères
        public Guid EspaceId { get; set; }
        public Guid PersonnelId { get; set; }

        // Relations
        public virtual Espace Espace { get; set; }
        public virtual Personnel Personnel { get; set; }
    }
} 