using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientInfoSys.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQuery : IRequest<List<GetPatientsListViewModel>>
    {
    }
}
