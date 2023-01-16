﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Magazin_Cosmetice.Data;
using Magazin_Cosmetice.Models;

namespace Magazin_Cosmetice.Pages.Clienti
{
    public class CreateModel : PageModel
    {
        private readonly Magazin_Cosmetice.Data.Magazin_CosmeticeContext _context;

        public CreateModel(Magazin_Cosmetice.Data.Magazin_CosmeticeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Client.Add(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
