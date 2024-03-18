using ClinicManagerAPI.Entities;
using MediatR;

namespace ClinicManager.Application.Queries.GetIdService
{
    public class GetServiceByIdQuery : IRequest<Service>
    {
        public int ServiceById { get; }
        public GetServiceByIdQuery(int serviceById) 
        {
            ServiceById = serviceById;
        }
    }
}
