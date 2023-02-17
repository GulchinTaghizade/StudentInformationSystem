using System;
using AutoMapper;
using SIS.Business.DTOs.TeacherDtos;
using SIS.Core.Entities;

namespace SIS.Business.Mappers
{
	public class TeacherMapper:Profile
	{
		public TeacherMapper()
		{
			CreateMap<Teacher, TeacherDto>().ReverseMap();
			CreateMap<TeacherPostDto, Teacher>().ReverseMap();
            CreateMap<TeacherUpdateDto, Teacher>().ReverseMap();

        }
    }
}

