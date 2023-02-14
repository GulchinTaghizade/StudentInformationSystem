using System;
using FluentValidation;
using SIS.Business.DTOs.GroupDtos;

namespace SIS.Business.Validators.Groups
{
	public class GroupPostDtoValidator:AbstractValidator<GroupPostDto>
	{
		public GroupPostDtoValidator()
		{
            RuleFor(g => g.Name).
                NotEmpty().
                WithMessage("Name is required").
                NotNull().
                WithMessage("Name is required").
                MaximumLength(15).
                WithMessage("Max Length : 15");
            RuleFor(g => g.MaxStudentCount).
                NotEmpty().
                WithMessage("MaxStudentCount is required").
                NotNull().
                WithMessage("MaxStudentCount is required");
        }
    }
}

