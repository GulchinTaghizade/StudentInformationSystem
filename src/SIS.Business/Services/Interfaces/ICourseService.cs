using System;
using System.Linq.Expressions;
using SIS.Business.DTOs.CourseDtos;
using SIS.Core.Entities;

namespace SIS.Business.Services.Interfaces
{
	public interface ICourseService
	{
		Task<List<CourseDto>> FindAllAsync();
		Task<List<CourseDto>> FindByConditionAsync(Expression<Func<Course, bool>> expression);
		Task<CourseDto> FindById(int id);
		Task CreateAsync(CoursePostDto course);
		Task Update(int id,CourseUpdateDto course);
		Task Delete(int id);
	}
}

