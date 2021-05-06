using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PreVerifica.Data;
using PreVerifica.Models;

namespace PreVerifica.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly PreVerifica.Data.AutomobiliDbContext _context;

        public DeleteModel(PreVerifica.Data.AutomobiliDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Automobile AutomobileDaEliminare { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AutomobileDaEliminare = await _context.Automobili.FirstOrDefaultAsync(i => i.PkId == id);

            if (AutomobileDaEliminare == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AutomobileDaEliminare = await _context.Automobili.FindAsync(id);

            if (AutomobileDaEliminare != null)
            {
                _context.Automobili.Remove(AutomobileDaEliminare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
