using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInfoSys.Application.Features.Commands.CreatePatient;
using PatientInfoSys.Application.Features.Commands.DeletePatient;
using PatientInfoSys.Application.Features.Commands.UpdatePatient;
using PatientInfoSys.Application.Features.Patients.Queries.GetPatientsList;
using PatientInfoSys.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;

namespace PatientInfoSys.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        

        [HttpGet("AllPatients",Name = "GetPatientsList")]
        public async Task<ActionResult<List<GetPatientsListViewModel>>> GetPatientsList(int page = 1, int itemsPP = 10, int? fileNo = null, string? name = null, string? phoneNumber = null)
        {
            var dtos = await _mediator.Send(new GetPatientsListQuery());
            var paginationData = new PaginationData(dtos.Count, page, itemsPP);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationData));
            Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");

            var items = dtos.Where(p => (string.IsNullOrEmpty(phoneNumber) || p.phoneNumber.Contains(phoneNumber)) && (string.IsNullOrEmpty(name) || p.name.ToLower() == name) && (fileNo == null || p.fileNo == fileNo)).Skip((page - 1) * itemsPP).Take(itemsPP).ToList();
            return Ok(items);
        }

        [HttpPost("AddPatient",Name = "AddPatient")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePatientCommand createPatientCommand)
        {
            Guid id = await _mediator.Send(createPatientCommand);
            return Ok(id);
        }

        [HttpPut("UpdatePatient", Name = "UpdatePatient")]
        public async Task<ActionResult> Update([FromBody] UpdatePatientCommand updatePatientCommand)
        {
            await _mediator.Send(updatePatientCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePatient")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePatientCommand = new DeletePatientCommand() { Id = id };
            await _mediator.Send(deletePatientCommand);
            return NoContent();
        }
    }
}
