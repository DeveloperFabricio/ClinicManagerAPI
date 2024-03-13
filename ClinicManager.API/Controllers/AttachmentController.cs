﻿using ClinicManagerAPI.DTO_s;
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
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly AppDbContext _appDbContext;
       

        public AttachmentController(IAttachmentRepository attachmentRepository, 
            AppDbContext appDbContext,
            IValidator<AttachmentCreateDTOValidator> validatorRules)
        {
            _attachmentRepository = attachmentRepository;
            _appDbContext = appDbContext;
            
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
            var attachment = new Attachment
            {
                Type = attachmentCreateDTO.Type,
                FileName = attachmentCreateDTO.FileName,
                FileData = attachmentCreateDTO.FileData
            };

            _appDbContext.Attachments.Add(attachment);
            await _appDbContext.SaveChangesAsync();

            return attachment;
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
