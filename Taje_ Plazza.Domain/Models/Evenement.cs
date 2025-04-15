namespace Taj_Plazza.Core.Models
{
    public class Evenement
    {
        public Guid Id { get; set; }
        public string NomDeLEvenement { get; set; } = string.Empty;
        public string LieuEvenement { get; set; } = string.Empty;
        public DateTimeOffset DateDebut { get; set; }
        public DateTimeOffset DateFin { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
