﻿using ClinicManager.Infrastructure.Persistence.Repositories;
using ClinicManagerAPI.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Queries.GetIdServiceClinic
{
    public class GetServiceClinicByIdQueryHandler : IRequestHandler<GetServiceClinicByIdQuery, ServiceClinic>
    {
        private readonly ServiceClinicRepository _repository;

        public GetServiceClinicByIdQueryHandler(ServiceClinicRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceClinic> Handle(GetServiceClinicByIdQuery request, CancellationToken cancellationToken)
        {
            var serviceClinic = await _repository.GetServiceClinicByIdAsync(request.ServiceClinicId);
            return serviceClinic;
        }
    }
}
