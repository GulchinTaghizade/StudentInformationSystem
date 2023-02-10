using System;
using System.Linq.Expressions;
using SIS.Business.DTOs;
using SIS.Business.DTOs.StudentDtos;
using SIS.Core.Entities;

namespace SIS.Business.Services.Interfaces
{
	public interface IStudentService
	{
		Task<List<StudentDto>> FindAllAsync();
        Task<List<StudentDto>> FindByConditionAsync(Expression<Func<Student, bool>> expression);
        Task<StudentDto> FindByIdAsync(int id);
		Task CreateAsync(StudentPostDto student);
		Task UpdateAsync(int id, StudentUpdateDto student);
		Task Delete(int id);
	}
}

