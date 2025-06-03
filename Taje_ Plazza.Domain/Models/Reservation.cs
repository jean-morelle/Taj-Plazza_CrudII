using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Domain.Models
{
    public class Reservation : BaseEntity
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateReservation { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateDebut { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateFin { get; set; }

        [Required]
        [StringLength(50)]
        public string Statut { get; set; } = "En attente";

        [StringLength(500)]
        public string? MotifAnnulation { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontantTotal { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontantPaye { get; set; }

        public int NombrePersonnes { get; set; }

        [StringLength(1000)]
        public string? NotesSpeciales { get; set; }

        public List<string> Options { get; set; } = new List<string>();
        public List<string> ServicesSupplementaires { get; set; } = new List<string>();

        [Required]
        [ForeignKey("Client")]
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }

        [Required]
        [ForeignKey("Espace")]
        public Guid EspaceId { get; set; }
        public virtual Espace Espace { get; set; }

        public virtual ICollection<LocationEquipement> EquipementsReserves { get; set; } = new List<LocationEquipement>();

        [NotMapped]
        public bool EstPayeeCompletement => MontantPaye >= MontantTotal;

        [NotMapped]
        public TimeSpan Duree => DateFin - DateDebut;
    }
}
