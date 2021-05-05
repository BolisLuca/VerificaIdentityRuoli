using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgenziaFotografica.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;

namespace WebApp1.Pages
{
    public class EditModel : PageModel
    {
        private readonly ModelsDbContext _context;

        public EditModel(ModelsDbContext context)
        {
            _context = context;

        }

        [BindProperty]
        public Modelli modello { get; set; }


        public async Task<IActionResult> OnGetAsync(string id)
        {
            modello = await _context.Modelli.FindAsync(id);


            if (modello == null)
            {
                return RedirectToPage("./Index");
            }


            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(modello).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Modello {modello.pkModello} not found!");
            }

            return RedirectToPage("./Index");
        }
    }
}
