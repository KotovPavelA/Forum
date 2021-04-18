using Forum.Models;
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
        public DbSet<Like> Likes { get; set; }
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
                    .HasMany(m => m.Messages)
                    .WithOne(u => u.User).HasForeignKey(i => i.UserId);

            modelBuilder.Entity<User>()
                    .HasOne(c => c.Role)
                    .WithMany(s => s.Users).HasForeignKey(i => i.RoleId);

            modelBuilder.Entity<QSection>()
                .HasMany(v => v.Variants)
                .WithOne(c => c.Section).HasForeignKey(i => i.SectionId);

            modelBuilder.Entity<Section>()
                .HasOne(c => c.Creater)
                .WithMany(s => s.SectionsCreated).HasForeignKey(i => i.CreaterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasOne(u => u.User)
                .WithMany(l => l.Likes).HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasOne(m => m.Message)
                .WithMany(l => l.Likes).HasForeignKey(i => i.MessageId)
                .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
