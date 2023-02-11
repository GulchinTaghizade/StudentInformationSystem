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
			CreateMap<Speciality, SpecialityDto>().ForMember(s => s.Faculty, s => s.MapFrom(f => f.Faculty.Name));
			CreateMap<Speciality, SpecialityPostDto>().ReverseMap();
            CreateMap<SpecialityUpdateDto,Speciality>().ForMember(s => s.Faculty.Name, s => s.MapFrom(f => f.Faculty));

        }
    }
}

