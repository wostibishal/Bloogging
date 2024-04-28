using Domain.Bloogging.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Infrastructure.Blogging
{
    public class BlooggingDBContext : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=DESKTOP-GP2SDC5\\SQLEXPRESS01;Database=Blogging;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        public DbSet<User> Users { get; set; }
    }
}


