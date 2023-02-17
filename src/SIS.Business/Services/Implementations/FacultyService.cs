using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SIS.Business.DTOs.FacultyDtos;
using SIS.Business.Exceptions;
using SIS.Business.Services.Interfaces;
using SIS.Core.Entities;
using SIS.DataAccess.Repositories.Implementations;
using SIS.DataAccess.Repositories.Interfaces;

namespace SIS.Business.Services.Implementations
{
	public class FacultyService:IFacultyService
	{
        private readonly IFacultyRepository _facultyrepository;
        private readonly IMapper _mapper;

        public FacultyService(IFacultyRepository facultyrepository, IMapper mapper)
        {
            _facultyrepository = facultyrepository;
            _mapper = mapper;
        }

        public async Task<List<FacultyDto>> FindAllAsync()
        {
            var faculties = await _facultyrepository.FindAll().ToListAsync();
            return _mapper.Map<List<FacultyDto>>(faculties);
        }

        public async Task<List<FacultyDto>> FindByConditionAsync(Expression<Func<Faculty, bool>> expression)
        {
            var faculties = await _facultyrepository.FindByCondition(expression).ToListAsync();
            if (faculties is null) throw new NotFoundException("Faculties are not found!");
            return _mapper.Map<List<FacultyDto>>(faculties);
        }

        public async Task<FacultyDto> FindByIdAsync(int id)
        {
            var faculty = await _facultyrepository.FindByIdAsync(id);
            if (faculty is null) throw new NotFoundException("Faculty is not found!");
            return _mapper.Map<FacultyDto>(faculty);
        }

        public async Task CreateAsync(FacultyPostDto faculty)
        {
            var isExist = await _facultyrepository.IsExistAsync(f=>f.FacultyNo==faculty.FacultyNo);
            if (isExist)
            {
                throw new RecordDublicatedException("This faculty is already exist");
            }
            var NewFaculty=_mapper.Map<Faculty>(faculty);
            await _facultyrepository.CreateAsync(NewFaculty);
            await _facultyrepository.SaveAsync();
        }

        public async Task UpdateAsync(int id, FacultyDto faculty)
        {
            if (id!=faculty.Id)
            {
                throw new BadRequestException("Faculty ID mismatch");
            }
            var facultyToUpdate = _facultyrepository.FindByCondition(f => f.Id.Equals(faculty.Id)).First();
            if (facultyToUpdate is null)
            {
                throw new NotFoundException("Faculty is not found!");
            }
            var updatedFaculty=_mapper.Map<Faculty>(faculty);
             _facultyrepository.Update(updatedFaculty);
            await _facultyrepository.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var facultyToDelete = await _facultyrepository.FindByIdAsync(id);
            if (facultyToDelete is null)
            {
                throw new NotFoundException("Faculty is not found");
            }
            _facultyrepository.Delete(facultyToDelete);
            await _facultyrepository.SaveAsync();
        }

    }
}

