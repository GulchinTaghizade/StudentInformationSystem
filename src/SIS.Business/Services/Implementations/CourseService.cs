
using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SIS.Business.DTOs.CourseDtos;
using SIS.Business.Exceptions;
using SIS.Business.Services.Interfaces;
using SIS.Core.Entities;
using SIS.DataAccess.Repositories.Implementations;
using SIS.DataAccess.Repositories.Interfaces;

namespace SIS.Business.Services.Implementations
{
	public class CourseService:ICourseService
	{
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseDto>> FindAllAsync()
        {
            var courses=await _courseRepository.FindAll().ToListAsync();
            return _mapper.Map<List<CourseDto>>(courses);
        }

        public async Task<List<CourseDto>> FindByConditionAsync(Expression<Func<Course, bool>> expression)
        {
            var courses = await _courseRepository.FindByCondition(expression).ToListAsync();
            if (courses is null)
            {
                throw new NotFoundException("Course is not found.");
            }
            return _mapper.Map<List<CourseDto>>(courses);
        }

        public async Task<CourseDto> FindById(int id)
        {
            var course = await _courseRepository.FindByIdAsync(id);
            if (course is null)
            {
                throw new NotFoundException("Course is not found.");
            }
            return _mapper.Map<CourseDto>(course);
        }

        public async Task CreateAsync(CoursePostDto course)
        {
            var isExist = await _courseRepository.IsExistAsync(c=>c.CourseCode==course.CourseCode);
            if (isExist)
            {
                throw new RecordDublicatedException("This course is already exist");
            }
            var courseToCreate= _mapper.Map<Course>(course);
            await _courseRepository.CreateAsync(courseToCreate);
            await _courseRepository.SaveAsync();
        }

        public async Task Update(int id, CourseUpdateDto course)
        {
            if (id!=course.Id)
            {
                throw new BadRequestException("Course ID mismatch");
            }
            var courseToUpdate = _courseRepository.FindByCondition(c =>c.Id.Equals(course.Id)).First();
            if (courseToUpdate is null)
            {
                throw new NotFoundException("Course is not found");
            }
            var updatedCourse = _mapper.Map<Course>(course);
            _courseRepository.Update(updatedCourse);
            await _courseRepository.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var courseToDelete = await _courseRepository.FindByIdAsync(id);
            if (courseToDelete is null)
            {
                throw new NotFoundException("Course is not found");
            }
            _courseRepository.Delete(courseToDelete);
            await _courseRepository.SaveAsync();
        }
    }
}

