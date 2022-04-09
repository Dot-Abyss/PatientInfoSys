using AutoMapper;
using PatientInfoSys.Application.Features.Commands.CreatePatient;
using PatientInfoSys.Application.Features.Commands.DeletePatient;
using PatientInfoSys.Application.Features.Commands.UpdatePatient;
using PatientInfoSys.Application.Features.Patients.Queries.GetPatientsList;
using PatientInfoSys.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientInfoSys.Application.Profiles
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patient, CreatePatientCommand>().ReverseMap();
            CreateMap<Patient, DeletePatientCommand>().ReverseMap();
            CreateMap<Patient, UpdatePatientCommand>().ReverseMap();
            CreateMap<Patient, GetPatientsListViewModel>().ReverseMap();
            
        }
    }
}
