using Microsoft.EntityFrameworkCore;
using PreVerifica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreVerifica.Data
{
    public class AutomobiliDbContext: DbContext
    {
        public AutomobiliDbContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<Automobile> Automobili { get; set; }
    }
}

