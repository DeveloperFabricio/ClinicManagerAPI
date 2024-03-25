using ClinicManagerAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.ViewModels
{
    public class ServiceClinicViewModel
    {
        public ServiceClinicViewModel(int id, 
            int idPatient, 
            int idService, 
            int idDoctor, 
            string healthInsurance, 
            DateTime start, 
            DateTime end, 
            TypeServiceEnum typeServices)

        {
            Id = id;
            IdPatient = idPatient;
            IdService = idService;
            IdDoctor = idDoctor;
            HealthInsurance = healthInsurance;
            Start = start;
            End = end;
            TypeServices = typeServices;
        }

        public int Id { get; set; }
        public int IdPatient { get; set; }
        public int IdService { get; set; }
        public int IdDoctor { get; set; }
        public string HealthInsurance { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TypeServiceEnum TypeServices { get; set; }
    }
}
