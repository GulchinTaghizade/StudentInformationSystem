using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
    public class TeacherStudent : IEntity
    {
        public int Id { get; set; }
        public Teacher? Teacher { get; set; }
        public int TeacherId { get; set; }
        public Student? Student { get; set; }
        public int StudentId { get; set; }
    }
}

