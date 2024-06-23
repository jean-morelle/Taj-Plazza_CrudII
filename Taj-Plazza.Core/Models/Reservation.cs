namespace Taj_Plazza.Core.Models;

public class Reservation
{
    public int Id { get; set; }
    public int EvenementId { get; set; }
    public Evenement Evenement { get; set; }
    public int UtilisateurId { get; set; }
    public Utilisateur Utilisateur { get; set; }
    public int NombreDePersonne { get; set; }
    public DateTimeOffset DateDeReservation { get; set; }
}