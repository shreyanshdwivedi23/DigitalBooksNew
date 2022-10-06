﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DigitalBooksApi.Models
{
    public partial class DigitalBooksDBContext : DbContext
    {
        public DigitalBooksDBContext()
        {
        }

        public DigitalBooksDBContext(DbContextOptions<DigitalBooksDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBook> TblBooks { get; set; }
        public virtual DbSet<TblLogin> TblLogins { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-I3ENK0M\\SQLEXPRESS;Initial Catalog=DigitalBooksDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblBook>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__TblBook__8BE5A10D0F0B3C1D");

                entity.ToTable("TblBook");

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.BookCategory)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("bookCategory");

                entity.Property(e => e.BookContent).HasColumnName("bookContent");

                entity.Property(e => e.BookCreatedBy).HasColumnName("bookCreatedBy");

                entity.Property(e => e.BookCreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("bookCreatedDate");

                entity.Property(e => e.BookImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("bookImage");

                entity.Property(e => e.BookIsActive).HasColumnName("bookIsActive");

                entity.Property(e => e.BookIsBlock).HasColumnName("bookIsBlock");

                entity.Property(e => e.BookIsDelete).HasColumnName("bookIsDelete");

                entity.Property(e => e.BookModifiedBy).HasColumnName("bookModifiedBy");

                entity.Property(e => e.BookModifiedDate)
                    .HasColumnType("date")
                    .HasColumnName("bookModifiedDate");

                entity.Property(e => e.BookPrice)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("bookPrice");

                entity.Property(e => e.BookPublisher)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("bookPublisher");

                entity.Property(e => e.BookReleasedDate)
                    .HasColumnType("date")
                    .HasColumnName("bookReleasedDate");

                entity.Property(e => e.BookTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("bookTitle");
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__TblLogin__1788CC4C9EF9EA18");

                entity.ToTable("TblLogin");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserFullname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__TblUser__1788CC4C56F23E5D");

                entity.ToTable("TblUser");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserFullname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}