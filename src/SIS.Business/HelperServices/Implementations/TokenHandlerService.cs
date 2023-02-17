﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SIS.Business.DTOs.AuthDtos;
using SIS.Business.HelperServices.Interfaces;
using SIS.Core.Entities.Identity;

namespace SIS.Business.HelperServices.Implementations
{
	public class TokenHandlerService:ITokenHandlerService
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public TokenHandlerService(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<TokenResponseDto> GetTokenAsync(AppUser user, int minute)
        {
            List<Claim> claims = new()
             {
                 new Claim(ClaimTypes.Name, user.UserName),
                 new Claim(ClaimTypes.NameIdentifier, user.Id),
                 new Claim(ClaimTypes.Email, user.Email)
             };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(minute),
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new();
            string token = tokenHandler.WriteToken(jwtSecurityToken);
            return new()
            {
                Token = token,
                Expires = jwtSecurityToken.ValidTo,
                UserName = user.UserName
            };
        }
    }
}

