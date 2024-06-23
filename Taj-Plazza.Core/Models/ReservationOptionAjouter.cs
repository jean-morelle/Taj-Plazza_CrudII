namespace Taj_Plazza.Core.Models;

public class ReservationOptionAjouter
{
    public int Id { get; set; }

    //[ForeignKey("Reservation")]
    public int ReservationId { get; set; }

    public Reservation Reservation { get; set; }

    //[ForeignKey("OptionAjouter")]
    public int OptionAjouterId { get; set; }

    public OptionAjouter OptionAjouter { get; set; }
}