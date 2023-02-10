using System;
using AutoMapper;
using SIS.Business.DTOs;
using SIS.Business.DTOs.StudentDtos;
using SIS.Core.Entities;

namespace SIS.Business.Mappers
{
	public class StudentMapper:Profile
	{
		public StudentMapper()
		{
			CreateMap<Student, StudentDto>().ReverseMap();
			CreateMap<Student, StudentPostDto>().ReverseMap();
            CreateMap<Student, StudentUpdateDto>().ReverseMap();
        }
    }
}

