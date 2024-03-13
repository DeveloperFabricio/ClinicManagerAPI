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
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.Surname)
                .IsRequired();

            builder.Property(p => p.DateOfBirth)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .IsRequired();

            builder.Property(p => p.Email)
                .IsRequired();

            builder.Property(p => p.Cpf)
                .IsRequired();

            builder.Property(p => p.BloodType)
                .IsRequired();

            builder.Property(p => p.Height)
                .IsRequired();

            builder.Property(p => p.Weight)
                .IsRequired();

            builder.Property(p => p.Address)
                .IsRequired();
        }
    }
}
