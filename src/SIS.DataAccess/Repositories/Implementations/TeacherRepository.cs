using System;
using SIS.Core.Entities;
using SIS.DataAccess.Context;
using SIS.DataAccess.Repositories.Interfaces;

namespace SIS.DataAccess.Repositories.Implementations
{
    public class TeacherRepository:Repository<Teacher>,ITeacherRepository
    {
        public TeacherRepository(AppDbContext context):base(context)
        {
        }
    }
}

