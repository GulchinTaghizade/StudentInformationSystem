using System;
using System.Linq.Expressions;
using SIS.Business.DTOs.GroupDtos;
using SIS.Business.DTOs.RoomDtos;
using SIS.Core.Entities;

namespace SIS.Business.Services.Interfaces
{
	public interface IRoomService
	{
		Task<List<RoomDto>> FindAllAsync();
		Task<List<RoomDto>> FindByConditionAsync(Expression <Func<Room,bool>> expression);
		Task<RoomDto> FindByIdAsync(int id);
		Task CreateAsync(RoomPostDto room);
        Task UpdateAsync(int id, RoomDto room);
        Task Delete(int id);
    }
}

