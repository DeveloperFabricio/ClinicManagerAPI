using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceClinicController : ControllerBase
    {
        private readonly IServiceClinicRepository _serviceClinicRepository;
        


        public ServiceClinicController(IServiceClinicRepository serviceClinicRepository)

        {
            _serviceClinicRepository = serviceClinicRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllServiceClinicsAsync()
        {
            try
            {
                var serviceClinic = await _serviceClinicRepository.GetAllServiceClinicsAsync();
                return Ok(serviceClinic);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Erro ao obter os dados fornecidos");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceClinicByIdAsync(int id)
        {
            try
            {
                var serviceClinic = await _serviceClinicRepository.GetServiceClinicByIdAsync(id);
                if (serviceClinic == null)
                {
                    return NotFound();
                }
                return Ok(serviceClinic);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Não existe serviço clinico cadastrado!");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddServiceClinicAsync(ServiceClinic serviceClinic)
        {
            try
            {
                    if (serviceClinic == null)
                    {
                        return BadRequest("O serviço clinico está vazio!");
                    }

                    await _serviceClinicRepository.AddServiceClinicAsync(serviceClinic);
                    return Ok(serviceClinic);
            }
                catch (Exception)
                {
                    return StatusCode(500, $"Erro ao criar o serviço clinico!");
                }
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServiceClinicAsync(int id, ServiceClinic serviceClinic)
        {
            if (id != serviceClinic.Id)
            {
                return BadRequest("ID do serviço clinico não corresponde ao ID fornecido nos parâmetros");
            }

            try
            {
                await _serviceClinicRepository.UpdateServiceClinicAsync(serviceClinic);
                return Ok(serviceClinic);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Erro ao atualizar o serviço clinico!");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceClinicAsync(int id)
        {
            try
            {
                var serviceClinicToDelete = await _serviceClinicRepository.GetServiceClinicByIdAsync(id);
                if (serviceClinicToDelete == null)
                {
                    return NotFound($"Serviço clinico com o ID {id} não encontrado.");
                }

                await _serviceClinicRepository.DeleteServiceClinicAsync(id);
                return Ok(serviceClinicToDelete);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Erro ao excluir o serviço clinico com o ID {id}.");
            }
        
        }
    }
}  
