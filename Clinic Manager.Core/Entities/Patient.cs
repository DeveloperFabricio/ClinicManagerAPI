using System.Net.Mail;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ClinicManagerAPI.Entities
{
    public class Patient
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set;}
        public string BloodType { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Address { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Surname) || DateOfBirth == default || string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Cpf))
            {
                return false;
            }
            
            return true;
        }

        
    }

    
}
