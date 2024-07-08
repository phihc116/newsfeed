using Microsoft.EntityFrameworkCore;
using NewsfeedAPI.Entity;

namespace NewsfeedAPI
{
    public class NewsfeedDbContext(DbContextOptions<NewsfeedDbContext> options) : DbContext(options)
    {
        public DbSet<Newsfeed> Newsfeeds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Newsfeed>().HasData(new Newsfeed()
            {
                Id = 1,
                Description = "Newsfeed Application, data from mysql",
                Name = "Newsfeed API"
            });
        }
    }    
}
