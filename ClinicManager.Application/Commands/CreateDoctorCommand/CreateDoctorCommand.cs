using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Commands.CreateDoctorCommand
{
    public class CreateDoctorCommand : IRequest<Unit>
    {
        public CreateDoctorCommand(string name, 
            string surname, 
            DateTime dateOfBirth, 
            string phoneNumber, 
            string email, 
            string cpf, 
            string bloodType, 
            string address, 
            string specialty, 
            string registrationCRM)

        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Cpf = cpf;
            BloodType = bloodType;
            Address = address;
            Specialty = specialty;
            RegistrationCRM = registrationCRM;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string BloodType { get; set; }
        public string Address { get; set; }
        public string Specialty { get; set; }
        public string RegistrationCRM { get; set; }
    }
}
