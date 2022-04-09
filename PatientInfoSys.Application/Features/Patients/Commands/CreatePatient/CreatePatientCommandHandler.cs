using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PatientInfoSys.Application.Contracts;
using PatientInfoSys.Domain;

namespace PatientInfoSys.Application.Features.Commands.CreatePatient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public CreatePatientCommandHandler(IPatientRepository patientRepository,IMapper mapper)
        {
            this._patientRepository = patientRepository;
            this._mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient = _mapper.Map<Patient>(request);
            CreatePatientValidator validator = new CreatePatientValidator();
            var result = await validator.ValidateAsync(request);
            if (result.Errors.Any())
            {
                throw new Exception("Patient is not Valid");
            }
            patient = await _patientRepository.AddAsync(patient);
            return patient.Id;
        }
    }
}
