using System;
using SIS.Core.Entities;
using SIS.DataAccess.Context;
using SIS.DataAccess.Repositories.Interfaces;

namespace SIS.DataAccess.Repositories.Implementations
{
    public class SpecialityRepository:Repository<Speciality>,ISpecialityRepository
    {
        public SpecialityRepository(AppDbContext context):base (context)
        {
        }
    }
}

