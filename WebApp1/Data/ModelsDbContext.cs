using AgenziaFotografica.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp1.Data
{
    public class ModelsDbContext : DbContext
    {
        public ModelsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }

        public DbSet<Modelli> Modelli { get; set; }

        public DbSet<Clienti> Clienti { get; set; }

    }
}
