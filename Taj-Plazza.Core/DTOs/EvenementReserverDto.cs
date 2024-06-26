using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.DTOs
{
    public class EvenementReserverDto
    {
        public int Id { get; set; }
        public int EvenementId { get; set; }
        public string NomEvenement { get; set; }
        public DateTimeOffset DateDebut { get; set; }
        public DateTimeOffset? DateFin { get; set; }
        public string Activites { get; set; }
        public string LieuEvenement { get; set; }
    }
}
