using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<FavouriteFood> FavouriteFoods { get; set; }
    }
}
