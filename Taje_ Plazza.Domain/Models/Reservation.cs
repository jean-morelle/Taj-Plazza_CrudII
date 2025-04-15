using Taje__Plazza.Domain.Models;

namespace Taj_Plazza.Core.Models;

public class Reservation
{
    public Guid Id { get; set; } // Identifiant unique de la réservation
    public Guid ClientId { get; set; } // Identifiant du client
    public Client Client { get; set; } = new Client();
    public Guid? EvenementId { get; set; } // Identifiant de l'événement (nullable si pas d'événement)
    public Evenement Evenement { get; set; } = new Evenement();
    public List<Equipement> EquipementsInclus { get; set; } = new List<Equipement>(); // Équipements inclus gratuitement
    public List<Equipement> EquipementsSupplementaires { get; set; } = new List<Equipement>(); // Équipements supplémentaires loués
    public decimal? TotalPrixEquipementsSupplementaires => EquipementsSupplementaires?.Sum(e => e.PrixLocation ?? 0) ?? 0; // Calcul automatique
    public DateTime DateReservation { get; set; } // Date et heure de la réservation
    public string StatutPaiement { get; set; } = string.Empty; // "Complet" ou "Partiel"
    public string? RemarqueClient { get; set; } // Commentaires ou demandes spécifiques (optionnel)
    public bool EstGratuit { get; set; } // Indique si la réservation est gratuite ou non
}  