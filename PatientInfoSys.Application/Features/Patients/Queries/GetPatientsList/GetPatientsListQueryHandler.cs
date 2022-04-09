using AutoMapper;
using MediatR;
using System;
using PatientInfoSys.Application.Contracts;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PatientInfoSys.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQueryHandler : IRequestHandler<GetPatientsListQuery, List<GetPatientsListViewModel>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetPatientsListQueryHandler(IPatientRepository patientRepository,IMapper mapper)
        {
            this._patientRepository = patientRepository;
            this._mapper = mapper;
        }

        public async Task<List<GetPatientsListViewModel>> Handle(GetPatientsListQuery request, CancellationToken cancellationToken)
        {
            var allPatients = await _patientRepository.getAllPatientsAsync();
            return _mapper.Map<List<GetPatientsListViewModel>>(allPatients);
        }
    }
}
