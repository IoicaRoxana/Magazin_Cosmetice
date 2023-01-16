using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Magazin_Cosmetice.Data;
using Magazin_Cosmetice.Models;

namespace Magazin_Cosmetice.Pages.Cumparaturi
{
    public class DeleteModel : PageModel
    {
        private readonly Magazin_Cosmetice.Data.Magazin_CosmeticeContext _context;

        public DeleteModel(Magazin_Cosmetice.Data.Magazin_CosmeticeContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Cumparare Cumparare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cumparare == null)
            {
                return NotFound();
            }

            var cumparare = await _context.Cumparare.FirstOrDefaultAsync(m => m.ID == id);

            if (cumparare == null)
            {
                return NotFound();
            }
            else 
            {
                Cumparare = cumparare;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cumparare == null)
            {
                return NotFound();
            }
            var cumparare = await _context.Cumparare.FindAsync(id);

            if (cumparare != null)
            {
                Cumparare = cumparare;
                _context.Cumparare.Remove(Cumparare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
