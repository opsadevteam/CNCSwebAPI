using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CNCSwebApiProject.Models;

public partial class CncssystemContext : DbContext
{
    public CncssystemContext(DbContextOptions<CncssystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblActivityLog> TblActivityLog { get; set; }

    public virtual DbSet<TblDescriptions> TblDescriptions { get; set; }

    public virtual DbSet<TblProdDescLog> TblProdDescLog { get; set; }

    public virtual DbSet<TblProductVendor> TblProductVendor { get; set; }

    public virtual DbSet<TblTransactionLogs> TblTransactionLogs { get; set; }

    public virtual DbSet<TblTransactions> TblTransactions { get; set; }

    public virtual DbSet<TblUserAccount> TblUserAccount { get; set; }

    public virtual DbSet<TblUserAccountLog> TblUserAccountLog { get; set; }
    public virtual DbSet<ProductVendor> ProductVendor { get; set; }
    public virtual DbSet<ProductVendorLog> ProductVendorLog { get; set; }
    public virtual DbSet<ProductDescription> ProductDescription { get; set; }
    public virtual DbSet<ProductDescriptionLog> ProductDescriptionLog { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblActivityLog>(entity =>
        {
            entity.ToTable("tblActivityLog");

            entity.Property(e => e.LogActivity).HasMaxLength(50);
            entity.Property(e => e.LogLocation).HasMaxLength(20);
            entity.Property(e => e.LogTime).HasPrecision(0);
            entity.Property(e => e.LogUser).HasMaxLength(50);
            entity.Property(e => e.UserGroup).HasMaxLength(20);
        });

        modelBuilder.Entity<TblDescriptions>(entity =>
        {
            entity.ToTable("tblDescriptions");

            entity.HasIndex(e => e.ProductVendorId, "IX_tblDescriptions_ProductVendorID");

            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasPrecision(0);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.LogId)
                .HasMaxLength(20)
                .HasColumnName("LogID");
            entity.Property(e => e.ProductVendorId).HasColumnName("ProductVendorID");

            entity.HasOne(d => d.ProductVendor).WithMany(p => p.TblDescriptions)
                .HasForeignKey(d => d.ProductVendorId)
                .HasConstraintName("FK_tblDescriptions_tblProductVendor");
        });

        modelBuilder.Entity<TblProdDescLog>(entity =>
        {
            entity.ToTable("tblProdDescLog");

            entity.Property(e => e.LogActivity).HasMaxLength(10);
            entity.Property(e => e.LogDate).HasPrecision(0);
            entity.Property(e => e.LogId)
                .HasMaxLength(20)
                .HasColumnName("LogID");
            entity.Property(e => e.LogUser).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<TblProductVendor>(entity =>
        {
            entity.ToTable("tblProductVendor");

            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasPrecision(0);
            entity.Property(e => e.LogId)
                .HasMaxLength(20)
                .HasColumnName("LogID");
            entity.Property(e => e.ProductVendor).HasMaxLength(50);
        });

        modelBuilder.Entity<TblTransactionLogs>(entity =>
        {
            entity.ToTable("tblTransactionLogs");

            entity.HasIndex(e => e.DescriptionId, "IX_tblTransactionLogs_DescriptionID");

            entity.HasIndex(e => e.ProductVendorId, "IX_tblTransactionLogs_ProductVendorID");

            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("CustomerID");
            entity.Property(e => e.DateAdded).HasPrecision(0);
            entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");
            entity.Property(e => e.LogBy).HasMaxLength(50);
            entity.Property(e => e.LogDate).HasPrecision(0);
            entity.Property(e => e.LogId)
                .HasMaxLength(20)
                .HasColumnName("LogID");
            entity.Property(e => e.LogType).HasMaxLength(20);
            entity.Property(e => e.PickUpDate).HasPrecision(0);
            entity.Property(e => e.ProductVendorId).HasColumnName("ProductVendorID");
            entity.Property(e => e.RepliedBy).HasMaxLength(50);
            entity.Property(e => e.Shift).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TakeOffDate).HasPrecision(0);
            entity.Property(e => e.TransactionId)
                .HasMaxLength(50)
                .HasColumnName("TransactionID");
            entity.Property(e => e.TransactionType).HasMaxLength(20);

            entity.HasOne(d => d.Description).WithMany(p => p.TblTransactionLogs)
                .HasForeignKey(d => d.DescriptionId)
                .HasConstraintName("FK_tblTransactionLogs_tblDescriptions");

            entity.HasOne(d => d.ProductVendor).WithMany(p => p.TblTransactionLogs)
                .HasForeignKey(d => d.ProductVendorId)
                .HasConstraintName("FK_tblTransactionLogs_tblProductVendor");
        });

        modelBuilder.Entity<TblTransactions>(entity =>
        {
            entity.ToTable("tblTransactions");

            entity.HasIndex(e => e.DescriptionId, "IX_tblTransactions_DescriptionID");

            entity.HasIndex(e => e.ProductVendorId, "IX_tblTransactions_ProductVendorID");

            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("CustomerID");
            entity.Property(e => e.DateAdded).HasPrecision(0);
            entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");
            entity.Property(e => e.LogId)
                .HasMaxLength(20)
                .HasColumnName("LogID");
            entity.Property(e => e.PickUpDate).HasPrecision(0);
            entity.Property(e => e.ProductVendorId).HasColumnName("ProductVendorID");
            entity.Property(e => e.RepliedBy).HasMaxLength(50);
            entity.Property(e => e.Shift).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TakeOffDate).HasPrecision(0);
            entity.Property(e => e.TransactionId)
                .HasMaxLength(50)
                .HasColumnName("TransactionID");
            entity.Property(e => e.TransactionType).HasMaxLength(20);

            entity.HasOne(d => d.Description).WithMany(p => p.TblTransactions)
                .HasForeignKey(d => d.DescriptionId)
                .HasConstraintName("FK_tblTransactions_tblDescriptions");

            entity.HasOne(d => d.ProductVendor).WithMany(p => p.TblTransactions)
                .HasForeignKey(d => d.ProductVendorId)
                .HasConstraintName("FK_tblTransactions_tblProductVendor");
        });

        modelBuilder.Entity<TblUserAccount>(entity =>
        {
            entity.ToTable("tblUserAccount");

            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasPrecision(0);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.LogId).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.UserGroup).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<TblUserAccountLog>(entity =>
        {
            entity.ToTable("tblUserAccountLog");

            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasPrecision(0);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.LogDate).HasPrecision(0);
            entity.Property(e => e.LogId).HasMaxLength(20);
            entity.Property(e => e.LogType).HasMaxLength(20);
            entity.Property(e => e.LogUser).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.UserGroup).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
