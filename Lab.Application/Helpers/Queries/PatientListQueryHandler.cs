using AutoMapper;
using Lab.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application.Helpers.Queries
{
    public class PatientListQueryHandler : IRequestHandler<PatientListQuery, List<PatientDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;
        public PatientListQueryHandler(IPatientRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _patientRepository = repository;
        }
        public async Task<List<PatientDto>> Handle(PatientListQuery query, CancellationToken cancellation)
        {
            var _list = await _patientRepository.GetAllAsync();
            return _mapper.Map<List<PatientDto>>(_list);
        }
    }
}
