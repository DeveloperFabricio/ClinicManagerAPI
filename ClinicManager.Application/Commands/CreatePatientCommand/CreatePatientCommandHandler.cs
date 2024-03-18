using ClinicManager.Infrastructure.Persistence;
using ClinicManagerAPI.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Commands.CreatePatientCommand
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePatientCommandHandler(AppDbContext appDbContext, IUnitOfWork unitOfWork)
        {
            _appDbContext = appDbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Patient
            {
                Name = request.Name,
                Surname = request.Surname,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Cpf = request.Cpf,
                BloodType = request.BloodType,
                Height = request.Height,
                Weight = request.Weight,
                Address = request.Address,
            };

            _appDbContext.Add(patient);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
