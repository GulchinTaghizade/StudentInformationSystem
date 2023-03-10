using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
	public class GroupCourse:IEntity
	{
        public int Id { get ; set; }
        public Group? Group { get; set; }
        public int GroupId { get; set; }
        public Course? Course { get; set; }
        public int CourseId { get; set; }
    }
}

