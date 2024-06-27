using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.DTOs
{
    public class ReservationAjouterDto
    {
        public int EvenementId { get; set; }
        public int UtilisateurId { get; set; }
        public int NombreDePersonne { get; set; }
    }
}
