using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
	public class RoomCourse : IEntity
    {
        public int Id { get; set; }
        public Room? Room { get; set; }
        public int RoomId { get; set; }
        public Course? Course { get; set; }
        public int CourseId { get; set; }

    }
}

