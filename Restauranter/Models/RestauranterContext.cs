using Microsoft.EntityFrameworkCore;

namespace Restauranter.Models
{
    public class RestauranterContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestauranterContext(DbContextOptions<RestauranterContext> options) : base(options) { }

        public DbSet<Review> Reviews { get; set; }
    }
}