using System;
using SIS.Core.Entities;
using SIS.DataAccess.Context;
using SIS.DataAccess.Repositories.Interfaces;

namespace SIS.DataAccess.Repositories.Implementations
{
    public class CourseRepository:Repository<Course>,ICourseRepository
    {
        public CourseRepository(AppDbContext context):base(context)
        {
        }
    }
}

