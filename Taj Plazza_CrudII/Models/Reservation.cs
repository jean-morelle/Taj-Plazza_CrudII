using System.ComponentModel.DataAnnotations.Schema;

namespace Taj_Plazza_CrudII.Models
{
    public class Reservation
    {

        public int Id { get; set; }

        [ForeignKey("Client")]
        public int clientId { get; set; }

        public Client? client { get; set; }


        public ReservationStatut statut { get; set; }
         
        public DateTime Date_De_Reservation { get; set; }


        public string Nom_D_Evenement { get; set; }

        public DateTime Date_D_Evenement { get; set; }

        public int Nombre_De_Personne { get; set; }
  
        public ICollection<Reservation_OptionAjouter> reservation_OptionAjouters { get; set; }


    }
}
