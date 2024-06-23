namespace Taj_Plazza.Core.Models;

public class Client
{

    public int Id { get; set; }

    public string Nom { get; set; }


    public string Prenom { get; set; }


    public string Domicile { get; set; }


    public int Num_Telephone { get; set; }

    public ICollection <Reservation> Reservations { get; set; }
}