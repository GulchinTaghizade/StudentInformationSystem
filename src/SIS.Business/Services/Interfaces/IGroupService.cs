using System;
using System.Linq.Expressions;
using SIS.Business.DTOs.GroupDtos;
using SIS.Core.Entities;

namespace SIS.Business.Services.Interfaces
{
	public interface IGroupService
	{
		Task<List<GroupDto>> FindAllAsync();
        Task<List<GroupDto>> FindbyConditionAsync(Expression<Func<Group, bool>> expression);
        Task<GroupDto> FindByIdAsync(int id);
        Task CreateAsync(GroupPostDto group);
        Task UpdateAsync(int id, GroupDto group);
        Task Delete(int id);
    }
}

