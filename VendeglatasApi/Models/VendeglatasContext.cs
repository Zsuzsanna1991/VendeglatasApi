using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VendeglatasApi.Models;

public partial class VendeglatasContext : DbContext
{
    public VendeglatasContext()
    {
    }

    public VendeglatasContext(DbContextOptions<VendeglatasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Furdok> Furdoks { get; set; }

    public virtual DbSet<Varosok> Varosoks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=vendeglatas;user=root;password=");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Furdok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("furdok");

            entity.HasIndex(e => e.Varosid, "varosid");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cim)
                .HasMaxLength(40)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("cim");
            entity.Property(e => e.Iranyitoszam)
                .HasMaxLength(5)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("iranyitoszam");
            entity.Property(e => e.Nev)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("nev");
            entity.Property(e => e.Regtime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("regtime");
            entity.Property(e => e.Varosid)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("varosid");

            entity.HasOne(d => d.Varos).WithMany(p => p.Furdoks)
                .HasForeignKey(d => d.Varosid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("furdok_ibfk_1");
        });

        modelBuilder.Entity<Varosok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("varosok");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Lakosokszama)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("lakosokszama");
            entity.Property(e => e.Nev)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("nev");
            entity.Property(e => e.Regtime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("regtime");
            entity.Property(e => e.Tipus)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("tipus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
