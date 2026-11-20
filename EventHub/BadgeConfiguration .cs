using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHub
{
    public class BadgeConfiguration :  IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.HasOne(b => b.Attendee)
                .WithOne(a => a.Badge)
                .HasForeignKey<Badge>(b => b.AttendeeId);

            builder.HasIndex(b => b.BadgeNumber)
                .IsUnique();

            builder.HasIndex(b => b.AttendeeId)
                .IsUnique();

            builder.Property(b => b.Tier)
                .HasConversion<string>();
        }

    }
}
