using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIS.Core.Entities;

namespace SIS.DataAccess.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.NationalId).IsRequired(true).HasMaxLength(15);
            builder.Property(s => s.StudentNo).IsRequired(true).HasMaxLength(100);
            builder.Property(s => s.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(s => s.Surname).IsRequired(true).HasMaxLength(100);
            builder.Property(s => s.FatherName).IsRequired(true).HasMaxLength(100);
            builder.Property(s => s.BirthDate).IsRequired(true);
            builder.Property(s => s.Address).IsRequired(true).HasMaxLength(200);
            builder.Property(s => s.Phone).IsRequired(true).HasMaxLength(25);
            builder.Property(s => s.Email).IsRequired(true).HasMaxLength(100);
            builder.Property(s => s.FacultyId).IsRequired(true);
            builder.Property(s => s.SpecialityId).IsRequired(true);
            builder.Property(s => s.EducationalLanguage).IsRequired(true).HasMaxLength(25);
            builder.Property(s => s.EducationalLevel).IsRequired(true).HasMaxLength(25);
            builder.Property(s => s.Id).IsRequired(true);
            builder.Property(s => s.YearOfStudy).IsRequired(true);
            builder.Property(s => s.GPA).IsRequired(true);

        }
    }
}

