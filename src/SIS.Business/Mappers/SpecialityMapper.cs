using System;
using AutoMapper;
using SIS.Business.DTOs.SpecialityDtos;
using SIS.Core.Entities;

namespace SIS.Business.Mappers
{
	public class SpecialityMapper:Profile
	{
		public SpecialityMapper()
		{
			CreateMap<Speciality, SpecialityDto>()
				.ForMember(s => s.Faculty, s => s.MapFrom(f => f.Faculty.Name));
			CreateMap<SpecialityPostDto,Speciality>().ReverseMap();
            CreateMap<SpecialityUpdateDto,Speciality>()
				.ForPath(s=>s.Faculty.Name, s => s.MapFrom(f => f.FacultyName));
        }
    }
}

