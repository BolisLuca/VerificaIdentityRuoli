using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgenziaFotografica.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp1.Data;

namespace WebApp1.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ModelsDbContext _context;

        public CreateModel(ModelsDbContext context)
        {
            _context = context;

        }

        [BindProperty]
        public Modelli modello { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Modelli.Add(modello);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


        public IActionResult OnGet()
        {

            return Page();
        }
    }
}
