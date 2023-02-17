using System;
using SIS.Business.DTOs;
using SIS.Core.Entities;
using System.Linq.Expressions;
using SIS.Business.DTOs.TeacherDtos;

namespace SIS.Business.Services.Interfaces
{
	public interface ITeacherService
	{
        Task<List<TeacherDto>> FindAllAsync();
        Task<List<TeacherDto>> FindByConditionAsync(Expression<Func<Teacher, bool>> expression);
        Task<TeacherDto> FindByIdAsync(int id);
        Task CreateAsync(TeacherPostDto teacher);
        Task UpdateAsync(int id, TeacherUpdateDto teacher);
        Task Delete(int id);
    }
}

