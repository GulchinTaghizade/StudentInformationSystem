using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
	public class Group:IEntity
	{
        public int Id { get ; set ; }
        public string? Name { get; set; }
        public int? MaxStudentCount { get; set; }

        public ICollection<Student>? Students { get; set; }
        public ICollection<GroupCourse>? GroupCourses { get; set; }
    }
}

