using Taje__Plazza.Domain.Models;

namespace Taj_Plazza.Core.Models
{
    public class Utilisateur:BaseEntiy
    {
        public string Nom { get; set; } = string.Empty; 
        public string Prenom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; 
        public string MotDePasse { get; set; } = string.Empty; 
        public string Contact { get; set; } = string.Empty; 
        public DateTime DateInscription { get; set; } 
        public bool EstActif { get; set; } = true; 
        public ICollection<Personnel>Personnels { get; set; } = new List<Personnel>();
        public ICollection<Client> Clients { get; set; } = new List<Client>();
    }
}

