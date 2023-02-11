using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SIS.Business.DTOs.SpecialityDtos;
using SIS.Business.Exceptions;
using SIS.Business.Services.Interfaces;
using SIS.Core.Entities;
using SIS.DataAccess.Repositories.Implementations;
using SIS.DataAccess.Repositories.Interfaces;

namespace SIS.Business.Services.Implementations
{
	public class SpecialityService:ISpecialityService
	{
        private readonly ISpecialityRepository _specialityRepository;
        private readonly IMapper _mapper;

        public SpecialityService(IMapper mapper, ISpecialityRepository specialityRepository)
        {
            _mapper = mapper;
            _specialityRepository = specialityRepository;
        }


        public async Task<List<SpecialityDto>> FindAllAsync()
        {
            var specialities= await _specialityRepository.FindAll().Include(s=>s.Faculty).ToListAsync();
            return _mapper.Map<List<SpecialityDto>>(specialities);
        }

        public async Task<List<SpecialityDto>> FindByCondition(Expression<Func<Speciality, bool>> expression)
        {
            var specialities= await _specialityRepository.FindByCondition(expression).Include(s => s.Faculty).ToListAsync();
            if (specialities is null)
            {
                throw new NotFoundException("Speciality does not exist");
            }
            return _mapper.Map<List<SpecialityDto>>(specialities);
        }

        public async Task<SpecialityDto> FindByIdAsync(int id)
        {
            var speciality = await _specialityRepository.FindByIdAsync(id);
            if (speciality is null)
            {
                throw new NotFoundException("Speciality does not exist");
            }
            return _mapper.Map<SpecialityDto>(speciality);
        }

        public async Task CreateAsync(SpecialityPostDto speciality)
        {
            var newSpeciality= _mapper.Map<Speciality>(speciality);
            await _specialityRepository.CreateAsync(newSpeciality);
            await _specialityRepository.SaveAsync();
        }

        public async Task UpdateAsync(int id, SpecialityUpdateDto speciality)
        {
            if (id!=speciality.Id)
            {
                throw new BadRequestException("Faculty ID mismatch");
            }
            var specialityToUpdate = _specialityRepository
                .FindByCondition(s => s.Id.Equals(speciality.Id)).Include(s=>s.Faculty).First();
            if (specialityToUpdate is null)
            {
                throw new NotFoundException("Faculty is not found!");
            }
            var updatedSpeciality = _mapper.Map<Speciality>(speciality);
            _specialityRepository.Update(updatedSpeciality);
            await _specialityRepository.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var specialityToDelete= await _specialityRepository.FindByIdAsync(id);
            if (specialityToDelete is null)
            {
                throw new NotFoundException("Faculty is not found");
            }
            _specialityRepository.Delete(specialityToDelete);
            await _specialityRepository.SaveAsync();
        }
    }
}

