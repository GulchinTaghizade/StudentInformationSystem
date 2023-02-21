using System;
namespace SIS.Business.DTOs.AuthDtos
{
	public class AuthResponseDto
	{
        public string? Token { get; set; }
        public DateTime? ExpireDate { get; set; }

        public string? Username { get; set; }

        public string? UserId { get; set; }
        public string? Email { get; set; }
    }
}

