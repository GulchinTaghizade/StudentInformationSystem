using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
                var response=await _authService.RegisterAsync(registerDto);
                return Ok(response);

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

        [HttpGet("[action]")]
        public async Task<IActionResult> ConfirmEmail(string token, string userId)
        {
            try
            {
                await _authService.ConfirmEmail(token, userId);
                return Ok("Email confirmed by user");
            }
            catch (ConfirmationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DuplicateWaitObjectException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                throw;
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


        [HttpPost("[action]")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPassword)
        {
            try
            {
                var response = await _authService.ForgotPasswordAsync(forgotPassword);
                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPasswordAsync(string token, string userId, [FromForm] ResetPasswordDto resetPassword)
        {
            try
            {
                await _authService.ResetPasswordAsync(token, userId, resetPassword);
                return Ok("reset done");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
