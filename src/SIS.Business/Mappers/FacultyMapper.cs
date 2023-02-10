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
			CreateMap<Faculty, FacultyDto>().ReverseMap();
			CreateMap<Faculty, FacultyPostDto>().ReverseMap();
		}
	}
}

