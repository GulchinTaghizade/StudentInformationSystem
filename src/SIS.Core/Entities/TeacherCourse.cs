using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
    public class TeacherCourse:IEntity
    {
        public int Id { get ; set; }
        public Teacher? Teacher { get; set; }
        public Course? Course { get; set; }
    }
}

