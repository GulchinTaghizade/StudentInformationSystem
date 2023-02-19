using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
    public class Speciality:IEntity
    {
        public int Id { get ; set ; }
        public string? Name { get; set; }
        public string? SpecialityNo { get; set; }
        public int? FacultyId { get; set; }
        public Faculty? Faculty { get; set; }

        public ICollection<Student>? Students { get; set; }
        public ICollection<CourseSpeciality>? CourseSpecialities { get; set; }

    }
}

