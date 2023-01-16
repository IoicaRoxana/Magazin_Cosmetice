using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Magazin_Cosmetice.Data;
using Magazin_Cosmetice.Models;

namespace Magazin_Cosmetice.Pages.Produse
{
    public class EditModel : CategoriiProdusPageModel
    {
        private readonly Magazin_Cosmetice.Data.Magazin_CosmeticeContext _context;

        public EditModel(Magazin_Cosmetice.Data.Magazin_CosmeticeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produs Produs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produs = await _context.Produs
                .Include(b => b.CategoriiProdus)
                .ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Produs == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Produs);

           
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null) { return NotFound(); }
            Produs produsToUpdate = await _context.Produs.Include(i => i.CategoriiProdus).ThenInclude(i => i.Categorie).FirstOrDefaultAsync(s => s.ID == id);

            if (produsToUpdate == null) { return NotFound(); }

            if (produsToUpdate == null) { return NotFound(); }
            if (await TryUpdateModelAsync<Produs>(
                produsToUpdate,
                "Produs",
                i => i.Denumire, i => i.Brand,
                i => i.Pret, i => i.DataFabricarii))

            {
                UpdateProdusCategories(_context, selectedCategories, produsToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateProdusCategories(_context, selectedCategories, produsToUpdate);
            PopulateAssignedCategoryData(_context, produsToUpdate);
            return Page();


            // return RedirectToPage("./Index");
        }

        private bool ProdusExists(int id)
        {
            return _context.Produs.Any(e => e.ID == id);
        }
    }
}
