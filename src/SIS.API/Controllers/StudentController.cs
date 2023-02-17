using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIS.Business.DTOs.StudentDtos;
using SIS.Business.Exceptions;
using SIS.Business.Services.Interfaces;

namespace SIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var students = await _studentService.FindAllAsync();
                return Ok(students);
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
                var students = await _studentService
                    .FindByConditionAsync(s=>s.Name != null ? s.Name.Contains(name) : true);
                return Ok(students);
            }
            catch(NotFoundException ex)
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
                var student = await _studentService.FindByIdAsync(id);
                return Ok(student);
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
        public async Task<IActionResult> Post(StudentPostDto student)
        {
            try
            {
                await _studentService.CreateAsync(student);
                return Ok("Student successfully created.");
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
        public async Task<IActionResult> Put(int id, StudentUpdateDto student)
        {
            try
            {
                await _studentService.UpdateAsync(id, student);
                return Ok("Student successfully updated.");
            }
            catch (NotFoundException ex)
            {
                return  NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _studentService.Delete(id);
                return Ok("Student successfully deleted.");
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
