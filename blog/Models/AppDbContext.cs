using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace blog.Models
{public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
        public DbSet<Blog> Blog { get; set; }
        // public DbSet<BlogAuthor> BlogAuthor { get; set; }
        // public DbSet<BlogPublisher> BlogPublisher { get; set; }
}
}

