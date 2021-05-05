using Microsoft.EntityFrameworkCore;

namespace Bolis.Data
{
    public class EventiDbContext : DbContext
    {
        public EventiDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}

