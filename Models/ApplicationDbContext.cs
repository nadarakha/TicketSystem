using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Models;

namespace TicketSystem.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ticket>().HasIndex(u => u.PatientId).IsUnique();
            builder.Entity<Patient>().HasIndex(u => u.Mobile).IsUnique();
            base.OnModelCreating(builder);
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
