using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje__Plazza.Domain.Models
{
    public class Facture:BaseEntiy
    {
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; } = new Reservation();
        public string MontantTotal { get; set; } = string.Empty;
        public DateTime DateDePayement { get; set; }
        public TypeDePayement TypeDePayement { get; set; } 
    }
}
