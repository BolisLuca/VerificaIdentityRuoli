using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bolis.Data;
using Bolis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bolis.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TelefoniDbContext _context;

        public IndexModel(TelefoniDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string MarcaSelezionata { get; set; }

        [BindProperty]
        public int fasciadiprezzoselezionata { get; set; }
        public List<SelectListItem> Marche {get; set;}
        public List<SelectListItem> FasceDiPrezzo { get; set; }
        public List<Telefono> Telefoni{ get;set; }

        public async Task OnGetAsync()
        {
            Marche = new List<SelectListItem>();
            Marche.Add(new SelectListItem { Value = "Qualunque", Text = "Qualunque" });
            FasceDiPrezzo = new List<SelectListItem>()
            {new SelectListItem
                {
                    Value = "0",
                    Text = "Qualunque"
                },
                new SelectListItem
                {
                    Value = "1",
                    Text = "0-150"
                },
                 new SelectListItem
                {
                    Value = "2",
                    Text = "151-300"
                },
                  new SelectListItem
                {
                    Value = "3",
                    Text = "301-500"
                },
                   new SelectListItem
                {
                    Value = "4",
                    Text = "500+"
                }

            };
            
          
                Telefoni = await _context.Telefoni.ToListAsync();

            foreach (var telefono in Telefoni)
            {
                Marche.Add(new SelectListItem { Value=telefono.Marca, Text= telefono.Marca});
            }

            
            Marche = Marche.Distinct().ToList();


        }
        public async Task OnPostAsync()
        {

            Marche = new List<SelectListItem>();
            Marche.Add(new SelectListItem { Value = "Qualunque", Text = "Qualunque" });
            FasceDiPrezzo = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = "0",
                    Text = "Qualunque"
                },
                new SelectListItem
                {
                    Value = "1",
                    Text = "0-150"
                },
                 new SelectListItem
                {
                    Value = "2",
                    Text = "151-300"
                },
                  new SelectListItem
                {
                    Value = "3",
                    Text = "301-500"
                },
                   new SelectListItem
                {
                    Value = "4",
                    Text = "500+"
                }

            };

           

            Telefoni = await _context.Telefoni.ToListAsync();

            switch (fasciadiprezzoselezionata)
            {
                case 0:
                    Telefoni = await _context.Telefoni.ToListAsync();
                    break;
                case 1:
                    Telefoni = Telefoni.Where(i => i.Prezzo_di_vendita < 150).ToList();
                    break;

                case 2:
                    Telefoni = Telefoni.Where(i => i.Prezzo_di_vendita > 150  && i.Prezzo_di_vendita < 300).ToList();
                    break;

                case 3:
                    Telefoni = Telefoni.Where(i => i.Prezzo_di_vendita > 300 && i.Prezzo_di_vendita < 500).ToList();
                    break;

                case 4:
                    Telefoni = Telefoni.Where(i => i.Prezzo_di_vendita > 500).ToList();
                    break;
            }

            foreach (var telefono in Telefoni)
            {
                Marche.Add(new SelectListItem { Value = telefono.Marca, Text = telefono.Marca });
            }

            Marche = Marche.Distinct().ToList();

            if(MarcaSelezionata != "Qualunque")
            {
                Telefoni = Telefoni.Where(i => i.Marca == MarcaSelezionata).ToList();
            }
            else
            {
                Telefoni = await _context.Telefoni.ToListAsync();
                switch (fasciadiprezzoselezionata)
                {
                    case 0:
                        Telefoni = await _context.Telefoni.ToListAsync();
                        break;
                    case 1:
                        Telefoni = Telefoni.Where(i => i.Prezzo_di_vendita < 150).ToList();
                        break;

                    case 2:
                        Telefoni = Telefoni.Where(i => i.Prezzo_di_vendita > 150 && i.Prezzo_di_vendita < 300).ToList();
                        break;

                    case 3:
                        Telefoni = Telefoni.Where(i => i.Prezzo_di_vendita > 300 && i.Prezzo_di_vendita < 500).ToList();
                        break;

                    case 4:
                        Telefoni = Telefoni.Where(i => i.Prezzo_di_vendita > 500).ToList();
                        break;
                }
            }
            

        }

    }
}
