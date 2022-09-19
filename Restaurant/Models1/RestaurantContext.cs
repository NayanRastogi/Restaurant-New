using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Restaurant.Models1
{
    public partial class RestaurantContext : DbContext
    {
        public RestaurantContext()
        {
        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Cuisine> Cuisines { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<DiningTable> DiningTables { get; set; } = null!;
        public virtual DbSet<DiningTableTrack> DiningTableTracks { get; set; } = null!;
        public virtual DbSet<GetCuisinewiseItem> GetCuisinewiseItems { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Restaurant> Restaurants { get; set; } = null!;
        public virtual DbSet<RestaurantMenuItem> RestaurantMenuItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-ECABALN;User ID=nayan;Password=nayan;Database=Restaurant;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.BillsId)
                    .HasName("PK_Bills_BillsID");

                entity.Property(e => e.BillsId).HasColumnName("BillsID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ModifyOn).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bills_CustomerID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bills_OrderID");
            });

            modelBuilder.Entity<Cuisine>(entity =>
            {
                entity.ToTable("Cuisine");

                entity.HasIndex(e => e.CuisineName, "UC_Cuisine_CuisineName")
                    .IsUnique();

                entity.Property(e => e.CuisineId).HasColumnName("CuisineID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CuisineName).HasMaxLength(50);

                entity.Property(e => e.ModifyOn).HasColumnType("datetime");

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Cuisines)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK_Cuisine_RestaurantID");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CustomerName).HasMaxLength(100);

                entity.Property(e => e.MobileNo).HasMaxLength(10);

                entity.Property(e => e.ModifyOn).HasColumnType("datetime");

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_RestaurantID");
            });

            modelBuilder.Entity<DiningTable>(entity =>
            {
                entity.ToTable("DiningTable");

                entity.Property(e => e.DiningTableId).HasColumnName("DiningTableID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.ModifyOn).HasColumnType("datetime");

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.DiningTables)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiningTable_RestaurantID");
            });

            modelBuilder.Entity<DiningTableTrack>(entity =>
            {
                entity.ToTable("DiningTableTrack");

                entity.Property(e => e.DiningTableTrackId).HasColumnName("DiningTableTrackID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DiningTableId).HasColumnName("DiningTableID");

                entity.Property(e => e.ModifyOn).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.Property(e => e.TableStatus).HasMaxLength(100);

                entity.HasOne(d => d.DiningTable)
                    .WithMany(p => p.DiningTableTracks)
                    .HasForeignKey(d => d.DiningTableId)
                    .HasConstraintName("FK_DiningTableTrack_DiningTableID");
            });

            modelBuilder.Entity<GetCuisinewiseItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetCuisinewiseItem");

                entity.Property(e => e.CuisineName).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(100);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.DiningTableId, "NC_Order_DiningTableID");

                entity.HasIndex(e => e.MenuItemId, "NC_Order_MenuITemID");

                entity.HasIndex(e => e.RestaurantId, "NC_Order_RestaurantID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DiningTableId).HasColumnName("DiningTableID");

                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");

                entity.Property(e => e.ModifyOn).HasColumnType("datetime");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.HasOne(d => d.DiningTable)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DiningTableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_DiningTableId");

                entity.HasOne(d => d.MenuItem)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MenuItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_MenuITemID");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_RestaurantID");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.HasIndex(e => e.MobileNo, "UC_Restaurant_MobileNo")
                    .IsUnique();

                entity.HasIndex(e => e.RestaurantName, "UC_Restaurant_RestaurantName")
                    .IsUnique();

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.MobileNo).HasMaxLength(10);

                entity.Property(e => e.ModifyOn).HasColumnType("datetime");

                entity.Property(e => e.RestaurantAddress).HasMaxLength(500);

                entity.Property(e => e.RestaurantName).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(10);
            });

            modelBuilder.Entity<RestaurantMenuItem>(entity =>
            {
                entity.HasKey(e => e.MenuItemId)
                    .HasName("PK_RestaurantMenuItem_MenuItemID");

                entity.ToTable("RestaurantMenuItem");

                entity.HasIndex(e => e.ItemName, "UC_RestaurantMenuItem_ItemName")
                    .IsUnique();

                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CuisineId).HasColumnName("CuisineID");

                entity.Property(e => e.ItemName).HasMaxLength(100);

                entity.Property(e => e.ModifyOn).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.HasOne(d => d.Cuisine)
                    .WithMany(p => p.RestaurantMenuItems)
                    .HasForeignKey(d => d.CuisineId)
                    .HasConstraintName("FK_RestaurantMenuItem_CuisineID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
