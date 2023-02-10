using System;
using SIS.Core.Entities;

namespace SIS.Business.DTOs
{
	public class StudentDto
	{
        public int Id { get; set; }
        public long? StudentNo { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? FatherName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Email { get; set; }
        public string? Speciality { get; set; }
        public string? Faculty { get; set; }
        public string? EducationalLevel { get; set; }
        public string? GroupName { get; set; }
        public string? YearOfStudy { get; set; }
        public decimal? GPA { get; set; }
    }
}

