using ClinicManager.Infrastructure.Persistence.Repositories;
using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Queries.GetIdService
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, Service>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetServiceByIdQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Service> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
           var service = await _serviceRepository.GetServiceByIdAsync(request.ServiceById);
           return service;
        }
    }
}
