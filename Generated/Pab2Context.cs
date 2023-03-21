using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PAB2.Generated;

public partial class Pab2Context : DbContext
{
    public Pab2Context()
    {
    }

    public Pab2Context(DbContextOptions<Pab2Context> options)
        : base(options)
    {
    }

    public Pab2Context(string connectionString)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerItem> PlayerItems { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<ShopItem> ShopItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PAB2;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("Player");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PlayerItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PlayerItem");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

            entity.HasOne(d => d.Item).WithMany()
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_PlayerItem_Item");

            entity.HasOne(d => d.Player).WithMany()
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK_PlayerItem_Player");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.ToTable("Shop");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ShopItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ShopItem");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ShopId).HasColumnName("ShopID");

            entity.HasOne(d => d.Item).WithMany()
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_ShopItem_Item");

            entity.HasOne(d => d.Shop).WithMany()
                .HasForeignKey(d => d.ShopId)
                .HasConstraintName("FK_ShopItem_Shop");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}