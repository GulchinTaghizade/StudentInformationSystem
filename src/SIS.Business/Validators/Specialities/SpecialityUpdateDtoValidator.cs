using System;
using FluentValidation;
using SIS.Business.DTOs.SpecialityDtos;

namespace SIS.Business.Validators.Specialities
{
	public class SpecialityUpdateDtoValidator:AbstractValidator<SpecialityUpdateDto>
	{
		public SpecialityUpdateDtoValidator()
		{
            RuleFor(s => s.Name).
                NotEmpty().
                WithMessage("Name is required").
                NotNull().
                WithMessage("Name is required").
                MaximumLength(100).
                WithMessage("Max Length : 100");
            RuleFor(s => s.SpecialityNo).
                NotEmpty().
                WithMessage("SpecialityNo is required").
                NotNull().
                WithMessage("SpecialityNo is required").
                MaximumLength(100).
                WithMessage("Max Length : 100");
            RuleFor(s => s.Faculty).
                NotEmpty().
                WithMessage("SpecialityNo is required").
                NotNull().
                WithMessage("SpecialityNo is required");
        }
	}
}

