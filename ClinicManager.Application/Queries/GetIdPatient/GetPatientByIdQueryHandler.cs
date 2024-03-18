﻿using ClinicManager.Infrastructure.Persistence.Repositories;
using ClinicManagerAPI.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Queries.GetIdPatient
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Patient>
    {
        private readonly PatientRepository _patientRepository;

        public GetPatientByIdQueryHandler(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(request.PatientId);
            return patient;
        }
    }
}
