namespace Magazin_Cosmetice.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string? NumeCategorie { get; set; }


        public ICollection<CategorieProdus>? CategoriiProdus { get; set; }
    }
}
