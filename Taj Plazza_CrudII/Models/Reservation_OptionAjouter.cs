using System.ComponentModel.DataAnnotations.Schema;

namespace Taj_Plazza_CrudII.Models
{
    public class Reservation_OptionAjouter
    {
        public int Id { get; set; }

        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }

        public Reservation reservation { get; set; }

        [ForeignKey("OptionAjouter")]
        public int OptionAjouterId { get; set; }

        public OptionAjouter optionAjouter { get; set; }
    }
}
