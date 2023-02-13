using System;
using SIS.Core.Entities;

namespace SIS.Business.DTOs.StudentDtos
{
	public class StudentPostDto
	{
        public string? NationalId { get; set; }
        public long? StudentNo { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? FatherName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? EducationalLevel { get; set; }
        public string? EducationalLanguage { get; set; }
        public string? GroupName { get; set; }
        public string? YearOfStudy { get; set; }
        public decimal? GPA { get; set; }
    }
}

