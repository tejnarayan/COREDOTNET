using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scheduler.Model;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Scheduler.Data
{
    public class SchedulerContext : DbContext
    {
       

        public DbSet<Contact> Contacts { get; set; }

        public SchedulerContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            

            modelBuilder.Entity<Contact>()
            .ToTable("Contact");

            modelBuilder.Entity<Contact>()
                .Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Contact>()
                .Property(u => u.LastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Contact>()
                .Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Contact>()
            .Property(u => u.PhoneNumber)
            .HasMaxLength(12)
            .IsRequired();
        }
    }
}
