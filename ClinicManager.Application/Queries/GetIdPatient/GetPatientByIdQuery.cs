using ClinicManagerAPI.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Queries.GetIdPatient
{
    public class GetPatientByIdQuery : IRequest<Patient>
    {
        public int PatientId { get; }

        public GetPatientByIdQuery(int patientId)
        {
            PatientId = patientId;
        }
    }
}
