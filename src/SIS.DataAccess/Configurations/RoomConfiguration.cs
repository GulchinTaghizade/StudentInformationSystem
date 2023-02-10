using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIS.Core.Entities;

namespace SIS.DataAccess.Configurations
{
	public class RoomConfiguration:IEntityTypeConfiguration<Room>
	{
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(r => r.RoomNo).IsRequired(true);
            builder.Property(r => r.Floor).IsRequired(true);
            builder.Property(r => r.Capacity).IsRequired(true);
        }
    }
}

