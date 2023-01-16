
using Microsoft.AspNetCore.Mvc.RazorPages;
using Magazin_Cosmetice.Data;

namespace Magazin_Cosmetice.Models
{
    public class CategoriiProdusPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Magazin_CosmeticeContext context, Produs produs)
        {
            Microsoft.EntityFrameworkCore.DbSet<Categorie> allCategories = context.Categorie;
            HashSet<int> categoriiProdus = new HashSet<int>(
                produs.CategoriiProdus.Select(c => c.ProdusID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (Categorie cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.NumeCategorie,
                    Assigned = categoriiProdus.Contains(cat.ID)
                });
            }
        }

        public void UpdateProdusCategories(Magazin_CosmeticeContext context, string[] selectedCategories, Produs produsToUpdate)
        {
            if (selectedCategories == null)
            {
                produsToUpdate.CategoriiProdus = new List<CategorieProdus>();
                return;
            }

            HashSet<string> selectedCategoriesHS = new HashSet<string>(selectedCategories);
            HashSet<int> categoriiProdus = new HashSet<int>
                (produsToUpdate.CategoriiProdus.Select(c => c.Categorie.ID));
            foreach (Categorie cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!categoriiProdus.Contains(cat.ID))
                    {
                        produsToUpdate.CategoriiProdus.Add(
                            new CategorieProdus
                            {
                                ProdusID = produsToUpdate.ID,
                                CategorieID = cat.ID
                            });
                    }
                }

                else
                {
                    if (categoriiProdus.Contains(cat.ID))
                    {
                        CategorieProdus coursetoRemove = produsToUpdate.CategoriiProdus.SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(coursetoRemove);
                    }
                }
            }
        }
    }
}
