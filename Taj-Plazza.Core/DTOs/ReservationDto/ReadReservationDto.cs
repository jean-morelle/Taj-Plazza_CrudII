using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.DTOs.ReservationDto
{
    public class ReadReservationDto
    {
        public int Id { get; set; }
        public int EvenementId { get; set; }
        public Evenement Evenement { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public int NombreDePersonne { get; set; }
        public DateTimeOffset DateDeReservation { get; set; }
    }
}
