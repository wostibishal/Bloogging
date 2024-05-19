using Domain;
using Domain.Entity;
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

        
        public DbSet<Blogging> Blogs { get; set; }
        public DbSet<BlogHistory> BlogsHistories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentHistory> CommentHistories { get; set; }
        public DbSet<ReactionBlog> Reactions { get; set; }
        public DbSet<ReactionComment> ReactionComments { get; set; }

    }
}
