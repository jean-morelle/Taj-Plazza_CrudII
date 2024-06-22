namespace Taj_Plazza_CrudII.Models;

public class Categorie
{
    public int Id { get; set; }

    public string Nom { get; set; }

    public ICollection<OptionAjouter> OptionAjouters { get; set; }
}