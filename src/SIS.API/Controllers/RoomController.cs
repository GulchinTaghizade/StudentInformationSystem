using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIS.Business.DTOs.RoomDtos;
using SIS.Business.Exceptions;
using SIS.Business.Services.Interfaces;
using SIS.Core.Entities;

namespace SIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var rooms=await _roomService.FindAllAsync();
                return Ok(rooms);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception )
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("GetByRoomNo/{roomNo}")]
        public async Task<IActionResult> GetByNumber(int roomNo)
        {
            try
            {
                var rooms = await _roomService.
                    FindByConditionAsync(r => r.RoomNo != null ? r.RoomNo.Equals(roomNo) : false);
                return Ok(rooms);
            }
            catch(FormatException ex)
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

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var room = await _roomService.FindByIdAsync(id);
                return Ok(room);
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

        [HttpPost]
        public async Task<IActionResult> Post(RoomPostDto room)
        {
            try
            {
                await _roomService.CreateAsync(room);
                return Ok("Room successfully created!");
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
        public async Task<IActionResult> Put(int id,RoomDto room)
        {
            try
            {
                await _roomService.UpdateAsync(id,room);
                return Ok("Room is updated");
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
                await _roomService.Delete(id);
                return Ok("Room is deleted");
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
