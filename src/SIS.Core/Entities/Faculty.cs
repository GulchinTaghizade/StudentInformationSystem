using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
    public class Faculty : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FacultyNo { get; set; }


        public ICollection<Student>? Students {get;set;}
        public ICollection<Speciality>? Specialities { get; set; }
    }
}

