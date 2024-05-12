using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lab_2_1.Models;

public partial class ZooContext : DbContext
{
    public ZooContext()
    {
    }

    public ZooContext(DbContextOptions<ZooContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=341841911;Database=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("customer_pkey");

            entity.ToTable("customer", "zoo");

            entity.Property(e => e.Customerid)
                .ValueGeneratedNever()
                .HasColumnName("customerid");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Employeeid).HasName("employee_pkey");

            entity.ToTable("employee", "zoo");

            entity.Property(e => e.Employeeid)
                .ValueGeneratedNever()
                .HasColumnName("employeeid");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .HasColumnName("position");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.Petid).HasName("pet_pkey");

            entity.ToTable("pet", "zoo");

            entity.Property(e => e.Petid)
                .ValueGeneratedNever()
                .HasColumnName("petid");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Breed)
                .HasMaxLength(100)
                .HasColumnName("breed");
            entity.Property(e => e.Healthstatus)
                .HasMaxLength(100)
                .HasColumnName("healthstatus");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Species)
                .HasMaxLength(100)
                .HasColumnName("species");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("product_pkey");

            entity.ToTable("product", "zoo");

            entity.Property(e => e.Productid)
                .ValueGeneratedNever()
                .HasColumnName("productid");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .HasColumnName("category");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Stockquantity).HasColumnName("stockquantity");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Saleid).HasName("sale_pkey");

            entity.ToTable("sale", "zoo");

            entity.Property(e => e.Saleid)
                .ValueGeneratedNever()
                .HasColumnName("saleid");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Paymentmethod)
                .HasMaxLength(50)
                .HasColumnName("paymentmethod");
            entity.Property(e => e.Petid).HasColumnName("petid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Saledate).HasColumnName("saledate");
            entity.Property(e => e.Totalamount).HasColumnName("totalamount");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("sale_customerid_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Employeeid)
                .HasConstraintName("sale_employeeid_fkey");

            entity.HasOne(d => d.Pet).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Petid)
                .HasConstraintName("sale_petid_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("sale_productid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
