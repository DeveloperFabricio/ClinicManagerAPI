using ClinicManager.Infrastructure.Persistence.Repositories;
using ClinicManagerAPI.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Queries.GetIdDoctor
{
    public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Doctor>
    {
        private readonly DoctorRepository _repository;

        public GetDoctorByIdQueryHandler(DoctorRepository repository)
        {
            _repository = repository;
        }
        public async Task<Doctor> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _repository.GetDoctorByIdAsync(request.DoctorId);
            return doctor;
        }
    }
}
