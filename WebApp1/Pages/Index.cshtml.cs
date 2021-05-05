using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgenziaFotografica.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp1.Data;

namespace WebApp1.Pages
{
   
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ModelsDbContext _context;
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context1,  ModelsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Modelli> Modelli { get; set; }
         
        public async Task OnGetAsync()
        {
            Modelli = await _context.Modelli.ToListAsync();
           
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            var modellodaeliminare = await _context.Modelli.FindAsync(id);

            if (modellodaeliminare != null)
            {
                _context.Modelli.Remove(modellodaeliminare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
