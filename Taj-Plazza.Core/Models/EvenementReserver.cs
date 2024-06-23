namespace Taj_Plazza.Core.Models
{
    public class EvenementReserver
    {
        public int Id { get; set; } 
        public int EvenementId { get; set; }
        public Evenement Evenement { get; set; }
        public DateTimeOffset DateDebut { get; set; }
        public DateTimeOffset? DateFin { get; set; }
        public string Activites { get; set; }
        public string LieuEvenement { get; set; }
    }
}
