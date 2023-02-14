using System;
using AutoMapper;
using SIS.Business.DTOs.CourseDtos;
using SIS.Core.Entities;

namespace SIS.Business.Mappers
{
	public class CourseMapper:Profile
	{
		public CourseMapper()
		{
			CreateMap<CourseDto, Course>().ReverseMap();
			CreateMap<Course, CoursePostDto>().ReverseMap();
		}
	}
}

