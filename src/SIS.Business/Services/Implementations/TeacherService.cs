using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SIS.Business.DTOs;
using SIS.Business.DTOs.StudentDtos;
using SIS.Business.DTOs.TeacherDtos;
using SIS.Business.Exceptions;
using SIS.Business.Services.Interfaces;
using SIS.Core.Entities;
using SIS.DataAccess.Repositories.Implementations;
using SIS.DataAccess.Repositories.Interfaces;

namespace SIS.Business.Services.Implementations
{
	public class TeacherService:ITeacherService
	{
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<List<TeacherDto>> FindAllAsync()
        {
            var teachers = await _teacherRepository.FindAll().ToListAsync();
            return _mapper.Map<List<TeacherDto>>(teachers);
        }

        public async Task<List<TeacherDto>> FindByConditionAsync(Expression<Func<Teacher, bool>> expression)
        {
            var teachers = await _teacherRepository.FindByCondition(expression).ToListAsync();
            return _mapper.Map<List<TeacherDto>>(teachers);
        }

        public async Task<TeacherDto> FindByIdAsync(int id)
        {
            var teacher = await _teacherRepository.FindByIdAsync(id);
            if (teacher is null)
            {
                throw new NotFoundException("This teacher does not exist");
            }
            return _mapper.Map<TeacherDto>(teacher);
        }

        public async Task CreateAsync(TeacherPostDto teacher)
        {
            var isExist = await _teacherRepository.IsExistAsync(t => t.NationalId==teacher.NationalId);
            if (isExist)
            {
                throw new RecordDublicatedException("This teacher is already exist");
            }
            var newTeacher = _mapper.Map<Teacher>(teacher);
            await _teacherRepository.CreateAsync(newTeacher);
            await _teacherRepository.SaveAsync();
        }

        public async Task UpdateAsync(int id, TeacherUpdateDto teacher)
        {
            if (id != teacher.Id)
            {
                throw new BadRequestException("Teacher ID mismatch");
            }
            var teacherToUpdate = _teacherRepository.FindByCondition(s => s.Id.Equals(teacher.Id)).First();
            if (teacherToUpdate is null)
            {
                throw new NotFoundException("Teacher is not found");
            }
            var updatedTeacher = _mapper.Map<Teacher>(teacher);
            _teacherRepository.Update(updatedTeacher);
            await _teacherRepository.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var teacherToDelete = await _teacherRepository.FindByIdAsync(id);
            if (teacherToDelete is null)
            {
                throw new NotFoundException("Teacher is not found");
            }
            _teacherRepository.Delete(teacherToDelete);
            await _teacherRepository.SaveAsync();
        }


    }
}

