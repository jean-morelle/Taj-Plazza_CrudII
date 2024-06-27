using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int EvenementId { get; set; }
        public string NomEvenement { get; set; }
        public int UtilisateurId { get; set; }
        public string NomUtilisateur { get; set; }
        public int NombreDePersonne { get; set; }
        public DateTimeOffset DateDeReservation { get; set; }
        public DateTimeOffset DateEvenement { get; set; }
    }
}
