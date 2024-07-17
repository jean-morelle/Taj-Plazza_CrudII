namespace Taj_Plazza.Core.Models;

public class Reservation
{
    public int Id { get; set; }
    public string AccessoireAjouter { get; set; }
    public string Desciption { get; set; }
    public decimal Prix { get; set; }
    public string ImageURl { get; set; } = "https://via.placeholder.com/300x300";
    public int Quantite { get; set; }
    public int CategorieId { get; set; }
    public Categorie Categorie { get; set; }
}