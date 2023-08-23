using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vicosa_Entity;

public partial class VicosaContext : DbContext
{
    public VicosaContext()
    {
    }

    public VicosaContext(DbContextOptions<VicosaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumnichapter> Alumnichapters { get; set; }

    public virtual DbSet<Alumnus> Alumni { get; set; }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<Chapterevent> Chapterevents { get; set; }

    public virtual DbSet<Chaptermeeting> Chaptermeetings { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=Olasehinde1$;database=vicosa", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Alumnichapter>(entity =>
        {
            entity.HasKey(e => e.AlumniChapterId).HasName("PRIMARY");

            entity.ToTable("alumnichapter");

            entity.HasIndex(e => e.AlumniId, "AlumniId");

            entity.HasIndex(e => e.ChapterId, "chapterId");

            entity.Property(e => e.ChapterId).HasColumnName("chapterId");

            entity.HasOne(d => d.Alumni).WithMany(p => p.Alumnichapters)
                .HasForeignKey(d => d.AlumniId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("alumnichapter_ibfk_2");

            entity.HasOne(d => d.Chapter).WithMany(p => p.Alumnichapters)
                .HasForeignKey(d => d.ChapterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("alumnichapter_ibfk_1");
        });

        modelBuilder.Entity<Alumnus>(entity =>
        {
            entity.HasKey(e => e.AlumniId).HasName("PRIMARY");

            entity.ToTable("alumni");

            entity.HasIndex(e => e.ChapterId, "ChapterID");

            entity.Property(e => e.AlumniId).HasColumnName("AlumniID");
            entity.Property(e => e.ChapterId).HasColumnName("ChapterID");
            entity.Property(e => e.EmailAddress).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.HasOne(d => d.Chapter).WithMany(p => p.Alumni)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("alumni_ibfk_1");
        });

        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasKey(e => e.ChapterId).HasName("PRIMARY");

            entity.ToTable("chapter");

            entity.Property(e => e.ChapterId).HasColumnName("ChapterID");
            entity.Property(e => e.ChapterName).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(50);
        });

        modelBuilder.Entity<Chapterevent>(entity =>
        {
            entity.HasKey(e => e.ChapterEventId).HasName("PRIMARY");

            entity.ToTable("chapterevent");

            entity.HasIndex(e => e.ChapterId, "ChapterID");

            entity.Property(e => e.ChapterEventId).HasColumnName("ChapterEventID");
            entity.Property(e => e.ChapterEventName).HasMaxLength(255);
            entity.Property(e => e.ChapterId).HasColumnName("ChapterID");

            entity.HasOne(d => d.Chapter).WithMany(p => p.Chapterevents)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("chapterevent_ibfk_1");
        });

        modelBuilder.Entity<Chaptermeeting>(entity =>
        {
            entity.HasKey(e => e.MeetingId).HasName("PRIMARY");

            entity.ToTable("chaptermeeting");

            entity.HasIndex(e => e.ChapterId, "ChapterID");

            entity.Property(e => e.MeetingId).HasColumnName("MeetingID");
            entity.Property(e => e.ChapterId).HasColumnName("ChapterID");
            entity.Property(e => e.FileDirectory)
                .HasMaxLength(255)
                .HasColumnName("fileDirectory");
            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .HasColumnName("filename");

            entity.HasOne(d => d.Chapter).WithMany(p => p.Chaptermeetings)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("chaptermeeting_ibfk_1");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PRIMARY");

            entity.ToTable("event");

            entity.Property(e => e.EventName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
