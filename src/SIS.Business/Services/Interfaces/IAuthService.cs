using System;
using SIS.Business.DTOs.AuthDtos;

namespace SIS.Business.Services.Interfaces
{
	public interface IAuthService
	{
        Task RegisterAsync(RegisterDto registerDto);
        Task<TokenResponseDto> LoginAsync(LoginDto loginDto);
    }
}

