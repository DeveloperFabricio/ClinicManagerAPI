using ClinicManager.Application.Commands.CreateDoctorCommand;
using ClinicManager.Application.Queries.GetIdServiceClinic;
using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories.Interface;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMediator _mediator;

        public DoctorController(IDoctorRepository doctorRepository, IMediator mediator)
        {
            _doctorRepository = doctorRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GettAllDoctorsAsync()
        {
            try
            {
                var doctors = await _doctorRepository.GetAllDoctorsAsync();
                return Ok(doctors);
            }
            catch(Exception) 
            {
                return StatusCode(500, $"Erro ao obter os dados fornecidos");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorByIdQuery(int id)
        {
            var query = new GetServiceClinicByIdQuery(id);

            try
            {
                var doctor = await _mediator.Send(query);
                if (doctor == null)
                {
                    return NotFound();
                }
                return Ok(doctor);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Erro ao obter os dados fornecidos!");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctorCommand(CreateDoctorCommand command)
        {
            try
            {
                if(command == null)
                {
                    return BadRequest("Os dados fornecidos estão vazios!");
                }

                var id = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetDoctorByIdQuery), new { id = id },command);
            }

            catch (Exception)
            {
                return StatusCode(500, $"Não foi possível adicionar o Doutor!");
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateDoctorAsync(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest("ID não encontrado");
            }
             
                try
                {
                    await _doctorRepository.UpdateDoctorAsync(doctor);
                    return Ok(doctor);
                }
                catch (Exception) 
                { 
                    return StatusCode(500, $"Erro ao Atualizar!");
                }
            
            
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDoctorAsync(int id)
        {
            try
            {
                var doctorToDelete = await _doctorRepository.GetDoctorByIdAsync(id);
                if (doctorToDelete == null)
                {
                    return NotFound($"Médico com o ID {id} não encontrado.");
                }

                await _doctorRepository.DeleteDoctorAsync(id);
                return Ok(doctorToDelete);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Erro ao excluir o médico com o ID {id}.");
            }

        }


    }
}
