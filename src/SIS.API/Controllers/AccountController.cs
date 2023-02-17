using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIS.Business.DTOs.AuthDtos;
using SIS.Business.Exceptions;
using SIS.Business.Services.Interfaces;

namespace SIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                await _authService.RegisterAsync(registerDto);
                return Ok("User successfully registered");

            }
            catch (UserCreateFailureException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (RoleCreateFailureException)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto logindto)
        {
            try
            {
                var tokenResponse = await _authService.LoginAsync(logindto);
                return Ok(tokenResponse);

            }
            catch (AuthFailException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
