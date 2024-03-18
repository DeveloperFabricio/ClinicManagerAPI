using ClinicManager.Infrastructure.Persistence.Repositories;
using ClinicManagerAPI.Entities;
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
        private readonly ServiceRepository _serviceRepository;

        public GetServiceByIdQueryHandler(ServiceRepository serviceRepository)
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
