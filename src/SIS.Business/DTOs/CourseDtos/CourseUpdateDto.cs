using System;
namespace SIS.Business.DTOs.CourseDtos
{
	public class CourseUpdateDto
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CourseCode { get; set; }
        public int? Credit { get; set; }
    }
}

