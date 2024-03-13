using ClinicManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Infrastructure.Persistence.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired();

            builder.Property(d => d.Surname)
                .IsRequired();

            builder.Property(d => d.DateOfBirth)
                .IsRequired();

            builder.Property(d => d.PhoneNumber)
                .IsRequired();

            builder.Property(d => d.Email)
                .IsRequired();

            builder.Property(d => d.Cpf)
                .IsRequired();

            builder.Property(d => d.BloodType)
                .IsRequired();

            builder.Property(d => d.Address)
                .IsRequired();

            builder.Property(d => d.Specialty)
                .IsRequired();

            builder.Property(d => d.RegistrationCRM)
                .IsRequired();
        }
    }
}
