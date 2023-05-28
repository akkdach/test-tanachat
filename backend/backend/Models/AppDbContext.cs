using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class AppDbContext : DbContext
    {

        public DbSet<Product> products { get; set; }
        public DbSet<Stock> stocks { get; set; }
        public DbSet<Order> orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public AppDbContext()
        {

        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        #endregion

    }
}
