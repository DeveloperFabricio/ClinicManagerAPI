using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Attachment = ClinicManagerAPI.Entities.Attachment;

namespace ClinicManager.Infrastructure.Persistence.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable("Attachments");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Type)
                .IsRequired();

            builder.Property(a => a.FileName)
                .IsRequired();

            builder.Property(a => a.FileData)
                .IsRequired();
        }
    }
}
