using System;
using FluentValidation;
using SIS.Business.DTOs.RoomDtos;

namespace SIS.Business.Validators.Rooms
{
	public class RoomPostDtoValidator:AbstractValidator<RoomPostDto>
	{
		public RoomPostDtoValidator()
		{
            RuleFor(r => r.RoomNo).
                NotEmpty().
                WithMessage("RoomNo is required").
                NotNull().
                WithMessage("RoomNo is required");
            RuleFor(r => r.Floor).
                NotEmpty().
                WithMessage("Floor is required").
                NotNull().
                WithMessage("Floor is required");
            RuleFor(r => r.Capacity).
                NotEmpty().
                WithMessage("Room capacity is required").
                NotNull().
                WithMessage("Room capacity is required");

        }
	}
}

