using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace QuoteBank2.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<QuotesTBL> QuotesTBLs { get; set; }
        public DbSet<AuthorsTBL> AuthorsTBLs { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}