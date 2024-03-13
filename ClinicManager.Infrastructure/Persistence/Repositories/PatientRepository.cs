using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _appDbContext;

        public PatientRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            _appDbContext.Patients.Add(patient);
            await _appDbContext.SaveChangesAsync();
            return patient;
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _appDbContext.Patients.FindAsync(id);
            _appDbContext.Patients.Remove(patient);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _appDbContext.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientByCpfAsync(string cpf)
        {
            return await _appDbContext.Patients.FirstOrDefaultAsync(p => p.Cpf == cpf);
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _appDbContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Patient> GetPatientByPhoneNumberAsync(string phoneNumber)
        {
            return await _appDbContext.Patients.FirstOrDefaultAsync(p => p.PhoneNumber == phoneNumber);
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            try
            {
                var existingPatient = await _appDbContext.Patients.FindAsync(patient.Id);
                if (existingPatient == null)
                {
                    throw new ArgumentException($"Não foi possível encontrar o paciente com o ID {patient.Id}");
                }

                // Atualizar apenas as propriedades modificadas
                _appDbContext.Entry(existingPatient).CurrentValues.SetValues(patient);

                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível atualizar o paciente!");
            }
        }
    }
}
