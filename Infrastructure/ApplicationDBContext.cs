using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-GP2SDC5;Database=Blogging;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        }

        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Blogging> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        

    }
}
