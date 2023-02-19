using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string? NationalId { get; set; }
        public long? StudentNo { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? FatherName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public int? SpecialityId { get; set; }
        public Speciality? Speciality { get; set; }
        public string? EducationalLevel { get; set; }
        public string? EducationalLanguage { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
        public string? YearOfStudy { get; set; }
        public decimal? GPA { get; set; }

        public ICollection<TeacherStudent>? TeacherStudents { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}

