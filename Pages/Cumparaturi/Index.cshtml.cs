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
    public class IndexModel : PageModel
    {
        private readonly Magazin_Cosmetice.Data.Magazin_CosmeticeContext _context;

        public IndexModel(Magazin_Cosmetice.Data.Magazin_CosmeticeContext context)
        {
            _context = context;
        }

        public IList<Cumparare> Cumparare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cumparare != null)
            {
                Cumparare = await _context.Cumparare
                .Include(c => c.Client)
                .Include(c => c.Produs).ToListAsync();
            }
        }
    }
}
