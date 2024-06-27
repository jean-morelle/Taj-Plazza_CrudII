using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.DTOs
{
    public class ReadEvenementDto
    {

        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public ReservationStatus Status { get; set; }

        public string NomEvenement { get; set; }

        public string Description { get; set; }

        public DateTimeOffset DateDebut { get; set; }

        public DateTimeOffset DateFin { get; set; }

        public string Place { get; set; }
    }
}
