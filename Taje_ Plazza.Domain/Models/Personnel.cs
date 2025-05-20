using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taje__Plazza.Domain.Models
{
    public class Personnel:BaseEntiy
    {
        public Guid UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; } = new Utilisateur();
        public string Role { get; set; } = string.Empty; 
    }
}
