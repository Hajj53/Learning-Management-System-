using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace LMS.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for your custom entities
        public DbSet<LmsEntity> LmsEntities { get; set; }

        // Add DbSet for IdentityRole if needed explicitly (optional, for advanced role management)
        public DbSet<IdentityRole> IdentityRoles { get; set; }
    }
}
