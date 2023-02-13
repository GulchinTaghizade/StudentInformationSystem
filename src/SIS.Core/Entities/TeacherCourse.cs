using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
    public class TeacherCourse:IEntity
    {
        public int Id { get ; set; }
        public Teacher? Teacher { get; set; }
        public int TeacherId { get; set; }
        public Course? Course { get; set; }
        public int CourseId { get; set; }
    }
}

