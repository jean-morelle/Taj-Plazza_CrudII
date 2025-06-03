using System.ComponentModel.DataAnnotations;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Domain.Models;

namespace Taj_Plazza.Core.Models
{
    public class Utilisateur : BaseEntity
    {
        [Required]
        public string? Nom { get; set; }

        [Required]
        public string? Prenom { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? Telephone { get; set; }

        [Required]
        public string MotDePasse { get; set; }

        [Required]
        public string Role { get; set; } = "Utilisateur";

        public DateTime? DerniereConnexion { get; set; }
    }
}

