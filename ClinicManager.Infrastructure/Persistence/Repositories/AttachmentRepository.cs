using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public AttachmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Attachment> AddAttachmentAsync(Attachment attachment)
        {
            _appDbContext.Attachments.Add(attachment);
            await _appDbContext.SaveChangesAsync();
            return attachment;
        }

        public async Task DeleteAttachmentAsync(int id)
        {
            var attachment = await _appDbContext.Attachments.FindAsync(id);
            _appDbContext.Attachments.Remove(attachment);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Attachment>> GetAllAttachmentsAsync()
        {
            return await _appDbContext.Attachments.ToListAsync();
        }

        public async Task<Attachment> GetAttachmentByIdAsync(int id)
        {
            return await _appDbContext.Attachments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAttachmentAsync(Attachment attachment)
        {
            try
            {
                var existingAttachment = await _appDbContext.ServicesClinic.FindAsync(attachment.Id);
                if (existingAttachment == null)
                {
                    throw new ArgumentException($"Não foi possível encontrar os anexos com o ID {attachment.Id}");
                }

                // Atualizar apenas as propriedades modificadas
                _appDbContext.Entry(existingAttachment).CurrentValues.SetValues(attachment);

                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível atualizar os anexos!");
            }
        }
    }
}
