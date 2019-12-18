using HD.DataAccses.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.DataAccses
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>()
                .HasKey(t => new { t.PostId, t.UserId});

            modelBuilder.Entity<Like>()
                .HasOne(sc => sc.Post)
                .WithMany(s => s.Likes)
                .HasForeignKey(sc => sc.PostId);

            modelBuilder.Entity<Like>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.Likes)
                .HasForeignKey(sc => sc.UserId);

            // Subscribers

            modelBuilder.Entity<Subscriber>()
               .HasKey(t => new { t.SubId, t.UserId });

            modelBuilder.Entity<Subscriber>()
               .HasOne(sc => sc.Sub)
               .WithMany(s => s.Subscribed)
               .HasForeignKey(sc => sc.SubId);

            modelBuilder.Entity<Subscriber>()
               .HasOne(sc => sc.User)
               .WithMany(s => s.Subscribers)
               .HasForeignKey(sc => sc.UserId);

            // Posts

            modelBuilder.Entity<Post>()
                .HasOne(sc => sc.Hd)
                .WithMany(s => s.Posts)
                .HasForeignKey(sc => sc.HdId);

            // Comments

            modelBuilder.Entity<Comment>()
                .HasOne(sc => sc.User)
                .WithMany(sc => sc.Comments)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<Comment>()
              .HasOne(sc => sc.Post)
              .WithMany(sc => sc.Comments)
              .HasForeignKey(sc => sc.PostId);

            // Photos

            modelBuilder.Entity<Photo>()
               .HasOne(sc => sc.Post)
               .WithMany(sc => sc.Photos)
               .HasForeignKey(sc => sc.PostId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
