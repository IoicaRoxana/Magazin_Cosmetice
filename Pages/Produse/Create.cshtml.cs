using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Magazin_Cosmetice.Data;
using Magazin_Cosmetice.Models;

namespace Magazin_Cosmetice.Pages.Produse
{
    public class CreateModel : CategoriiProdusPageModel
    {
        private readonly Magazin_Cosmetice.Data.Magazin_CosmeticeContext _context;

        public CreateModel(Magazin_Cosmetice.Data.Magazin_CosmeticeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            
            Produs produs = new Produs();
            produs.CategoriiProdus = new List<CategorieProdus>();
            PopulateAssignedCategoryData(_context, produs);
            return Page();
        }

        [BindProperty]
        public Produs Produs { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            Produs newProdus = new Produs();
            if (selectedCategories != null)
            {
                newProdus.CategoriiProdus = new List<CategorieProdus>();
                foreach (string cat in selectedCategories)
                {
                    CategorieProdus catToAdd = new CategorieProdus
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newProdus.CategoriiProdus.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Produs>(newProdus, "Produs", i => i.Denumire, i => i.Brand, i => i.Pret, i => i.DataFabricarii))
            {
                _context.Produs.Add(newProdus);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newProdus);
            return Page();

        }
    }
}
