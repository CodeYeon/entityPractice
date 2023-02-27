using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityPractice.Server.Models
{
    public partial class kapcq_cafeContext : DbContext
    {
        public kapcq_cafeContext()
        {
        }

        public kapcq_cafeContext(DbContextOptions<kapcq_cafeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=kapcq.database.windows.net,1433;Initial Catalog=kapcq_cafe;Persist Security Info=False;User ID=kapcqdbadmin;Password=Kapcqvm14317!;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Idx);

                entity.ToTable("Category");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.Idx)
                    .HasName("PK_Menus");

                entity.ToTable("Menu");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.CategoryIdxNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.CategoryIdx)
                    .HasConstraintName("FK_Menu_Category");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Idx);

                entity.ToTable("Order");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnType("money");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Idx);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_OrderItems_Menu");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderItems_Order");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
