using System;
using FluentValidation;
using SIS.Business.DTOs.StudentDtos;

namespace SIS.Business.Validators.Students
{
	public class StudentPostDtoValidator:AbstractValidator<StudentPostDto>
	{
		public StudentPostDtoValidator()
		{
            RuleFor(s => s.NationalId).
                NotEmpty().
                WithMessage("NationalId is required").
                NotNull().
                WithMessage("NationalId is required").
                MaximumLength(15).
                WithMessage("Max Length : 15");
            RuleFor(s => s.Name).
                NotEmpty().
                WithMessage("Name is required").
                NotNull().
                WithMessage("Name is required").
                MaximumLength(100).
                WithMessage("Max Length : 100");
            RuleFor(s => s.Surname).
               NotEmpty().
               WithMessage("Surname is required").
               NotNull().
               WithMessage("Surname is required").
               MaximumLength(100).
               WithMessage("Max Length : 100");
            RuleFor(s => s.FatherName).
               NotEmpty().
               WithMessage("FatherName is required").
               NotNull().
               WithMessage("FatherName is required").
               MaximumLength(100).
               WithMessage("Max Length : 100");
            RuleFor(s => s.BirthDate).
               NotEmpty().
               WithMessage("BirthDate is required").
               NotNull().
               WithMessage("BirthDate is required");
            RuleFor(s => s.Address).
               NotEmpty().
               WithMessage("Address is required").
               NotNull().
               WithMessage("Address is required").
               MaximumLength(200).
               WithMessage("Max Length : 200");
            RuleFor(s => s.Phone).
               NotEmpty().
               WithMessage("Phone is required").
               NotNull().
               WithMessage("Phone is required").
               MaximumLength(25).
               WithMessage("Max Length : 25");
            RuleFor(s => s.Email).
               NotEmpty().
               WithMessage("Email is required").
               NotNull().
               WithMessage("Email is required").
               MaximumLength(100).
               WithMessage("Max Length : 100").
               EmailAddress();
            RuleFor(s => s.EducationalLevel).
              NotEmpty().
              WithMessage("EducationalLevel is required").
              NotNull().
              WithMessage("EducationalLevel is required").
              MaximumLength(25).
              WithMessage("Max Length : 25");
            RuleFor(s => s.EducationalLanguage).
               NotEmpty().
               WithMessage("EducationalLanguage is required").
               NotNull().
               WithMessage("EducationalLanguage is required").
               MaximumLength(25).
              WithMessage("Max Length : 25");
            RuleFor(s => s.GroupId).
               NotEmpty().
               WithMessage("GroupName is required").
               NotNull().
               WithMessage("GroupName is required");
            RuleFor(s => s.FacultyId).
               NotEmpty().
               WithMessage("FacultyId is required").
               NotNull().
               WithMessage("FacultyId is required");
            RuleFor(s => s.SpecialityId).
               NotEmpty().
               WithMessage("SpecialityId is required").
               NotNull().
               WithMessage("SpecialityId is required");
            RuleFor(s => s.YearOfStudy).
               NotEmpty().
               WithMessage("YearOfStudy is required").
               NotNull().
               WithMessage("YearOfStudy is required").
               MaximumLength(25).
               WithMessage("Max Length : 25");
            RuleFor(s => s.GPA).
               NotEmpty().
               WithMessage("GPA is required").
               NotNull().
               WithMessage("GPA is required");
        }
    }
}

