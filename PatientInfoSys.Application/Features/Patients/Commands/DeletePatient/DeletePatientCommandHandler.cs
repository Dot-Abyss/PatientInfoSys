using MediatR;
using PatientInfoSys.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatientInfoSys.Application.Features.Commands.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public DeletePatientCommandHandler(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }

        public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByIdAsync(request.Id);
            await _patientRepository.DeleteAsync(patient);
            return Unit.Value;
        }
    }
}
