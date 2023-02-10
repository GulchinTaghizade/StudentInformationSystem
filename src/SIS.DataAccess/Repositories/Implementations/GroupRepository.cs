using System;
using SIS.Core.Entities;
using SIS.DataAccess.Context;
using SIS.DataAccess.Repositories.Interfaces;

namespace SIS.DataAccess.Repositories.Implementations
{
	public class GroupRepository:Repository<Group>,IGroupRepository
	{
		public GroupRepository(AppDbContext context):base(context)
		{
		}
	}
}

