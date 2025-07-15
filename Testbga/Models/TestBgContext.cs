using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Testbga.Models;

public partial class TestbgContext : DbContext
{
    public TestbgContext()
    {
    }

    public TestbgContext(DbContextOptions<TestbgContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<Container> Containers { get; set; }

    public virtual DbSet<Containing> Containings { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<TextBox> TextBoxes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=GUYMICKEY; Initial Catalog=Testbg; Integrated Security=True; Pooling=False; Encrypt=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banner>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Banner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Banner_Component");
        });

        modelBuilder.Entity<Container>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Container)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Container_Component");
        });

        modelBuilder.Entity<Containing>(entity =>
        {
            entity.HasOne(d => d.Component).WithMany(p => p.Containings).HasConstraintName("FK_Containing_Component");

            entity.HasOne(d => d.Container).WithMany(p => p.Containings).HasConstraintName("FK_Containing_Container");
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Page)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Page_Container");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Section)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Section_Container");
        });

        modelBuilder.Entity<TextBox>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TextBox)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TextBox_Component");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
