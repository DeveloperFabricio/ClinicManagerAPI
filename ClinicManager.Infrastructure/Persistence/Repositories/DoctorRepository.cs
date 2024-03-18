using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            try
            {
                var existingDoctor = await _context.Doctors.FindAsync(doctor.Id);
                if (existingDoctor == null)
                {
                    throw new ArgumentException($"Não foi possível encontrar o médico com o ID {doctor.Id}");
                }

                // Atualizar apenas as propriedades modificadas
                _context.Entry(existingDoctor).CurrentValues.SetValues(doctor);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível atualizar o médico!");
            }
        }

        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        
    }
}
