using MediatR;
using PatientInfoSys.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientInfoSys.Application.Features.Commands.UpdatePatient
{
    public class UpdatePatientCommand : IRequest
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public int fileNo { get; set; }
        public string citizenId { get; set; }
        public Gender gender { get; set; }
        public string natinality { get; set; }
        public DateTime birthDate { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string contactPerson { get; set; }
        public string contactRelation { get; set; }
        public string contactPhone { get; set; }
        public DateTime firstVisitDate { get; set; }
    }
}
