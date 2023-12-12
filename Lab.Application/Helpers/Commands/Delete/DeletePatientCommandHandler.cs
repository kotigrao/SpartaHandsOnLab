using AutoMapper;
using Lab.Application.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application.Helpers.Commands.Delete
{
    public class DeletePatientCommandHandler: IRequest<DeletePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeletePatientCommandHandler> _logger;

        public DeletePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper, ILogger<DeletePatientCommandHandler> logger)
        {
            _patientRepository=patientRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByIdAsync(request.Id);

            await _patientRepository.DeleteAsync(patient);
            _logger.LogInformation($"Order {patient.Id} is successfully deleted.");
            return Unit.Value;
        }
    }
}
