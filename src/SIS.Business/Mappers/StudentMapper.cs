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
			CreateMap<Student, StudentDto>()
				.ForMember(s => s.Faculty, s => s.MapFrom(f => f.Faculty.Name))
				.ForMember(s=>s.Speciality,s=>s.MapFrom(s=>s.Speciality.Name))
				.ForMember(s=>s.Group,s=>s.MapFrom(s=>s.Group.Name));
			CreateMap< StudentPostDto, Student>().ReverseMap();
            CreateMap<Student, StudentUpdateDto>().ReverseMap();
        }
    }
}

