using System;
using AutoMapper;
using SIS.Business.DTOs.RoomDtos;
using SIS.Core.Entities;

namespace SIS.Business.Mappers
{
	public class RoomMapper:Profile
	{
		public RoomMapper()
		{
			CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Room, RoomPostDto>().ReverseMap();

        }
    }
}

