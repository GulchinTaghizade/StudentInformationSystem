using System;
using SIS.Core.Entities;
using SIS.DataAccess.Context;
using SIS.DataAccess.Repositories.Interfaces;

namespace SIS.DataAccess.Repositories.Implementations
{
    public class StudentRepository:Repository<Student>,IStudentRepository
    {
        public StudentRepository(AppDbContext context):base(context)
        {
        }
    }
}

