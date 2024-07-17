namespace Taj_Plazza.Core.Models
{
    public class EvenementReserver
    {
        public int Id { get; set; }
        public int EvenementId { get; set; }
        public Evenement Evenement { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int NombreDePersonne { get; set; }
    }
}
