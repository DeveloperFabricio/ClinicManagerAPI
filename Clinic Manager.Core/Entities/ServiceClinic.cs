using ClinicManagerAPI.Enums;
using System.Net.Mail;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ClinicManagerAPI.Entities
{
    public class ServiceClinic
    {
       

        public int Id { get; set; }
        public Patient IdPatient { get; set; }
        public Service IdService { get; set; }
        public Doctor IdDoctor { get; set; }
        public string HealthInsurance { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TypeServiceEnum TypeServices { get; set; }

        public bool IsValid()
        {

            if (IdPatient == null || IdService == null || IdDoctor == null || string.IsNullOrEmpty(HealthInsurance))
            {
                return false;
            }

            if (Start >= End)
            {
                return false;
            }

            return true;
        }

        
    }
}
