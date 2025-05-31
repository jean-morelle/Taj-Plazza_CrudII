using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taje__Plazza.Domain.Models
{
    public class Client:Utilisateur
    {
      
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Facture> Invoices { get; set; } = new List<Facture>();
    }
}
