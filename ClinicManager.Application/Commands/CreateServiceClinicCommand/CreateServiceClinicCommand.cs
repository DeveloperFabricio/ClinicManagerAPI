using ClinicManagerAPI.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Commands.CreateServiceClinicCommand
{
    public class CreateServiceClinicCommand : IRequest<Unit>
    {
        public CreateServiceClinicCommand(int idPatient, 
            int idService, 
            int idDoctor, 
            string healthInsurance, 
            DateTime start, 
            DateTime end, 
            TypeServiceEnum typeServices)

        {
            IdPatient = idPatient;
            IdService = idService;
            IdDoctor = idDoctor;
            HealthInsurance = healthInsurance;
            Start = start;
            End = end;
            TypeServices = typeServices;
        }

        public int IdPatient { get; set; }
        public int IdService { get; set; }
        public int IdDoctor { get; set; }
        public string HealthInsurance { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TypeServiceEnum TypeServices { get; set; }
    }
}
