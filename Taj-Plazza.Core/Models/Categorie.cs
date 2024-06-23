namespace Taj_Plazza.Core.Models;

public class Categorie
{
    public int Id { get; set; }

    public string Nom { get; set; }

    public ICollection<OptionAjouter> OptionAjouters { get; set; }
}