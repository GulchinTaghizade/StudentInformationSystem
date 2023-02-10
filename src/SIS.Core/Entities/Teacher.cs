using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
    public class Teacher:IEntity
    {
        public int Id { get ; set; }
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

