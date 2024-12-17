using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;
using Taje__Plazza.Domain.Extension;

namespace Taje_Plazza.Application.DTOs
{
    public class EvenementDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ReservationStatus Status { get; set; }
        public string NomEvenement { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateDebut { get; set; }
        public DateTimeOffset? DateFin { get; set; }
        public string Place { get; set; }

        // Propriete Calculee

        public string StatutLabel => StatutExtension.ToStatutLabel(Status);
    }
}
