using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.Blogging
{

    public class BloggingDbContext : DbContext
    {
        public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= DESKTOP-GP2SDC5\\SQLEXPRESS01; Database =Blogging; Trusted_Connection=True; TrustServerCertificate=True; MultiplActiveResultSets =True");
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        
    }
}

