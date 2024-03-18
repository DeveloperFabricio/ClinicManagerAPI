using ClinicManagerAPI.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Queries.GetIdDoctor
{
    public class GetDoctorByIdQuery : IRequest<Doctor>
    {
        public int DoctorId {  get; }

        public GetDoctorByIdQuery(int doctorId)
        {
            DoctorId = doctorId;
        }
    }
}
