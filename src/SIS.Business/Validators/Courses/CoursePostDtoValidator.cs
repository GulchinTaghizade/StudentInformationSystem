using System;
using FluentValidation;
using SIS.Business.DTOs.CourseDtos;

namespace SIS.Business.Validators.Courses
{
	public class CoursePostDtoValidator:AbstractValidator<CoursePostDto>
	{
		public CoursePostDtoValidator()
		{
            RuleFor(c => c.Name).
                NotEmpty().
                WithMessage("Name is required").
                NotNull().
                WithMessage("Name is required").
                MaximumLength(100).
                WithMessage("Max Length : 100");
            RuleFor(c => c.CourseCode).
                NotEmpty().
                WithMessage("CourseCode is required").
                NotNull().
                WithMessage("CourseCode is required").
                MaximumLength(15).
                WithMessage("Max Length : 15");
            RuleFor(c => c.Credit).
                NotEmpty().
                WithMessage("Credit count is required").
                NotNull().
                WithMessage("Credit count is required");

        }
    }
}

