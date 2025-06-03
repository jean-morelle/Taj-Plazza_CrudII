using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Domain.Models
{
    public class Espace : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Capacite { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Range(0, double.MaxValue)]
        public decimal TarifHoraire { get; set; }

        [Range(0, double.MaxValue)]
        public decimal TarifJournalier { get; set; }

        public string? Description { get; set; }

        public string? Equipements { get; set; }

        public string? Localisation { get; set; }

        public bool EstDisponible { get; set; } = true;

        [StringLength(500)]
        public string? Caracteristiques { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Facture> Factures { get; set; } = new List<Facture>();
    }
}
