using System;
using FluentValidation;
using SIS.Business.DTOs.TeacherDtos;

namespace SIS.Business.Validators.Teachers
{
	public class TeacherPostDtoValidator:AbstractValidator<TeacherPostDto>
	{
		public TeacherPostDtoValidator()
		{
            RuleFor(t => t.NationalId).
               NotEmpty().
               WithMessage("NationalId is required").
               NotNull().
               WithMessage("NationalId is required").
               MaximumLength(15).
               WithMessage("Max Length : 15");
            RuleFor(t => t.Name).
                NotEmpty().
                WithMessage("Name is required").
                NotNull().
                WithMessage("Name is required").
                MaximumLength(100).
                WithMessage("Max Length : 100");
            RuleFor(t => t.Surname).
               NotEmpty().
               WithMessage("Surname is required").
               NotNull().
               WithMessage("Surname is required").
               MaximumLength(100).
               WithMessage("Max Length : 100");
            RuleFor(t => t.FatherName).
               NotEmpty().
               WithMessage("FatherName is required").
               NotNull().
               WithMessage("FatherName is required").
               MaximumLength(100).
               WithMessage("Max Length : 100");
            RuleFor(t => t.BirthDate).
               NotEmpty().
               WithMessage("BirthDate is required").
               NotNull().
               WithMessage("BirthDate is required");
            RuleFor(t => t.Address).
               NotEmpty().
               WithMessage("Address is required").
               NotNull().
               WithMessage("Address is required").
               MaximumLength(200).
               WithMessage("Max Length : 200");
            RuleFor(t => t.Phone).
               NotEmpty().
               WithMessage("Phone is required").
               NotNull().
               WithMessage("Phone is required").
               MaximumLength(25).
               WithMessage("Max Length : 25");
            RuleFor(t => t.Email).
               NotEmpty().
               WithMessage("Email is required").
               NotNull().
               WithMessage("Email is required").
               MaximumLength(100).
               WithMessage("Max Length : 100").
               EmailAddress();
        }
	}
}

