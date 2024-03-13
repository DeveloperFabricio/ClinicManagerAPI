using ClinicManager.Infrastructure.Persistence.Configurations;
using ClinicManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClinicManager.Infrastructure.Persistence
{
    public  class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceClinic> ServicesClinic { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
           

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LoginSystemConfiguration());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ServiceClinicConfiguration());

        }

    }
}
