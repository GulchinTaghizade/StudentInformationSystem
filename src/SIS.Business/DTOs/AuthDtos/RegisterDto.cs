using System;
namespace SIS.Business.DTOs.AuthDtos
{
	public class RegisterDto
	{
        public string? Fullname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}

