using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SwimmingPoolNew.Models;

namespace SwimmingPoolNew.Data
{
    public class SwimmingPoolContext : IdentityDbContext <ApplicationUser>
    {
        public SwimmingPoolContext(DbContextOptions<SwimmingPoolContext> options)
            : base(options)
        {
        }

        public DbSet<SwimmingPoolNew.Models.Student> Student { get; set; } = default!;
        public DbSet<SwimmingPoolNew.Models.Teacher> Teacher { get; set; }
        public DbSet<SwimmingPoolNew.Models.TypeClass> TypeClass { get; set; }
        public DbSet<SwimmingPoolNew.Models.Style> Style { get; set; }
        public DbSet<SwimmingPoolNew.Models.Appointment> Appintments { get; set; }

    }
}
