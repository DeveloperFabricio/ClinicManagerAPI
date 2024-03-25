using ClinicManager.Application.Commands.CreateServiceClinicCommand;
using ClinicManager.Application.Queries.GetIdPatient;
using ClinicManager.Application.Queries.GetIdService;
using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories.Interface;
using MediatR;
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
        private readonly IMediator _mediator;

        public ServiceClinicController(IServiceClinicRepository serviceClinicRepository, IMediator mediator)

        {
            _serviceClinicRepository = serviceClinicRepository;
            _mediator = mediator;
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
        public async Task<IActionResult> GetServiceClinicByIdQuery(int id)
        {
            var query = new GetServiceByIdQuery(id);
            try
            {
                var serviceClinic = await _mediator.Send(query);
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
        public async Task<IActionResult> AddServiceClinicCommand(CreateServiceClinicCommand command)
        {
            try
            {
                    if (command == null)
                    {
                        return BadRequest("O serviço clinico está vazio!");
                    }

                var id = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetServiceClinicByIdQuery), new { id = id }, command);
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
