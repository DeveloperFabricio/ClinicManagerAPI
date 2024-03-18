using ClinicManager.Infrastructure.Persistence;
using ClinicManager.Infrastructure.Persistence.Repositories;
using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Commands.CreateDoctorCommand
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUnitOfWork _unitOfWork;
        public CreateDoctorCommandHandler(IUnitOfWork unitOfWork, AppDbContext appDbContext)
        {
            _unitOfWork = unitOfWork;
            _appDbContext = appDbContext;
        }
        public async Task<Unit> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = new Doctor
            {
                Name = request.Name,
                Surname = request.Surname,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Cpf = request.Cpf,
                BloodType = request.BloodType,
                Address = request.Address,
                Specialty = request.Specialty,
                RegistrationCRM = request.RegistrationCRM,
            };

            _appDbContext.Add(doctor);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
            
        }
    }
}
