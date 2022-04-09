using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientInfoSys.Application.Features.Commands.CreatePatient
{
    public class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidator()
        {
            RuleFor(p => p.name).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(p => p.email).EmailAddress();
            RuleFor(p => p.phoneNumber).NotEmpty().NotNull().MaximumLength(14);
            RuleFor(p => p.contactPhone).NotEmpty().NotNull().MaximumLength(14).NotEqual(p => p.phoneNumber);
            RuleFor(p => p.birthDate.Year).NotEmpty().NotNull().LessThanOrEqualTo(DateTime.Now.Year).GreaterThanOrEqualTo(DateTime.Now.Year - 111);
            RuleFor(p => p.firstVisitDate).NotEmpty().NotNull();
            RuleFor(p => p.natinality).NotEmpty().NotNull();
            RuleFor(p => p.gender).IsInEnum();
            
        }
    }
}
