using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
    public class CourseSpeciality : IEntity
    {
        public int Id { get; set; }
        public int SpecialityId { get; set; }
        public Speciality? Speciality { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}

