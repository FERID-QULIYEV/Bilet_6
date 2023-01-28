using Bilet_6.Models;
using Microsoft.EntityFrameworkCore;

namespace Bilet_6.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Pozition> Pozitions { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
    }
}
