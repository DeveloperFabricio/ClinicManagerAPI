namespace ClinicManagerAPI.Entities
{
    public class Doctor
    {
       
        public int Id { get; set; }
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
