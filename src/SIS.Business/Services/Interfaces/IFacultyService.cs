using System;
using System.Linq.Expressions;
using SIS.Business.DTOs.FacultyDtos;
using SIS.Core.Entities;

namespace SIS.Business.Services.Interfaces
{
	public interface IFacultyService
	{
		Task<List<FacultyDto>> FindAllAsync();
		Task<List<FacultyDto>> FindByConditionAsync(Expression<Func<Faculty, bool>> expression);
        Task<FacultyDto> FindById(int id);
		Task CreateAsync(FacultyPostDto faculty);
		Task UpdateAsync(int id,FacultyDto facullty);
		Task Delete(int id);
	}
}

