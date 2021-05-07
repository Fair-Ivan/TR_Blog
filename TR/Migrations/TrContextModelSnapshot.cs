﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TR.Models;

namespace TR.Migrations
{
    [DbContext(typeof(TrContext))]
    partial class TrContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TR.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime");

                    b.Property<string>("Intridution")
                        .HasMaxLength(2000);

                    b.Property<string>("Name")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("author");
                });

            modelBuilder.Entity("TR.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Category")
                        .HasMaxLength(32);

                    b.Property<string>("CategoryID")
                        .HasMaxLength(32);

                    b.Property<string>("Content")
                        .HasMaxLength(51200);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("EditTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Pv")
                        .HasMaxLength(32);

                    b.Property<string>("SourceUrl")
                        .HasMaxLength(64);

                    b.Property<string>("Summary")
                        .HasMaxLength(2000);

                    b.Property<string>("Tags")
                        .HasMaxLength(32);

                    b.Property<string>("Title")
                        .HasMaxLength(64);

                    b.Property<int>("Top")
                        .HasColumnType("int(2)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("blog");
                });

            modelBuilder.Entity("TR.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime");

                    b.Property<string>("AuthenticationType");

                    b.Property<DateTime>("EditTime")
                        .HasColumnType("datetime");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int(11)");

                    b.Property<string>("Password")
                        .HasMaxLength(32);

                    b.Property<string>("UserName")
                        .HasMaxLength(32);

                    b.HasKey("UserId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("TR.Models.Blog", b =>
                {
                    b.HasOne("TR.Models.Author", "Author")
                        .WithMany("Blogs")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}