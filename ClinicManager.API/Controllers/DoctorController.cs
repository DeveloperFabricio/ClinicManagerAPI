using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories.Interface;
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

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
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
        public async Task<IActionResult> GetDoctorByIdAsync(int id)
        {
            try
            {
                var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
                if(doctor == null)
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
        public async Task<IActionResult> AddDoctorAsync(Doctor doctor)
        {
            try
            {
                if(doctor == null)
                {
                    return BadRequest("Os dados fornecidos estão vazios!");
                }

                await _doctorRepository.AddDoctorAsync(doctor);
                return Ok(doctor);
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
