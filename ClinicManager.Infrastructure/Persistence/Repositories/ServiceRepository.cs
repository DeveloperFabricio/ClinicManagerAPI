using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _appDbContext;

        public ServiceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Service> AddServiceAsync(Service service)
        {
            _appDbContext.Services.Add(service);
            await _appDbContext.SaveChangesAsync();
            return service;
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _appDbContext.Services.FindAsync(id);
            _appDbContext.Services.Remove(service);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _appDbContext.Services.ToListAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _appDbContext.Services.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateServiceAsync(Service service)
        {
            try
            {
                var existingService = await _appDbContext.ServicesClinic.FindAsync(service.Id);
                if (existingService == null)
                {
                    throw new ArgumentException($"Não foi possível encontrar o serviço com o ID {service.Id}");
                }

                _appDbContext.Entry(existingService).CurrentValues.SetValues(service);

                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível atualizar o serviço!");
            }
        }
    }
}
