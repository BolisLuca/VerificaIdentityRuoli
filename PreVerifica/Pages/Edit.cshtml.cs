using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PreVerifica.Data;
using PreVerifica.Models;

namespace PreVerifica.Pages
{
    [Authorize(Roles ="Admin,Salesman")]

    public class EditModel : PageModel
    {
        private readonly PreVerifica.Data.AutomobiliDbContext _context;

        public EditModel(PreVerifica.Data.AutomobiliDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Automobile Automobile { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Automobile = await _context.Automobili.FirstOrDefaultAsync(i => i.PkId == id);

            if (Automobile == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Automobile).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            
            return RedirectToPage("./Index");
        }
    }
}
