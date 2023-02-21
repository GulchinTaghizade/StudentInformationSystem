using System;
using SIS.Business.DTOs.AuthDtos;

namespace SIS.Business.Services.Interfaces
{
	public interface IAuthService
	{
        Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
        Task ConfirmEmail(string token, string userId);
        Task<TokenResponseDto> LoginAsync(LoginDto loginDto);
        Task<AuthResponseDto> ForgotPasswordAsync(ForgotPasswordDto forgotPassword);
        Task ResetPasswordAsync(string token, string userId, ResetPasswordDto resetPassword);
    }
}

