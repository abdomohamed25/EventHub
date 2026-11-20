using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHub
{
    public class EventHubContext : DbContext
    {

        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Badge> Badges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organizer>().ToTable("EventOrganizers");

            modelBuilder.Entity<Organizer>().HasOne(o => o.Profile).WithOne(p => p.Organizer).HasForeignKey<OrganizerProfile>(p => p.OrganizerId);

            modelBuilder.Entity<Organizer>().HasMany(o => o.Events).WithOne(e => e.Organizer).HasForeignKey(e => e.OrganizerId);

            modelBuilder.ApplyConfiguration(new BadgeConfiguration());
        }
    }

}

