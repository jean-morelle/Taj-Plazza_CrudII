using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.DTOs
{
    public class ReadClientDto
    {
        public int Id { get; set; }

        public string NomComplete { get; set; }

        public string Domicile { get; set; }

        public string Telephone { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
