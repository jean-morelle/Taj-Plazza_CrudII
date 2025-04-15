namespace Taj_Plazza.Core.Models;

public class Client
{
    public Guid Id { get; set; }
    public string NomDuClient { get; set; } = string.Empty;
    public string? PrenomDuClient { get; set; } = string.Empty;
    public string? Domicile { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public  List <Reservation> Reservations { get; set; } = new List<Reservation>();
}