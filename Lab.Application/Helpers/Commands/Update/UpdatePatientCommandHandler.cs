using AutoMapper;
using Lab.Application.Contracts;
using Lab.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Lab.Application.Helpers.Commands.Update
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePatientCommandHandler> _logger;
        public UpdatePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper, ILogger<UpdatePatientCommandHandler> logger)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _logger = logger;
        }

        async Task IRequestHandler<UpdatePatientCommand>.Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patientToUpdate = await _patientRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, patientToUpdate, typeof(UpdatePatientCommand), typeof(Patient));
            await _patientRepository.UpdateAsync(patientToUpdate);
            _logger.LogInformation($"{request.Id}");
        }
    }
}
