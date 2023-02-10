using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIS.Core.Entities;

namespace SIS.DataAccess.Configurations
{
    public class SpecialityConfiguration:IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.Property(s => s.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(s => s.SpecialityNo).IsRequired(true).HasMaxLength(100);
            builder.Property(s => s.Faculty).IsRequired(true);
        }
    }
}

