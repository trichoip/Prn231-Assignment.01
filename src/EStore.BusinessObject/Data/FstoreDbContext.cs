﻿using EStore.BusinessObject.DataSeeding;
using EStore.BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;

namespace EStore.BusinessObject.Data;

public partial class FstoreDbContext : DbContext
{
    public FstoreDbContext(DbContextOptions<FstoreDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            //entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0BA60CD6F4");
            //entity.Property(e => e.CategoryId).ValueGeneratedNever();

            entity.ToTable("Category");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            //entity.HasKey(e => e.MemberId).HasName("PK__Member__0CF04B18FCB84942");
            //entity.Property(e => e.MemberId).ValueGeneratedNever();

            entity.ToTable("Member");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            //entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCF8214C676");
            //entity.Property(e => e.OrderId).ValueGeneratedNever();

            entity.ToTable("Order");
            entity.Property(e => e.Freight).HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");

            //entity.HasOne(d => d.Member).WithMany(p => p.Orders)
            //    .HasForeignKey(d => d.MemberId)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .HasConstraintName("FK__Order__MemberId__267ABA7A");

        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });
            //.HasName("PK__OrderDet__08D097A39E3AFFCA");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.UnitPrice).HasColumnType("money");

            //entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
            //    .HasForeignKey(d => d.OrderId)
            //    .HasConstraintName("FK__OrderDeta__Order__2E1BDC42");

            //entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
            //    .HasForeignKey(d => d.ProductId)
            //    .HasConstraintName("FK__OrderDeta__Produ__2F10007B");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            //entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CD301EB008");
            //entity.Property(e => e.ProductId).ValueGeneratedNever();

            entity.ToTable("Product");
            entity.Property(e => e.ProductName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
            entity.Property(e => e.Weight)
                .HasMaxLength(20)
                .IsUnicode(false);

            //entity.HasOne(d => d.Category).WithMany(p => p.Products)
            //    .HasForeignKey(d => d.CategoryId)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .HasConstraintName("FK__Product__Categor__2B3F6F97");
        });

        //OnModelCreatingPartial(modelBuilder);

        modelBuilder.ApplyConfiguration(new CatergorySeeding());
        modelBuilder.ApplyConfiguration(new MemberSeeding());
        modelBuilder.ApplyConfiguration(new ProductSeeding());
        modelBuilder.ApplyConfiguration(new OrderDetailSeeding());
        modelBuilder.ApplyConfiguration(new OrderSeeding());

    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
