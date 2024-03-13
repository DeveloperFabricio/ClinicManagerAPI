using ClinicManagerAPI.DTO_s;
using FluentValidation;

namespace ClinicManagerAPI.Validators
{
    public class AttachmentCreateDTOValidator : AbstractValidator<AttachmentCreateDTO>
    {
        public AttachmentCreateDTOValidator()
        {
            RuleFor(dto => dto.Type).NotEmpty().WithMessage("O tipo de anexo é obrigatório.");
            RuleFor(dto => dto.FileName).NotEmpty().WithMessage("O nome do arquivo é obrigatório.");
            RuleFor(dto => dto.FileData).NotEmpty().WithMessage("Os dados do arquivo são obrigatórios.");
        }
    }
}

