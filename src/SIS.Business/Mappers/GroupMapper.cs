using System;
using AutoMapper;
using SIS.Business.DTOs.GroupDtos;
using SIS.Core.Entities;

namespace SIS.Business.Mappers
{
	public class GroupMapper:Profile
	{
		public GroupMapper()
		{
			CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<GroupPostDto, Group>().ReverseMap();

        }
    }
}

