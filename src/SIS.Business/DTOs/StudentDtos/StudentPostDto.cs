using System;
using SIS.Core.Entities;

namespace SIS.Business.DTOs.StudentDtos
{
	public class StudentPostDto
	{
        public string? NationalId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? FatherName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
	}
}

