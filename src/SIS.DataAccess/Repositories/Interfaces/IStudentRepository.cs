using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SIS.Core.Entities;

namespace SIS.DataAccess.Repositories.Interfaces
{
    public interface IStudentRepository:IRepository<Student>
    {

    }
}

