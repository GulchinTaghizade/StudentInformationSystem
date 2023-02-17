using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIS.Business.DTOs.SpecialityDtos;
using SIS.Business.Exceptions;
using SIS.Business.Services.Interfaces;
using SIS.Core.Entities;

namespace SIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityService _specialityService;

        public SpecialityController(ISpecialityService specialityRepository)
        {
            _specialityService = specialityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var specialities= await _specialityService.FindAllAsync();
                return Ok(specialities);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var speciality = await _specialityService.FindByIdAsync(id);
                return Ok(speciality);
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

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var specialities = await _specialityService.FindByCondition(s => s.Name !=null ? s.Name.Contains(name): false);
                return Ok(specialities);
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
        public async Task<IActionResult> Post(SpecialityPostDto speciality)
        {
            try
            {
                await _specialityService.CreateAsync(speciality);
                return Ok("Speciality successfully created");
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
        public async Task<IActionResult> Update(int id, SpecialityUpdateDto speciality)
        {
            try
            {
                await _specialityService.UpdateAsync(id,speciality);
                return Ok("Speciality successfully updated");
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _specialityService.Delete(id);
                return Ok("Speciality successfully deleted");
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }
    }
}
