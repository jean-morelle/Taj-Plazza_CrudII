namespace Taj_Plazza.Core.Models
{
    public class Evenement
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public Status Status { get; set; }

        public DateTimeOffset DateDeReservation { get; set; }

        public string NomEvenement { get; set; }

        public string LieuEvenement { get; set; }

        public string Description { get; set; }

        public string Organisateur { get; set; }

        public DateTimeOffset DateEvenement { get; set; }

        public int NombreDePersonne { get; set; }

    }
}
