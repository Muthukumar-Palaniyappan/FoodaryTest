using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rewards.Data.Models
{
    public class RewardsEntities:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<PointsPromotion> PointsPromotions { get; set; }
        public DbSet<DiscountPromotion> DiscountPromotions { get; set; }
        public DbSet<DiscountPromotionProduct> DiscountPromotionProducts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SqlExpress01;Initial Catalog=StoreDB;Integrated Security=true;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().
                HasKey(p => p.ProductId).
                HasName("PrimaryKey_ProductId");

            modelBuilder.Entity<Product>()
            .HasData(GetProducts());

            modelBuilder.Entity<PointsPromotion>()
                .HasKey(p => p.PointsPromotionId)
                .HasName("PrimaryKey_PointsPromotionId");
            modelBuilder.Entity<PointsPromotion>()
                .HasData(GetPointsPromotions());

            modelBuilder.Entity<DiscountPromotion>()
                .HasKey(p => p.DiscountPromotionId)
                .HasName("PrimaryKey_DiscountPromotionId");
            modelBuilder.Entity<DiscountPromotion>()
                .HasData(GetDiscountPromotions());

            modelBuilder.Entity<DiscountPromotionProduct>()
                .HasKey(p => p.DiscountPromotionsProductID)
                .HasName("PrimaryKey_DiscountPromotionsProductID");

            modelBuilder.Entity<DiscountPromotionProduct>()
                .HasOne(d => d.Product)
                .WithMany(p => p.DiscountPromotionProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_DiscountPromotionProducts_Product");

            modelBuilder.Entity<DiscountPromotionProduct>()
                .HasOne(d => d.DiscountPromotion)
                .WithMany(p => p.DiscountPromotionProducts)
                .HasForeignKey(d => d.DiscountPromotionId)
                .HasConstraintName("FK_DiscountPromotionProducts_DiscountPromotion");

            modelBuilder.Entity<DiscountPromotionProduct>()
                .HasData(GetDiscountPromotionProducts());


        }


     
        private Product[] GetProducts()
        {
            return new List<Product> {
                new Product { ProductId = "PRD01", ProductName = "Vortex 95", Category = "Fuel", UnitPrice = 1.2M },
                new Product { ProductId = "PRD02", ProductName = "Vortex 98", Category = "Fuel", UnitPrice = 1.3M },
                new Product { ProductId = "PRD03", ProductName = "Diesel", Category = "Fuel", UnitPrice = 1.1M },
                new Product { ProductId = "PRD04", ProductName = "Twix 55g", Category = "Shop", UnitPrice = 2.3M },
                new Product { ProductId = "PRD05", ProductName = "Mars 72g", Category = "Shop", UnitPrice = 5.1M },
                new Product { ProductId = "PRD06", ProductName = "SNICKERS 72G", Category = "Shop", UnitPrice = 3.4M },
                new Product { ProductId = "PRD07", ProductName = "Bounty 363g", Category = "Shop", UnitPrice = 6.9M },
                new Product { ProductId = "PRD08", ProductName = "Snickers 50g", Category = "Shop", UnitPrice = 4.0M }
             }.ToArray();

        }

        private PointsPromotion[] GetPointsPromotions()
        {
            return new List<PointsPromotion> {
                new PointsPromotion { PointsPromotionId = "PP001", PromotionName = "New Year Promo", StartDate=new DateTime(2020,01,01),
                    EndDate = new DateTime(2020,01,30),Category = "Any", PointsPerDollar = 2M },
                new PointsPromotion { PointsPromotionId = "PP002", PromotionName = "Fuel Promo", StartDate=new DateTime(2020,02,05),
                    EndDate = new DateTime(2020,02,15),Category = "Fuel", PointsPerDollar = 3M },
                new PointsPromotion { PointsPromotionId = "PP003", PromotionName = "Shop Promo", StartDate=new DateTime(2020,03,01),
                    EndDate = new DateTime(2020,03,20),Category = "Shop", PointsPerDollar = 4M },
             }.ToArray();

        }

        private DiscountPromotion[] GetDiscountPromotions()
        {
            return new List<DiscountPromotion> {
                new DiscountPromotion { DiscountPromotionId = "DP001", PromotionName = "Fuel Discount Promo", StartDate=new DateTime(2020,01,01),
                    EndDate = new DateTime(2020,02,15),DiscountPercent=20M },
                new DiscountPromotion { DiscountPromotionId = "DP002", PromotionName = "Happy Promo", StartDate=new DateTime(2020,03,02),
                    EndDate = new DateTime(2020,03,20),DiscountPercent=15M },

             }.ToArray();

        }
        private DiscountPromotionProduct[] GetDiscountPromotionProducts()
        {
            return new List<DiscountPromotionProduct> {
                new DiscountPromotionProduct{ DiscountPromotionsProductID=1, DiscountPromotionId = "DP001", ProductId="PRD01" },
                new DiscountPromotionProduct{ DiscountPromotionsProductID=2, DiscountPromotionId = "DP001", ProductId="PRD02" }

             }.ToArray();

        }
    }
}
