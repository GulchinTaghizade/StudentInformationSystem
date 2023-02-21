using System;
namespace SIS.Business.DTOs.AuthDtos
{
	public class ResetPasswordDto
	{
        public string? NewPassword { get; set; }
        public string? NewConfirmedPassword { get; set; }
    }
}

