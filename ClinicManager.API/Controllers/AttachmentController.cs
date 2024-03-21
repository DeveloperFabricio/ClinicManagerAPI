using ClinicManagerAPI.DTO_s;
using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using ClinicManagerAPI.Validators;
using Microsoft.AspNetCore.Authorization;
using ClinicManager.Infrastructure.Persistence;


namespace ClinicManagerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IValidator<AttachmentCreateDTO> _attachmentValidator;
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly AppDbContext _appDbContext;
       

        public AttachmentController(IAttachmentRepository attachmentRepository, 
            AppDbContext appDbContext,
            IValidator<AttachmentCreateDTO> validator)
        {
            _attachmentRepository = attachmentRepository;
            _appDbContext = appDbContext;
            _attachmentValidator = validator;
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attachment>>> GetAllAttachments()
        {
            try
            {
                var attachment = await _attachmentRepository.GetAllAttachmentsAsync();
                return Ok(attachment);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Anexo vazio!");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Attachment>> GetAttachmentByIdAsync(int id)
        {
            try
            {
                var attachment = await _attachmentRepository.GetAttachmentByIdAsync(id);
                if (attachment == null)
                {
                    return NotFound();
                }
                return Ok(attachment);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Não existe anexos cadastrados!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Attachment>> AddAttachmentAsync([FromBody] AttachmentCreateDTO attachmentCreateDTO)
        {
            if (attachmentCreateDTO == null)
            {
                return BadRequest("O DTO de criação de anexo não pode ser nulo.");
            }

            
            var validationResult = await _attachmentValidator.ValidateAsync(attachmentCreateDTO);
            if (!validationResult.IsValid)
            {
               
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var attachment = new Attachment
                {
                    Type = attachmentCreateDTO.Type,
                    FileName = attachmentCreateDTO.FileName,
                    FileData = attachmentCreateDTO.FileData
                };

                _appDbContext.Attachments.Add(attachment);
                await _appDbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAttachmentByIdAsync), new { id = attachment.Id }, attachment);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Erro interno ao adicionar anexo: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttachment(int id, [FromBody] Attachment attachment)
        {
            if (id != attachment.Id)
            {
                return BadRequest();
            }

            _appDbContext.Entry(attachment).State = EntityState.Modified;

            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttachmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttachment(int id)
        {
            var attachment = await _appDbContext.Attachments.FindAsync(id);
            if (attachment == null)
            {
                return NotFound();
            }

            _appDbContext.Attachments.Remove(attachment);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool AttachmentExists(int id)
        {
            return _appDbContext.Attachments.Any(e => e.Id == id);
        }
    }
}
