

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Magazin_Cosmetice.Data;
using Magazin_Cosmetice.Models;

namespace Magazin_Cosmetice.Pages.Produse
{
    public class IndexModel : PageModel
    {
        private readonly Magazin_Cosmetice.Data.Magazin_CosmeticeContext _context;

        public IndexModel(Magazin_Cosmetice.Data.Magazin_CosmeticeContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get; set; }
        public ProdusData ProdusD { get; set; }
        public string DenumireSort { get; set; }
        public int ProdusID { get; set; }
        public int CategorieID { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categorieID, string sortOrder, string
searchString)
        {
            ProdusD = new ProdusData();

            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "denumire_desc" : "";
            CurrentFilter = searchString;
            ProdusD.Produse = await _context.Produs
               
                .Include(b => b.CategoriiProdus)
                .ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .OrderBy(b => b.Denumire)
                .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                ProdusD.Produse = ProdusD.Produse.Where(s => s.Denumire.Contains(searchString));
                if (id != null)
                {
                    ProdusID = id.Value;
                    Produs produs = ProdusD.Produse
                        .Where(i => i.ID == id.Value).Single();
                    ProdusD.Categorii = produs.CategoriiProdus.Select(s => s.Categorie);
                }

                switch (sortOrder)
                {
                    case "denumire_desc":
                        ProdusD.Produse = ProdusD.Produse.OrderByDescending(s =>
                       s.Denumire);
                        break;
                }

                // Produs = await _context.Produs.Include(b=>b.Status).ToListAsync();
            }
        }
    }
}
