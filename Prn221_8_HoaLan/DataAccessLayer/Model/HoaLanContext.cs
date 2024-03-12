using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLayer.Model
{
    public partial class HoaLanContext : DbContext
    {
        public HoaLanContext()
        {
        }

        public HoaLanContext(DbContextOptions<HoaLanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auction> Auctions { get; set; } = null!;
        public virtual DbSet<AuctionDetail> AuctionDetails { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);database=HoaLan;uid=sa;pwd=12345;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>(entity =>
            {
                entity.ToTable("auction");

                entity.HasIndex(e => e.OrderId, "UK_bvlmyhb2isivkfvtp5kv3tpl0")
                    .IsUnique()
                    .HasFilter("([order_id] IS NOT NULL)");

                entity.Property(e => e.AuctionId).HasColumnName("auction_id");

                entity.Property(e => e.AuctionName)
                    .HasMaxLength(100)
                    .HasColumnName("auction_name");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");

                entity.Property(e => e.EndPrice).HasColumnName("end_price");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time");

                entity.Property(e => e.HostBy).HasColumnName("hostBy");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PriceStep).HasColumnName("price_step");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.StartPrice).HasColumnName("start_price");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status");

                entity.Property(e => e.WinnerId).HasColumnName("winner_id");

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.Auction)
                    .HasForeignKey<Auction>(d => d.OrderId)
                    .HasConstraintName("FKiepn1ayfrf4b659sg16t9rmjr");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Auctions)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK1w78eyenem7jaulsfmrhmt1mk");
            });

            modelBuilder.Entity<AuctionDetail>(entity =>
            {
                entity.ToTable("auction_detail");

                entity.Property(e => e.AuctionDetailId).HasColumnName("auction_detail_id");

                entity.Property(e => e.AuctionId).HasColumnName("auction_id");

                entity.Property(e => e.BidTime)
                    .HasColumnType("datetime")
                    .HasColumnName("bid_time");

                entity.Property(e => e.ParticipantId).HasColumnName("participant_id");

                entity.Property(e => e.ParticipantPrice).HasColumnName("participant_price");

                entity.HasOne(d => d.Auction)
                    .WithMany(p => p.AuctionDetails)
                    .HasForeignKey(d => d.AuctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK5dygb3k049gmjcquym4ddub04");

                entity.HasOne(d => d.Participant)
                    .WithMany(p => p.AuctionDetails)
                    .HasForeignKey(d => d.ParticipantId)
                    .HasConstraintName("FKcmi76t59v5sin7ee8ppp2xy94");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.OrderBy).HasColumnName("order_by");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.OrderByNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderBy)
                    .HasConstraintName("FKppaknh5o3u2q53jlykyw43gtf");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_detail");

                entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");

                entity.Property(e => e.Orders).HasColumnName("orders");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.OrdersNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Orders)
                    .HasConstraintName("FKgn4buybec6yic8a026fnk27g8");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FKd9sf38t1yu7b0gbcg6iyet4pv");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.IsAuction).HasColumnName("is_auction");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .HasColumnName("product_name");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("report");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.ReportBy).HasColumnName("report_by");

                entity.Property(e => e.ReportContent)
                    .HasMaxLength(255)
                    .HasColumnName("report_content");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FKcmcakv0g86ueq3ixbirjeb6qu");

                entity.HasOne(d => d.ReportByNavigation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ReportBy)
                    .HasConstraintName("FKpd4nf34id6tmasos9pa7xtmrv");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK20wcxq3dnh6io9qug4vc90p0p");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
