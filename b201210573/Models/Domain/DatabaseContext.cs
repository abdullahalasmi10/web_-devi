using B201210597.Models.DTO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace B201210597.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        internal IEnumerable<koafor> koafor;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
		public DbSet<Department> Departments { get; set; }

        public DbSet<SonRandevu> Randevular{ get; set; }

        public DbSet<salon> salons { get; set; }
        public DbSet<koafor> koafors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Kullanici> Kullaniciler { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {





            modelBuilder.Entity<salon>()
                .HasOne(c => c.Department)
                .WithMany(d => d.salons)
                .HasForeignKey(c => c.DepartmentId);

            modelBuilder.Entity<koafor>()
                .HasOne(d => d.salon)
                .WithMany(c => c.koafors)
                .HasForeignKey(d => d.salonId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Kullanici)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.KullaniciId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Koafor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.koaforId);





            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>();


        }

    }
}