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
    public class ServiceClinicConfiguration : IEntityTypeConfiguration<ServiceClinic>
    {
        public void Configure(EntityTypeBuilder<ServiceClinic> builder)
        {
            builder.ToTable("ServiceClinics");

            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Start)
                .IsRequired();

            builder.Property(sc => sc.End)
                .IsRequired();

            builder.Property(sc => sc.HealthInsurance)
                .IsRequired();

            builder.Property(sc => sc.TypeServices)
                .IsRequired();
                        
        }
    }
}
