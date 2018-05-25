using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GiftCertWeb.Models
{
    public partial class GiftCertificateDBContext : DbContext
    {
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<GcOutlet> GcOutlet { get; set; }
        public virtual DbSet<GcPurchase> GcPurchase { get; set; }
        public virtual DbSet<GcRedemption> GcRedemption { get; set; }
        public virtual DbSet<GcType> GcType { get; set; }
        public virtual DbSet<GiftCert> GiftCert { get; set; }
        public virtual DbSet<Outlet> Outlet { get; set; }
        public virtual DbSet<ServicesType> ServicesType { get; set; }

        public GiftCertificateDBContext(DbContextOptions<GiftCertificateDBContext> options)
              : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<GcOutlet>(entity =>
            {
                entity.HasOne(d => d.GiftCertNoNavigation)
                    .WithMany(p => p.GcOutlet)
                    .HasForeignKey(d => d.GiftCertNo)
                    .HasConstraintName("FK_GcOutlet_GiftCert");

                entity.HasOne(d => d.Outlet)
                    .WithMany(p => p.GcOutlet)
                    .HasForeignKey(d => d.OutletId)
                    .HasConstraintName("FK_GcOutlet_Outlet");
            });

            modelBuilder.Entity<GcPurchase>(entity =>
            {
                entity.Property(e => e.CardType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CcNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasColumnType("text");

                entity.HasOne(d => d.GiftCertNoNavigation)
                    .WithMany(p => p.GcPurchase)
                    .HasForeignKey(d => d.GiftCertNo)
                    .HasConstraintName("FK_GcPurchase_GiftCert");
            });

            modelBuilder.Entity<GcRedemption>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RedemptionDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasColumnType("text");

                entity.HasOne(d => d.GiftCertNoNavigation)
                    .WithMany(p => p.GcRedemption)
                    .HasForeignKey(d => d.GiftCertNo)
                    .HasConstraintName("FK_GcRedemption_GiftCert");
            });

            modelBuilder.Entity<GcType>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GiftCert>(entity =>
            {
                entity.HasKey(e => e.GiftCertNo);

                entity.Property(e => e.GiftCertNo).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DtiPermitNo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasColumnType("text");

                entity.Property(e => e.QrCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("decimal(9, 2)");

                entity.HasOne(d => d.GcType)
                    .WithMany(p => p.GiftCert)
                    .HasForeignKey(d => d.GcTypeId)
                    .HasConstraintName("FK_GiftCert_GcType");
            });

            modelBuilder.Entity<Outlet>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ServicesType>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.GiftCertNoNavigation)
                    .WithMany(p => p.ServicesType)
                    .HasForeignKey(d => d.GiftCertNo)
                    .HasConstraintName("FK_ServicesType_GiftCert");
            });
        }
    }
}
