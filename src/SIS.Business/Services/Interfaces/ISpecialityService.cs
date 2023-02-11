using System;
using SIS.Core.Entities;
using System.Linq.Expressions;
using SIS.Business.DTOs.SpecialityDtos;

namespace SIS.Business.Services.Interfaces
{
	public interface ISpecialityService
	{
		Task<List<SpecialityDto>> FindAllAsync();
		Task<List<SpecialityDto>> FindByCondition(Expression<Func<Speciality, bool>> expression);
		Task<SpecialityDto> FindByIdAsync(int id);
		Task CreateAsync(SpecialityPostDto speciality);
		Task UpdateAsync(int id,SpecialityUpdateDto speciality);
		Task Delete(int id);
	}
}

