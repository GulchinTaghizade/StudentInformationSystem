using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
    public class Faculty:IEntity
    {
        public int Id { get ; set ; }
        public string? Name { get; set; }
        public string? FacultyNo { get; set; }

    }
}

