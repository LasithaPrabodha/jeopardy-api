using System;
using System.Collections.Generic;
using Jeopardy.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Jeopardy.Core.Data;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airdate> Airdates { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Classification> Classifications { get; set; }

    public virtual DbSet<Clue> Clues { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airdate>(entity =>
        {
            entity.HasKey(e => e.Game);

            entity.ToTable("airdates");

            entity.Property(e => e.Game)
                .ValueGeneratedNever()
                .HasColumnName("game");
            entity.Property(e => e.Date).HasColumnName("airdate");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories");

            entity.HasIndex(e => e.CategoryName, "IX_categories_category").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName).HasColumnName("category");
        });

        modelBuilder.Entity<Classification>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("classifications");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ClueId).HasColumnName("clue_id");

            entity.HasOne(d => d.Category).WithMany().HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.Clue).WithMany().HasForeignKey(d => d.ClueId);
        });

        modelBuilder.Entity<Clue>(entity =>
        {
            entity.ToTable("clues");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Game).HasColumnName("game");
            entity.Property(e => e.Round).HasColumnName("round");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.GameNavigation).WithMany(p => p.Clues).HasForeignKey(d => d.Game);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ClueNavigation)
                .HasForeignKey<Clue>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.ToTable("documents");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer).HasColumnName("answer");
            entity.Property(e => e.Clue).HasColumnName("clue");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
