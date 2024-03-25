using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.ViewModels
{
    public class DoctorViewModel
    {
        public DoctorViewModel(int id, 
            string name, 
            string surname, 
            string specialty, 
            string registrationCRM)

        {
            Id = id;
            Name = name;
            Surname = surname;
            Specialty = specialty;
            RegistrationCRM = registrationCRM;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Specialty { get; set; }
        public string RegistrationCRM { get; set; }
    }
}
