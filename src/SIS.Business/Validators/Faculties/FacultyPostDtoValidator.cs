using System;
using FluentValidation;
using SIS.Business.DTOs.FacultyDtos;

namespace SIS.Business.Validators.Faculties
{
	public class FacultyPostDtoValidator : AbstractValidator<FacultyPostDto>
	{
		public FacultyPostDtoValidator()
		{
			RuleFor(f=>f.Name).
                NotEmpty().
                WithMessage("Name is required").
                NotNull().
                WithMessage("Name is required").
                MaximumLength(100).
                WithMessage("Max Length : 100");
            RuleFor(f => f.FacultyNo).
                NotEmpty().
                WithMessage("FacultyNo is required").
                NotNull().
                WithMessage("FacultyNo is required").
                MaximumLength(15).
                WithMessage("Max Length : 15");
        }
	}
}

