using ClinicManager.Infrastructure.Persistence;
using ClinicManagerAPI.Entities;
using MediatR;

namespace ClinicManager.Application.Commands.CreateServiceCommand
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUnitOfWork _unitOfWork;

        public CreateServiceCommandHandler(AppDbContext appDbContext, IUnitOfWork unitOfWork)
        {
            _appDbContext = appDbContext;
            _unitOfWork = unitOfWork;
        }
            
        public async Task<Unit> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Service
            {
                Name = request.Name,
                Description = request.Description,
                Value = request.Value,
                Duration = request.Duration,
            };

            _appDbContext.Add(service);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
