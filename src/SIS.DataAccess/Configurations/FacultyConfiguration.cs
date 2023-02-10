using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIS.Core.Entities;

namespace SIS.DataAccess.Configurations
{
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.Property(f => f.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(f => f.FacultyNo).IsRequired(true).HasMaxLength(15);
        }
    }
}

