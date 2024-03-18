using ClinicManagerAPI.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Queries.GetIdServiceClinic
{
    public class GetServiceClinicByIdQuery : IRequest<ServiceClinic>
    {
        public int ServiceClinicId { get; }
        public GetServiceClinicByIdQuery(int serviceClinicId)
        {
            ServiceClinicId = serviceClinicId;
        }
    }
}
