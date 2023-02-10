using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIS.Core.Entities;

namespace SIS.DataAccess.Configurations
{
	public class GroupConfiguration:IEntityTypeConfiguration<Group>
	{
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.Name).IsRequired(true).HasMaxLength(15);
            builder.Property(g => g.MaxStudentCount).IsRequired(true);
        }
    }
}

