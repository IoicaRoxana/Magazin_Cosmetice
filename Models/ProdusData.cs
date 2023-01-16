using System.Collections.Generic;
namespace Magazin_Cosmetice.Models
{
    public class ProdusData
    {
        public IEnumerable<Produs>? Produse { get; set; }
        public IEnumerable<Categorie>? Categorii { get; set; }
        public IEnumerable<CategorieProdus>? CategoriiProdus { get; set; }
    }
}
