namespace Taj_Plazza.Core.Models;

public class Client
{
    public int Id { get; set; }

    public string NomComplete { get; set; }

    public string Domicile { get; set; }

    public string Telephone { get; set; }

    public string Email { get; set; }
    public ICollection <Reservation> Reservations { get; set; }
}