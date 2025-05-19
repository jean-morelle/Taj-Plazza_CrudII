using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taje__Plazza.Domain.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public Guid UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; } = new Utilisateur();
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string NumeroDeTelephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Evenement> Evenements { get; set; } = new List<Evenement>();
    }
}
