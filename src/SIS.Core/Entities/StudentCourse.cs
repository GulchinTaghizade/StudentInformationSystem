using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
    public class StudentCourse : IEntity
    {
        public int Id { get; set; }
        public Student? Student { get; set; }
        public int StudentId { get; set; }
        public Course? Course { get; set; }
        public int CourseId { get; set; }
    }
}

