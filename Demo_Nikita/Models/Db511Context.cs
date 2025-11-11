using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Demo_Nikita.Models;

public partial class Db511Context : DbContext
{
    public Db511Context()
    {
    }

    public Db511Context(DbContextOptions<Db511Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsUnit> ProductsUnits { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProduct> UserProducts { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=lorksipt.ru;Port=5432;Username=user511;Password=72390;Database=db511");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("products_pk");

            entity.ToTable("products");

            entity.Property(e => e.ProductId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasColumnType("character varying")
                .HasColumnName("product_name");
            entity.Property(e => e.ProductPrice).HasColumnName("product_price");
            entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");
            entity.Property(e => e.ProductUnit).HasColumnName("product_unit");

            entity.HasOne(d => d.ProductUnitNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductUnit)
                .HasConstraintName("products_products_unit_fk");
        });

        modelBuilder.Entity<ProductsUnit>(entity =>
        {
            entity.HasKey(e => e.ProductsUnitId).HasName("products_unit_pk");

            entity.ToTable("products_unit");

            entity.Property(e => e.ProductsUnitId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("products_unit_id");
            entity.Property(e => e.ProductsUnitName)
                .HasColumnType("character varying")
                .HasColumnName("products_unit_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pk");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("user_id");
            entity.Property(e => e.UserAddress).HasColumnName("user_address");
            entity.Property(e => e.UserInn)
                .HasColumnType("character varying")
                .HasColumnName("user_inn");
            entity.Property(e => e.UserLogin)
                .HasColumnType("character varying")
                .HasColumnName("user_login");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword)
                .HasColumnType("character varying")
                .HasColumnName("user_password");
            entity.Property(e => e.UserPhone)
                .HasColumnType("character varying")
                .HasColumnName("user_phone");
            entity.Property(e => e.UserType).HasColumnName("user_type");

            entity.HasOne(d => d.UserTypeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserType)
                .HasConstraintName("users_user_type_fk");
        });

        modelBuilder.Entity<UserProduct>(entity =>
        {
            entity.HasKey(e => e.UserProductId).HasName("user_product_pk");

            entity.ToTable("user_product");

            entity.Property(e => e.UserProductId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("user_product_id");
            entity.Property(e => e.UserProductProduct).HasColumnName("user_product_product");
            entity.Property(e => e.UserProductQuantity).HasColumnName("user_product_quantity");
            entity.Property(e => e.UserProductUser).HasColumnName("user_product_user");

            entity.HasOne(d => d.UserProductProductNavigation).WithMany(p => p.UserProducts)
                .HasForeignKey(d => d.UserProductProduct)
                .HasConstraintName("user_product_products_fk");

            entity.HasOne(d => d.UserProductUserNavigation).WithMany(p => p.UserProducts)
                .HasForeignKey(d => d.UserProductUser)
                .HasConstraintName("user_product_users_fk");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.UserTypeId).HasName("user_type_pk");

            entity.ToTable("user_type");

            entity.Property(e => e.UserTypeId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("user_type_id");
            entity.Property(e => e.UserTypeName)
                .HasColumnType("character varying")
                .HasColumnName("user_type_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
