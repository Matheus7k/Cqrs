﻿using CqrsCurso.Domain.Helpers;
using FluentValidation;

namespace CqrsCurso.Domain.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The field {PropertyName} is mandatory");

            RuleFor(x => x.CPF)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("The field {PropertyName} is mandatory")
                .Must(StringHelper.IsCpf).WithMessage("The field {PropertyName} is not valid for {PropertyName}");

            RuleFor(x => x.DateBirth)
                .NotEmpty().WithMessage("The field {PropertyName} is mandatory");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("The field {PropertyName} is not valid").When(x => !string.IsNullOrWhiteSpace(x.Email));
        }
    }
}
