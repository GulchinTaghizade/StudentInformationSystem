using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIS.Core.Entities;

namespace SIS.DataAccess.Configurations
{
    public class CourseCofiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(c => c.CourseCode).IsRequired(true).HasMaxLength(15);
            builder.Property(c => c.Credit).IsRequired(true);
        }
    }
}

