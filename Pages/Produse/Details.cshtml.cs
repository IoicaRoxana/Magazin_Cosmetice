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
    public class DetailsModel : PageModel
    {
        private readonly Magazin_Cosmetice.Data.Magazin_CosmeticeContext _context;

        public DetailsModel(Magazin_Cosmetice.Data.Magazin_CosmeticeContext context)
        {
            _context = context;
        }

      public Produs Produs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produs == null)
            {
                return NotFound();
            }

            Produs = await _context.Produs.FirstOrDefaultAsync(m => m.ID == id);

            if (Produs == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
