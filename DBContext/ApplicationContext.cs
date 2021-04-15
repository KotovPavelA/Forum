﻿using Forum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.DBContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<QSection> QSections { get; set; }
        public DbSet<QSectionAnswer> QSectionAnswers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                    .HasOne(c => c.User)
                    .WithMany(s => s.Messages).HasForeignKey(i => i.UserId);

            modelBuilder.Entity<Message>()
                    .HasOne(c => c.Section)
                    .WithMany(s => s.Messages).HasForeignKey(i=>i.SectionId);

            modelBuilder.Entity<User>()
                    .HasOne(c => c.Role)
                    .WithMany(s => s.Users).HasForeignKey(i => i.RoleId);

            modelBuilder.Entity<QSection>()
                .HasMany(v => v.Variants)
                .WithOne(c => c.Section).HasForeignKey(i => i.SectionId);
        }
    }
}