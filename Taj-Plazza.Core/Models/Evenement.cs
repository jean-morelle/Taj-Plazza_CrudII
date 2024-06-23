namespace Taj_Plazza.Core.Models
{
    public class Evenement
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public ReservationStatus Status { get; set; }
        
        public string NomEvenement { get; set; }

        public string Description { get; set; }
        
        public DateTimeOffset DateDebut { get; set; }

        public DateTimeOffset DateFin { get; set; }

        public string Place { get; set; }
    }
}
