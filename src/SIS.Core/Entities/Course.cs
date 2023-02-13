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

        public ICollection<CourseSpeciality>? CourseSpecialities { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }
        public ICollection<TeacherCourse>? TeacherCourses { get; set; }
        public ICollection<GroupCourse>? GroupCourses { get; set; }
        public ICollection<RoomCourse>? RoomCourses { get; set; }


    }
}

