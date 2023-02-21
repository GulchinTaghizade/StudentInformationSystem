using System;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SIS.Business.DTOs.AuthDtos;
using SIS.Business.Exceptions;
using SIS.Business.HelperServices.Interfaces;
using SIS.Business.Services.Interfaces;
using SIS.Core.Entities.Identity;
using SIS.Core.Enums;

namespace SIS.Business.Services.Implementations
{
	public class AuthService:IAuthService
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenHandlerService _tokenHandler;

        public AuthService(UserManager<AppUser> userManager
            , IConfiguration configuration
            , ITokenHandlerService tokenHandler)
        {
            _userManager = userManager;
            _configuration = configuration;
            _tokenHandler = tokenHandler;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            var isExist = await _userManager.FindByEmailAsync(registerDto.Email);
            if (isExist != null)
            {
                throw new RecordDublicatedException("This email already registered.Please try with another email.");
            }

            AppUser user = new()
            {
                Fullname = registerDto.Fullname,
                UserName = registerDto.Username,
                Email = registerDto.Email,
                EmailConfirmed = false
            };

            var identityResult = await _userManager.CreateAsync(user, registerDto.Password);
            if (!identityResult.Succeeded)
            {
                string errors = String.Empty;
                int count = 0;
                foreach (var error in identityResult.Errors)
                {
                    errors += count != 0 ? $", {error.Description}" : $"{error.Description}";
                    count++;
                }
                throw new UserCreateFailureException(errors);
            }

            var result = await _userManager.AddToRoleAsync(user, Roles.Member.ToString());
            if (!result.Succeeded)
            {
                string errors = String.Empty;
                int count = 0;
                foreach (var error in result.Errors)
                {
                    errors += count != 0 ? $", {error.Description}" : $"{error.Description}";
                    count++;
                }
                throw new RoleCreateFailureException(errors);
            }

            var token = HttpUtility.UrlEncode(await _userManager.GenerateEmailConfirmationTokenAsync(user));
            return new AuthResponseDto()
            {
                Token = token,
                ExpireDate = DateTime.UtcNow.AddMinutes(10),
                Username = user.UserName,
                UserId = user.Id,
                Email = user.Email
            };
        }

        public async Task ConfirmEmail(string token, string userId)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(userId))
            {
                throw new BadRequestException("Token or UserId is invalid");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user.EmailConfirmed == true)
            {
                throw new RecordDublicatedException("This email already confirmed!");
            }
            var decodeToken = HttpUtility.UrlDecode(token);
            var result = await _userManager.ConfirmEmailAsync(user, decodeToken);
            if (!result.Succeeded)
            {
                throw new ConfirmationException("Email didn't confirmed!");
            }

        }

        public async Task<TokenResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user is null) throw new AuthFailException("UserName or password is not correct!");
            if (user.EmailConfirmed == false)  throw new ConfirmationException("This account didn't confirmed yet");
            var check = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!check) throw new AuthFailException("UserName or password is not correct!");

            //Create JWT
            var TokenResponse = await _tokenHandler.GetTokenAsync(user, 1);
            return TokenResponse;
        }

        public async Task<AuthResponseDto> ForgotPasswordAsync(ForgotPasswordDto forgotPassword)
        {
            var user = await _userManager.FindByEmailAsync(forgotPassword.EmailOrUsername);
            if (user is null)
            {
                user = await _userManager.FindByNameAsync(forgotPassword.EmailOrUsername);
            }

            if (user is null) throw new NotFoundException("There is not exist any account for this email/username");

            var token = HttpUtility.UrlEncode(await _userManager.GeneratePasswordResetTokenAsync(user));
            return new AuthResponseDto
            {
                Token = token,
                Email = user.Email,
                ExpireDate = DateTime.UtcNow.AddMinutes(10),
                UserId = user.Id,
                Username = user.UserName
            };
        }

        public async Task ResetPasswordAsync(string token, string userId, ResetPasswordDto resetPassword)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token)) throw new AuthFailException("token or user id is empty");
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) throw new NotFoundException("User not found");
            var decodeToken = HttpUtility.UrlDecode(token);
            var identityResult = await _userManager.ResetPasswordAsync(user, decodeToken, resetPassword.NewPassword);
            if (!identityResult.Succeeded) throw new BadRequestException("Password couldn't reset!");
        }

    }
}

