using System;
using SIS.Core.Entities;
using SIS.DataAccess.Context;
using SIS.DataAccess.Repositories.Interfaces;

namespace SIS.DataAccess.Repositories.Implementations
{
    public class FacultyRepository:Repository<Faculty>,IFacultyRepository
    {
        public FacultyRepository(AppDbContext context):base (context)
        {
        }
    }
}

