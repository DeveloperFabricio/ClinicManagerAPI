using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServicesAsync()
        {
            try
            {
                var services = await _serviceRepository.GetAllServicesAsync();
                return Ok(services);
            }
            catch (Exception) 
            {
                return StatusCode(500, $"Erro ao obter todos os serviços!");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceByIdAsync(int id)
        {
            try
            {
                var service = await _serviceRepository.GetServiceByIdAsync(id);
                if(service == null)
                {
                    return NotFound();
                }
                return Ok(service);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Errro ao obter o {id} do serviço");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddServiceAsync(Service service)
        {
            try
            {
                if(service == null)
                {
                    return BadRequest("O serviço enviado está vazio");
                }

                await _serviceRepository.AddServiceAsync(service);
                return Ok(service);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Erro ao criar o serviço!");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServiceAsync(int id, Service service)
        {
            if(id != service.Id)
            {
                return BadRequest("ID do serviço não corresponde ao ID fornecido nos parâmetros!");
            }

            try
            {
                await _serviceRepository.UpdateServiceAsync(service);
                return Ok(service);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Erro ao atualizar o serviço");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceAsync(int id)
        {
            try
            {
                var serviceToDelete = await _serviceRepository.GetServiceByIdAsync(id);
                if (serviceToDelete == null)
                {
                    return NotFound($"Serviço com o ID {id} não encontrado.");
                }

                await _serviceRepository.DeleteServiceAsync(id);
                return Ok(serviceToDelete);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Erro ao excluir o serviço com o ID {id}.");
            }
        }
    }
}
