using System;
namespace SIS.Business.DTOs.AuthDtos
{
	public class TokenResponseDto
	{
        public string? Token { get; set; }
        public DateTime Expires { get; set; }
        public string? UserName { get; set; }
    }
}

