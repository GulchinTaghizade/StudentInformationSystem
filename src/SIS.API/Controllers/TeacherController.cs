using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIS.Business.DTOs.StudentDtos;
using SIS.Business.DTOs.TeacherDtos;
using SIS.Business.Exceptions;
using SIS.Business.Services.Implementations;
using SIS.Business.Services.Interfaces;

namespace SIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var teachers = await _teacherService.FindAllAsync();
                return Ok(teachers);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("getByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var teachers = await _teacherService
                    .FindByConditionAsync(s => s.Name != null ? s.Name.Contains(name) : true);
                return Ok(teachers);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("getByID/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var teacher = await _teacherService.FindByIdAsync(id);
                return Ok(teacher);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(TeacherPostDto teacher)
        {
            try
            {
                await _teacherService.CreateAsync(teacher);
                return Ok("Teacher successfully created.");
            }
            catch (RecordDublicatedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, TeacherUpdateDto teacher)
        {
            try
            {
                await _teacherService.UpdateAsync(id, teacher);
                return Ok("Teacher successfully updated.");
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
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _teacherService.Delete(id);
                return Ok("Teacher successfully deleted.");
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
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
