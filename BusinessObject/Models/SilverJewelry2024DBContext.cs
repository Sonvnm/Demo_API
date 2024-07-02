using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models
{
    public partial class SilverJewelry2024DBContext : DbContext
    {
        public SilverJewelry2024DBContext()
        {
        }

        public SilverJewelry2024DBContext(DbContextOptions<SilverJewelry2024DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BranchAccount> BranchAccounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<SilverJewelry> SilverJewelries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //                optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;uid=sa;pwd=12345;database=SilverJewelry2024DB;TrustServerCertificate=True");
            //            }
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration config = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json").Build();

                string connectionString = config["ConnectionStrings:DefaultConnection"];
                optionsBuilder.UseSqlServer(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BranchAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__BranchAc__349DA586825BCFD3");

                entity.ToTable("BranchAccount");

                entity.HasIndex(e => e.EmailAddress, "UQ__BranchAc__49A14740FE2BD0C6")
                    .IsUnique();

                entity.Property(e => e.AccountId)
                    .ValueGeneratedNever()
                    .HasColumnName("AccountID");

                entity.Property(e => e.AccountPassword)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.EmailAddress).HasMaxLength(60);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasMaxLength(30);

                entity.Property(e => e.CategoryDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FromCountry).HasMaxLength(160);
            });

            modelBuilder.Entity<SilverJewelry>(entity =>
            {
                entity.ToTable("SilverJewelry");

                entity.Property(e => e.SilverJewelryId).HasMaxLength(200);

                entity.Property(e => e.CategoryId).HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MetalWeight).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SilverJewelryDescription).HasMaxLength(250);

                entity.Property(e => e.SilverJewelryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SilverJewelries)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__SilverJew__Categ__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
