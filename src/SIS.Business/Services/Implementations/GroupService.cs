using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SIS.Business.DTOs.FacultyDtos;
using SIS.Business.DTOs.GroupDtos;
using SIS.Business.Exceptions;
using SIS.Business.Services.Interfaces;
using SIS.Core.Entities;
using SIS.DataAccess.Repositories.Interfaces;

namespace SIS.Business.Services.Implementations
{
	public class GroupService:IGroupService
	{
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(IMapper mapper, IGroupRepository groupRepository)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
        }

        public async Task<List<GroupDto>> FindAllAsync()
        {
            var groups = await _groupRepository.FindAll().ToListAsync();
            return _mapper.Map<List<GroupDto>>(groups);
        }

        public async Task<List<GroupDto>> FindbyConditionAsync(Expression<Func<Group, bool>> expression)
        {
            var groups = await _groupRepository.FindByCondition(expression).ToListAsync();
            if (groups is null) throw new NotFoundException("Groups are not found!");
            return _mapper.Map<List<GroupDto>>(groups);

        }

        public async Task<GroupDto> FindById(int id)
        {
            var group = await _groupRepository.FindByIdAsync(id);
            if (group is null)
            {
                throw new NotFoundException("Group is not found!");
            }
            return _mapper.Map<GroupDto>(group);
        }

        public async Task Create(GroupPostDto group)
        {
            var groupToCreate = _mapper.Map<Group>(group);
            await _groupRepository.CreateAsync(groupToCreate);
            await _groupRepository.SaveAsync();
        }

        public async Task Update(int id, GroupDto group)
        {
            if (id != group.Id)
            {
                throw new BadRequestException("Group ID mismatch");
            }
            var groupToUpdate = _groupRepository.
                FindByCondition(g=>g.Id.Equals(group.Id)).First();
            if (groupToUpdate is null)
            {
                throw new NotFoundException("Group is not found");
            }
            var updatedGroup = _mapper.Map<Group>(group);
            _groupRepository.Update(updatedGroup);
            await _groupRepository.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var groupToDelete = await _groupRepository.FindByIdAsync(id);
            if (groupToDelete is null)
            {
                throw new NotFoundException("Group not found");
            }
            _groupRepository.Delete(groupToDelete);
            await _groupRepository.SaveAsync();
        }
    }
}

