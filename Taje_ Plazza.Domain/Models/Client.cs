using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;
using Taje__Plazza.Domain.Models;

namespace Taje_Plazza.Domain.Models
{
    public class Client : Utilisateur
    {
        [Required]
        public string NumeroClient { get; set; }
        
        public string? Adresse { get; set; }
        
        [Range(0, int.MaxValue)]
        public int PointsFidelite { get; set; }
        
        public string? Preferences { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public virtual ICollection<Facture> Factures { get; set; } = new List<Facture>();
    }
}
