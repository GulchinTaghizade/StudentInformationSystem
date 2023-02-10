using System;
using System.Linq.Expressions;
using AutoMapper;
using SIS.Business.DTOs.SpecialityDtos;
using SIS.Business.Services.Interfaces;
using SIS.Core.Entities;
using SIS.DataAccess.Repositories.Interfaces;

namespace SIS.Business.Services.Implementations
{
	public class SpecialityService:ISpecialityService
	{
        private readonly ISpecialityRepository _specialityrepository;
        private readonly IMapper _mapper;

        public SpecialityService(IMapper mapper, ISpecialityRepository specialityrepository)
        {
            _mapper = mapper;
            _specialityrepository = specialityrepository;
        }


        public Task<List<SpecialityDto>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<SpecialityDto>> FindByCondition(Expression<Func<Speciality, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<SpecialityDto> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(SpecialityPostDto speciality)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, SpecialityDto speciality)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

