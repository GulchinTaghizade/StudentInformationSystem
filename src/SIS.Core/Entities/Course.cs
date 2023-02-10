using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
    public class Course:IEntity
    {
        public int Id { get ; set; }
        public string? Name { get; set; }
        public string? CourseCode { get; set; }
        public int? Credit { get; set; }
    }
}

