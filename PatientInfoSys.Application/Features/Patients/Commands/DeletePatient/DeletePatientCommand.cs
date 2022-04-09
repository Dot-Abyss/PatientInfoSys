using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientInfoSys.Application.Features.Commands.DeletePatient
{
    public class DeletePatientCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
