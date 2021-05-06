using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PreVerifica.Data;
using PreVerifica.Models;

namespace PreVerifica.Pages
{
    public class CreateModel : PageModel
    {
        private readonly PreVerifica.Data.AutomobiliDbContext _context;

        public CreateModel(PreVerifica.Data.AutomobiliDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Automobile Automobile { get; set; }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Automobili.Add(Automobile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
