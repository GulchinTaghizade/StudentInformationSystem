using System;
using SIS.Business.DTOs.AuthDtos;
using SIS.Core.Entities.Identity;

namespace SIS.Business.HelperServices.Interfaces
{
	public interface ITokenHandlerService
	{
        Task<TokenResponseDto> GetTokenAsync(AppUser user, int minute);
    }
}

