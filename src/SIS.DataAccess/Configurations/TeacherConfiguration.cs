using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIS.Core.Entities;

namespace SIS.DataAccess.Configurations
{
    public class TeacherConfiguration:IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(s => s.NationalId).IsRequired(true).HasMaxLength(15);
            builder.Property(s => s.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(s => s.Surname).IsRequired(true).HasMaxLength(100);
            builder.Property(s => s.FatherName).IsRequired(true).HasMaxLength(100);
            builder.Property(s => s.BirthDate).IsRequired(true);
            builder.Property(s => s.Address).IsRequired(true).HasMaxLength(200);
            builder.Property(s => s.Phone).IsRequired(true).HasMaxLength(25);
            builder.Property(s => s.Email).IsRequired(true).HasMaxLength(100);
        }
    }
}

