using Microsoft.EntityFrameworkCore;

namespace gettingStartedWithEntity.Models
{
    public class RestauranterContext: DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestauranterContext(DbContextOptions<RestauranterContext> options) : base(options) { }
        public DbSet<Review> reviews { get; set; }

        // public void Add(Review review)
        // {

        // }
    }

}