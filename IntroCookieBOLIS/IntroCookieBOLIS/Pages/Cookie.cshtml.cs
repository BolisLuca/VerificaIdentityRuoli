using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntroCookieBOLIS.Pages
{
    public class CookieModel : PageModel
    {
        [BindProperty]
        public string SelectedColor { get; set; }
        [BindProperty]
        public bool display { get; set; }

        public List<SelectListItem> Colors { get; set; }
        public async Task OnGetAsync()
        {
            if (Request.Cookies["Color"] != null)
            {
                display = false;
                SelectedColor = Request.Cookies["Color"];
            }
            else
            {
                display = true;
                Colors = new List<SelectListItem> //asp-net items vuole elementi di tipo SelectListItem
            {
                new SelectListItem{Value="white", Text="white" },
                new SelectListItem{Value="red", Text="red" },
                new SelectListItem{Value="green", Text="green" },
                new SelectListItem{Value="blue",Text="blue" }
            };
            }
        }

        public async Task OnPostAsync()
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };
            Response.Cookies.Append("Color", SelectedColor, cookieOptions);



        }
    }
}
