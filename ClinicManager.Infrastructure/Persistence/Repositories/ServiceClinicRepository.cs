using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class ServiceClinicRepository : IServiceClinicRepository
    {
        private readonly AppDbContext _appDbContext;

        public ServiceClinicRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ServiceClinic> AddServiceClinicAsync(ServiceClinic serviceClinic)
        {
            _appDbContext.ServicesClinic.Add(serviceClinic);
            await _appDbContext.SaveChangesAsync();
            return serviceClinic;
        }

        public async Task DeleteServiceClinicAsync(int id)
        {
            var serviceClinic = await _appDbContext.ServicesClinic.FindAsync(id);
            _appDbContext.ServicesClinic.Remove(serviceClinic);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ServiceClinic>> GetAllServiceClinicsAsync()
        {
            return await _appDbContext.ServicesClinic.ToListAsync();
        }

        public async Task<ServiceClinic> GetServiceClinicByIdAsync(int id)
        {
            return await _appDbContext.ServicesClinic.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateServiceClinicAsync(ServiceClinic serviceClinic)
        {
            try
            {
                var existingServiceClinic = await _appDbContext.ServicesClinic.FindAsync(serviceClinic.Id);
                if (existingServiceClinic == null)
                {
                    throw new ArgumentException($"Não foi possível encontrar o serviço da clinica com o ID {serviceClinic.Id}");
                }

                _appDbContext.Entry(existingServiceClinic).CurrentValues.SetValues(serviceClinic);

                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível atualizar o serviço da clinica!");
            }
        }
    }
}
