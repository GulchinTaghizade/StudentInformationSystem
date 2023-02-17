using System;
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

        public async Task RegisterAsync(RegisterDto registerDto)
        {
            AppUser user = new()
            {
                Fullname = registerDto.Fullname,
                UserName = registerDto.Username,
                Email = registerDto.Email
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
        }

        public async Task<TokenResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user is null) throw new AuthFailException("UserName or password is not correct!");

            var check = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!check) throw new AuthFailException("UserName or password is not correct!");

            //Create JWT
            var TokenResponse = await _tokenHandler.GetTokenAsync(user, 1);
            return TokenResponse;
        }
    }
}

