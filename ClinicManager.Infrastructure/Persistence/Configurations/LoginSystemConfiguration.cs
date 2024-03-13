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
    public class LoginSystemConfiguration : IEntityTypeConfiguration<LoginSystem>
    {
        public void Configure(EntityTypeBuilder<LoginSystem> builder)
        {
            builder.ToTable("LoginSystems");

            builder.Property(ls => ls.Login)
                .IsRequired();

            builder.Property(ls => ls.Password)
                .IsRequired();
        }
    }
}
