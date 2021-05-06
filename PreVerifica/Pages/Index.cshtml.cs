using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PreVerifica.Data;
using PreVerifica.Models;

namespace PreVerifica.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly PreVerifica.Data.AutomobiliDbContext _automobiliDbContext;
        private readonly UserManager<IdentityUser>_userManager;
        public IndexModel(ApplicationDbContext context, AutomobiliDbContext automobiliDbContext, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _automobiliDbContext = automobiliDbContext;
            _userManager = userManager;
        }

        public List<Automobile> Automobili { get;set; }

        public async Task OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Automobili = await _automobiliDbContext.Automobili.ToListAsync();
            }
            else
            {
                Automobili = await _automobiliDbContext.Automobili.Where(i => i.fkUserName == User.Identity.Name).ToListAsync();
            }
            
        }
    }
}
