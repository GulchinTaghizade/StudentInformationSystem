using System;
using AutoMapper;
using SIS.Business.DTOs.FacultyDtos;
using SIS.Core.Entities;

namespace SIS.Business.Mappers
{
	public class FacultyMapper:Profile
	{
		public FacultyMapper()
		{
			CreateMap<FacultyDto,Faculty>().ReverseMap();
			CreateMap<Faculty, FacultyPostDto>().ReverseMap();
		}
	}
}

