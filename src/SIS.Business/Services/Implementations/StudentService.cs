using System;
using System.Linq.Expressions;
using System.Xml.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SIS.Business.DTOs;
using SIS.Business.DTOs.StudentDtos;
using SIS.Business.Exceptions;
using SIS.Business.Services.Interfaces;
using SIS.Core.Entities;
using SIS.DataAccess.Repositories.Interfaces;

namespace SIS.Business.Services.Implementations
{
	public class StudentService:IStudentService
	{
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentDto>> FindAllAsync()
        {
            var students=await _studentRepository.FindAll().ToListAsync();
            return _mapper.Map<List<StudentDto>>(students);
        }

        public async Task<List<StudentDto>> FindByConditionAsync(Expression<Func<Student, bool>> expression)
        {
            var students = await _studentRepository.FindByCondition(expression).ToListAsync();
            return _mapper.Map<List<StudentDto>>(students);

        }

        public async Task<StudentDto> FindByIdAsync(int id)
        {
            var student = await _studentRepository.FindByIdAsync(id);
            if (student is null)
            {
                throw new NotFoundException("This student does not exist");
            }
            return _mapper.Map<StudentDto>(student);
        }
        public async Task CreateAsync(StudentPostDto student)
        {
           var newStudent=_mapper.Map<Student>(student);
           await _studentRepository.CreateAsync(newStudent);
           await _studentRepository.SaveAsync();
        }

        public async Task UpdateAsync(int id, StudentUpdateDto student)
        {
            if (id!=student.Id)
            {
                throw new BadRequestException("Student ID mismatch");
            }
            var studentToUpdate = _studentRepository.FindByCondition(s=>s.Id.Equals(student.Id)).First();
            if (studentToUpdate is null)
            {
                throw new NotFoundException("Student is not found");
            }
            var updatedStudent=_mapper.Map<Student>(student);
            _studentRepository.Update(updatedStudent);
            await _studentRepository.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var studentToDelete = await _studentRepository.FindByIdAsync(id);
            if (studentToDelete is null)
            {
                throw new NotFoundException("Course is not found");
            }
            _studentRepository.Delete(studentToDelete);
            await _studentRepository.SaveAsync();
        }

    }
}

