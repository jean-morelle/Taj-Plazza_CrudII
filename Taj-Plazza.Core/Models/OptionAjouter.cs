using System.ComponentModel.DataAnnotations.Schema;

namespace Taj_Plazza.Core.Models;

public class OptionAjouter
{
    public int Id { get; set; }

    public string Nom { get; set; }

    public decimal Prix { get; set; }

    [ForeignKey("Categorie")]
    public int CategorieId { get; set; }

    public Categorie categorie { get; set; }

    public ICollection<ReservationOptionAjouter> reservation_OptionAjouters { get; set; }
}