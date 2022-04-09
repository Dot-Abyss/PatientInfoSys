using AutoMapper;
using MediatR;
using PatientInfoSys.Application.Contracts;
using PatientInfoSys.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatientInfoSys.Application.Features.Commands.UpdatePatient
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public UpdatePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            this._patientRepository = patientRepository;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient = _mapper.Map<Patient>(request);
            await _patientRepository.UpdatePatientAsync(patient);
            return Unit.Value;
        }
    }
}
