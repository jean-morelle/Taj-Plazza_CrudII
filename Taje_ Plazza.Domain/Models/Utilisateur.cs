namespace Taj_Plazza.Core.Models
{
    public class Utilisateur
    {
        public Guid Id { get; set; } // Identifiant unique de l'utilisateur
        public string Nom { get; set; } = string.Empty; // Nom de l'utilisateur
        public string Prenom { get; set; } = string.Empty; // Prénom de l'utilisateur
        public string Email { get; set; } = string.Empty; // Adresse email
        public string MotDePasse { get; set; } = string.Empty; // Mot de passe sécurisé
        public string Role { get; set; } = "Administrateur"; // Rôle de l'utilisateur (garant par défaut)
        public string Contact { get; set; } = string.Empty; // Numéro de téléphone ou contact
        public DateTime DateInscription { get; set; } // Date à laquelle l'utilisateur s'est inscrit
        public bool EstActif { get; set; } = true; // Statut de l'utilisateur (actif ou inactif)
       
    }
}

