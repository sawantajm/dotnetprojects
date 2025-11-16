using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MilkManagementSystem.Models;

public partial class MilkMgtSystemContext : DbContext
{
    public MilkMgtSystemContext()
    {
    }

    public MilkMgtSystemContext(DbContextOptions<MilkMgtSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodDetail> FoodDetails { get; set; }

    public virtual DbSet<Milkcollection> Milkcollections { get; set; }

    public virtual DbSet<Milkerate> Milkerates { get; set; }

    public virtual DbSet<Milktype> Milktypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("CUSTOMER");

            entity.Property(e => e.Customerid).HasColumnName("CUSTOMERID");
            entity.Property(e => e.Dateadded)
                .HasColumnType("datetime")
                .HasColumnName("DATEADDED");
            entity.Property(e => e.Datechanged)
                .HasColumnType("datetime")
                .HasColumnName("DATECHANGED");
            entity.Property(e => e.Deleteflag).HasColumnName("DELETEFLAG");
            entity.Property(e => e.FirstName)
                .HasMaxLength(250)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(250)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Milktypeid).HasColumnName("MILKTYPEID");
            entity.Property(e => e.Mobileno)
                .HasMaxLength(250)
                .HasColumnName("MOBILENO");
            entity.Property(e => e.Roleid).HasColumnName("ROLEID");

            entity.HasOne(d => d.Milktype).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Milktypeid)
                .HasConstraintName("FK__CUSTOMER__MILKTY__3E52440B");

            entity.HasOne(d => d.Role).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("FK__CUSTOMER__DELETE__3D5E1FD2");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.ToTable("Food");

            entity.Property(e => e.DateChanged).HasColumnType("datetime");
            entity.Property(e => e.Dateadded).HasColumnType("datetime");
            entity.Property(e => e.FoodName).HasMaxLength(250);
        });

        modelBuilder.Entity<FoodDetail>(entity =>
        {
            entity.HasKey(e => e.Srno);

            entity.Property(e => e.Srno).HasColumnName("SRNO");
            entity.Property(e => e.Amount).HasColumnName("AMOUNT");
            entity.Property(e => e.Customerid).HasColumnName("CUSTOMERID");
            entity.Property(e => e.Dateadded)
                .HasColumnType("datetime")
                .HasColumnName("DATEADDED");
            entity.Property(e => e.Datechanged)
                .HasColumnType("datetime")
                .HasColumnName("DATECHANGED");
            entity.Property(e => e.Deleteflag).HasColumnName("DELETEFLAG");
            entity.Property(e => e.Foodname)
                .HasMaxLength(250)
                .HasColumnName("FOODNAME");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");
            entity.Property(e => e.Rate).HasColumnName("RATE");

            entity.HasOne(d => d.Customer).WithMany(p => p.FoodDetails)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("FK__FoodDetai__CUSTO__68487DD7");

            entity.HasOne(d => d.Food).WithMany(p => p.FoodDetails)
                .HasForeignKey(d => d.FoodId)
                .HasConstraintName("FK__FoodDetai__FoodI__693CA210");
        });

        modelBuilder.Entity<Milkcollection>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("MILKCOLLECTION");

            entity.Property(e => e.Guid)
                .HasMaxLength(1000)
                .HasColumnName("GUID");
            entity.Property(e => e.Collectionshift)
                .HasMaxLength(255)
                .HasColumnName("COLLECTIONSHIFT");
            entity.Property(e => e.Customerid).HasColumnName("CUSTOMERID");
            entity.Property(e => e.Dateadded)
                .HasColumnType("datetime")
                .HasColumnName("DATEADDED");
            entity.Property(e => e.Fat).HasColumnName("FAT");
            entity.Property(e => e.Liter)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("LITER");
            entity.Property(e => e.Milktypeid).HasColumnName("MILKTYPEID");
            entity.Property(e => e.Rate).HasColumnName("RATE");
            entity.Property(e => e.Snf).HasColumnName("SNF");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.Customer).WithMany(p => p.Milkcollections)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("FK__MILKCOLLEC__GUID__534D60F1");

            entity.HasOne(d => d.Milktype).WithMany(p => p.Milkcollections)
                .HasForeignKey(d => d.Milktypeid)
                .HasConstraintName("FK__MILKCOLLE__MILKT__5441852A");
        });

        modelBuilder.Entity<Milkerate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MILKERATE");

            entity.Property(e => e.Fatrate).HasColumnName("FATRATE");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Snfrate).HasColumnName("SNFRATE");
        });

        modelBuilder.Entity<Milktype>(entity =>
        {
            entity.ToTable("MILKTYPE");

            entity.Property(e => e.Milktypeid).HasColumnName("MILKTYPEID");
            entity.Property(e => e.Dateadded).HasColumnType("datetime");
            entity.Property(e => e.Milkname)
                .HasMaxLength(250)
                .HasColumnName("MILKNAME");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("ROLE");

            entity.Property(e => e.Roleid).HasColumnName("ROLEID");
            entity.Property(e => e.Dateadded)
                .HasColumnType("datetime")
                .HasColumnName("DATEADDED");
            entity.Property(e => e.Datechanged)
                .HasColumnType("datetime")
                .HasColumnName("DATECHANGED");
            entity.Property(e => e.Deleteflag).HasColumnName("DELETEFLAG");
            entity.Property(e => e.Rolename)
                .HasMaxLength(255)
                .HasColumnName("ROLENAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
