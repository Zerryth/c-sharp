using Microsoft.EntityFrameworkCore;

namespace DojoLeague.Models
{
    public class DojoLeagueContext : DbContext
    {
        public DojoLeagueContext (DbContextOptions<DojoLeagueContext> options) : base(options) { }

        public DbSet<Ninja> ninjas { get; set; }
        public DbSet<Dojo> dojos { get; set; }
    }
}