using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories;
using ClinicManagerAPI.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPatientsAsync()
        {
            try
            {
                var patients = await _patientRepository.GetAllPatientsAsync();
                return Ok(patients);
            }
            catch(Exception)
            {
                return StatusCode(500, $"Erro ao obter todos os pacientes");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientByIdAsync(int id)
        {
            try
            {
                var patient = await _patientRepository.GetPatientByIdAsync(id);
                if (patient == null)
                {
                    return NotFound();
                }
                return Ok(patient);
            }
            catch(Exception)
            {
                return StatusCode(500, $"Erro ao obter o paciente!");
            }
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetPatientByCpf(string cpf)
        {
            try
            {
                var patient = await _patientRepository.GetPatientByCpfAsync(cpf);
                if (patient == null)
                {
                    return NotFound("CPF não existe!");
                }
                return Ok(patient);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Erro ao obter o paciente pelo CPF!");
            }
            
        }

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetPatientByPhoneNumber(string phoneNumber)
        {
            try
            {
                var patient = await _patientRepository.GetPatientByPhoneNumberAsync(phoneNumber);
                if (patient == null)
                {
                    return NotFound("PhoneNumber não existe!");
                }
                return Ok(patient);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Erro ao obter o paciente pelo PhoneNumber!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPatientAsync(Patient patient)
        {
            try
            {
                if(patient == null)
                {
                    return BadRequest("O paciente enviado está vazio!");
                }

                await _patientRepository.AddPatientAsync(patient);
                return Ok(patient);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Não foi possível adicionar o paciente!");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatientAsync(int id, Patient patient)
        {
            if(id != patient.Id)
            {
                return BadRequest("ID do paciente não corresponde ao ID fornecido nos parâmetros!");
            }

            try
            {
                await _patientRepository.UpdatePatientAsync(patient);
                return Ok(patient);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Erro ao atualizar o paciente!");
            }
                
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientAsync(int id)
        {
            try
            {
                var patientToDelete = await _patientRepository.GetPatientByIdAsync(id);
                if (patientToDelete == null)
                {
                    return NotFound($"Paciente com o ID {id} não encontrado.");
                }

                await _patientRepository.DeletePatientAsync(id);
                return Ok(patientToDelete);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Erro ao excluir o paciente com o ID {id}.");
            }
        }
    }
}
