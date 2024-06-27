using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.DTOs.ReservationDto
{
    public  class AddReservationDto
    {
        public int NombreDePersonne { get; set; }
        public DateTimeOffset DateDeReservation { get; set; }

    }
}
