using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SIS.Business.DTOs.RoomDtos;
using SIS.Business.Exceptions;
using SIS.Business.Services.Interfaces;
using SIS.Core.Entities;
using SIS.DataAccess.Repositories.Implementations;
using SIS.DataAccess.Repositories.Interfaces;

namespace SIS.Business.Services.Implementations
{
	public class RoomService:IRoomService
	{
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<List<RoomDto>> FindAllAsync()
        {
            var rooms= await _roomRepository.FindAll().ToListAsync();
            return _mapper.Map<List<RoomDto>>(rooms);
        }

        public async Task<List<RoomDto>> FindByConditionAsync(Expression<Func<Room, bool>> expression)
        {
            var rooms = await _roomRepository.FindByCondition(expression).ToListAsync();
            if (rooms is null) throw new NotFoundException("Rooms are not found!");
            return _mapper.Map<List<RoomDto>>(rooms);
        }

        public async Task<RoomDto> FindByIdAsync(int id)
        {
            var room = await _roomRepository.FindByIdAsync(id);
            if (room is null)
            {
                throw new NotFoundException("Room is not found");
            }
            return _mapper.Map<RoomDto>(room);
        }

        public async Task CreateAsync(RoomPostDto room)
        {
            var isExist = await _roomRepository.IsExistAsync(r=>r.RoomNo==room.RoomNo);
            if (isExist)
            {
                throw new RecordDublicatedException("This room is already exist");
            }
            var roomToCreate = _mapper.Map<Room>(room);
            await _roomRepository.CreateAsync(roomToCreate);
            await _roomRepository.SaveAsync();
        }

        public async Task UpdateAsync(int id, RoomDto room)
        {
            if (id!=room.Id)
            {
                throw new BadRequestException("Room Id mismatch");
            }
            var roomToUpdate = _roomRepository.FindByCondition(r => r.Id==room.Id).First();
            if (roomToUpdate is null)
            {
                throw new NotFoundException("Room is not found");
            }
            var updatedRoom =_mapper.Map<Room>(room);
             _roomRepository.Update(updatedRoom);
            await _roomRepository.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var roomToDelete = await _roomRepository.FindByIdAsync(id);
            if (roomToDelete is null)
            {
                throw new NotFoundException("Room is not found");
            }
            _roomRepository.Delete(roomToDelete);
            await _roomRepository.SaveAsync();
        }
    }
}

