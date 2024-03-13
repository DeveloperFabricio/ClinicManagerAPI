using ClinicManagerAPI.Entities;

namespace ClinicManagerAPI.Repositories.Interface
{
    public interface IAttachmentRepository
    {
        Task<IEnumerable<Attachment>> GetAllAttachmentsAsync();
        Task<Attachment> GetAttachmentByIdAsync(int id);
        Task<Attachment> AddAttachmentAsync(Attachment attachment);
        Task UpdateAttachmentAsync(Attachment attachment);
        Task DeleteAttachmentAsync(int id);
    }
}
