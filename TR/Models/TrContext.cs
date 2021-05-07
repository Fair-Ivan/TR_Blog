namespace TR.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// context
    /// </summary>
    public class TrContext:DbContext
    {
        public TrContext(DbContextOptions<TrContext> dbContextOptions)
            :base(dbContextOptions)
        {
        }

        /// <summary>
        /// 用户表
        /// </summary>
        public virtual DbSet<User> User { get; set; }

        /// <summary>
        /// 博客表
        /// </summary>
        public virtual DbSet<Blog> Blog { get; set; }

        public virtual DbSet<Author> Author { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(a => a.UserId);
                entity.ToTable("user");
                entity.Property(a => a.UserName).HasMaxLength(32);
                entity.Property(a => a.Password).HasMaxLength(32);
                entity.Property(a => a.AddTime).HasColumnType("datetime");
                entity.Property(a => a.EditTime).HasColumnType("datetime");
                entity.Property(a => a.IsDelete).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.ToTable("blog");
                entity.Property(a => a.Title).HasMaxLength(64);
                entity.Property(a => a.Top).HasColumnType("int(2)");
                entity.Property(a => a.Content).HasMaxLength(51200);
                entity.Property(a => a.Summary).HasMaxLength(2000);
                entity.Property(a => a.Category).HasMaxLength(32);
                entity.Property(a => a.CategoryID).HasMaxLength(32);
                entity.Property(a => a.CreateTime).HasColumnType("datetime");
                entity.Property(a => a.EditTime).HasColumnType("datetime");
                entity.Property(a => a.Tags).HasMaxLength(32);
                entity.Property(a => a.SourceUrl).HasMaxLength(64);
                entity.Property(a => a.Pv).HasMaxLength(32);
                entity.Property(a => a.AuthorId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.ToTable("author");
                entity.Property(a => a.Name).HasMaxLength(64);
                entity.Property(a => a.Intridution).HasMaxLength(2000);
                entity.Property(a => a.AddTime).HasColumnType("datetime");
                entity.Property(a => a.BirthDay).HasColumnType("datetime");
            });
        }
    }
}
