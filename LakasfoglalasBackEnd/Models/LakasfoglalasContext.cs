using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LakasfoglalasBackEnd.Models;

public partial class LakasfoglalasContext : DbContext
{
    public LakasfoglalasContext()
    {
    }

    public LakasfoglalasContext(DbContextOptions<LakasfoglalasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Eladasok> Eladasoks { get; set; }

    public virtual DbSet<Lakasok> Lakasoks { get; set; }

    public virtual DbSet<Megyek> Megyeks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Varosok> Varosoks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=lakasfoglalas;USER=root;PASSWORD=;SSL MODE=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Eladasok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("eladasok");

            entity.HasIndex(e => e.FelhasznaloId, "FelhasznaloID");

            entity.HasIndex(e => e.LakasId, "LakasID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.FelhasznaloId)
                .HasColumnType("int(11)")
                .HasColumnName("FelhasznaloID");
            entity.Property(e => e.LakasId)
                .HasColumnType("int(11)")
                .HasColumnName("LakasID");

            entity.HasOne(d => d.Felhasznalo).WithMany(p => p.Eladasoks)
                .HasForeignKey(d => d.FelhasznaloId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("eladasok_ibfk_3");
        });

        modelBuilder.Entity<Lakasok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lakasok");

            entity.HasIndex(e => e.FelhasznaloId, "FelhasznaloID");

            entity.HasIndex(e => e.VarosId, "VarosID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Ar).HasColumnType("int(10)");
            entity.Property(e => e.FelhasznaloId)
                .HasColumnType("int(11)")
                .HasColumnName("FelhasznaloID");
            entity.Property(e => e.Leiras).HasMaxLength(100);
            entity.Property(e => e.Meret).HasColumnType("int(10)");
            entity.Property(e => e.SzobakSzama)
                .HasColumnType("int(10)")
                .HasColumnName("Szobak szama");
            entity.Property(e => e.Utca).HasMaxLength(32);
            entity.Property(e => e.VarosId)
                .HasColumnType("int(11)")
                .HasColumnName("VarosID");

            entity.HasOne(d => d.Felhasznalo).WithMany(p => p.Lakasoks)
                .HasForeignKey(d => d.FelhasznaloId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("lakasok_ibfk_2");

            entity.HasOne(d => d.Varos).WithMany(p => p.Lakasoks)
                .HasForeignKey(d => d.VarosId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("lakasok_ibfk_1");
        });

        modelBuilder.Entity<Megyek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("megyek");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Megye).HasMaxLength(30);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.PermissionId, "Jog");

            entity.HasIndex(e => e.LoginNev, "LoginNev").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Email).HasMaxLength(64);
            entity.Property(e => e.Hash)
                .HasMaxLength(64)
                .HasColumnName("HASH");
            entity.Property(e => e.LoginNev).HasMaxLength(16);
            entity.Property(e => e.Name).HasMaxLength(64);
            entity.Property(e => e.PermissionId).HasColumnType("int(11)");
            entity.Property(e => e.ProfilePicturePath).HasMaxLength(64);
            entity.Property(e => e.Salt)
                .HasMaxLength(64)
                .HasColumnName("SALT");
        });

        modelBuilder.Entity<Varosok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("varosok");

            entity.HasIndex(e => e.MegyeId, "MegyeID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.MegyeId)
                .HasColumnType("int(11)")
                .HasColumnName("MegyeID");
            entity.Property(e => e.Varos).HasMaxLength(30);

            entity.HasOne(d => d.Megye).WithMany(p => p.Varosoks)
                .HasForeignKey(d => d.MegyeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("varosok_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
