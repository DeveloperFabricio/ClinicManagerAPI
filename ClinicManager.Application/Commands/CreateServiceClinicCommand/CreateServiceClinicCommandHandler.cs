using Clinic_Manager.Core.Exceptions;
using ClinicManager.Infrastructure.Persistence;
using ClinicManager.Infrastructure.Persistence.Repositories;
using ClinicManagerAPI.Entities;
using ClinicManagerAPI.Repositories.Interface;
using MediatR;

namespace ClinicManager.Application.Commands.CreateServiceClinicCommand
{
    public class CreateServiceClinicCommandHandler : IRequestHandler<CreateServiceClinicCommand, Unit>
    {
        private readonly IServiceClinicRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPatientRepository _patientRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IDoctorRepository _doctorRepository;

        public CreateServiceClinicCommandHandler(IServiceClinicRepository repository, 
            IUnitOfWork unitOfWork,
            IPatientRepository patientRepository,
            IServiceRepository serviceRepository,
            IDoctorRepository doctorRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _patientRepository = patientRepository;
            _serviceRepository = serviceRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<Unit> Handle(CreateServiceClinicCommand request, CancellationToken cancellationToken)
        {
            
        var patient = await _patientRepository.GetPatientByIdAsync(request.IdPatient);
        var service = await _serviceRepository.GetServiceByIdAsync(request.IdService);
        var doctor = await _doctorRepository.GetDoctorByIdAsync(request.IdDoctor);

       
        if (patient == null)
            throw new NotFoundException("Patient", request.IdPatient);
        
        if (service == null)
            throw new NotFoundException("Service", request.IdService);
        
        if (doctor == null)
            throw new NotFoundException("Doctor", request.IdDoctor);

        
        var serviceClinic = new ServiceClinic
        {
            IdPatient = patient,
            IdService = service,
            IdDoctor = doctor,
            HealthInsurance = request.HealthInsurance,
            Start = request.Start,
            End = request.End,
            TypeServices = request.TypeServices
        };

        
        await _repository.AddServiceClinicAsync(serviceClinic);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
        }
    }
}
