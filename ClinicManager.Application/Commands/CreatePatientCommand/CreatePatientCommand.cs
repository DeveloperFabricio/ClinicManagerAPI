using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Commands.CreatePatientCommand
{
    public class CreatePatientCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string BloodType { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Address { get; set; }
    }
}
