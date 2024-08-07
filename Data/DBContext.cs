using Data.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace Data
{
    public class DBContext : DbContext
    {
        // Your context has been configured to use a 'DBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Data.DBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DBContext' 
        // connection string in the application configuration file.
        public DBContext()
            : base("name=DBContext")
        {

        }
        public System.Data.Entity.DbSet<Product> Products { get; set; }
        public System.Data.Entity.DbSet<Purchase> Purchases { get; set; }
        public System.Data.Entity.DbSet<PurchaseProduct> PurchaseProducts { get; set; } // Add DbSet for PurchaseProduct entity

        // Declare the relationship between Purchase and Product entities
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Purchase>()
            //    .HasMany(p => p.Products)
            //    .WithMany()
            //    .Map(m =>
            //    {
            //        m.ToTable("PurchaseProduct");
            //        m.MapLeftKey("PurchaseId");
            //        m.MapRightKey("ProductId");
            //    });

            modelBuilder.Entity<PurchaseProduct>()
                .HasRequired(p => p.Purchase)
                .WithMany(p => p.PurchaseProducts)
                .HasForeignKey(p => p.PurchaseId);
             modelBuilder.Entity<PurchaseProduct>()
                .HasRequired(p => p.Product)
                .WithMany(p => p.PurchaseProducts)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.PurchaseProducts)
                .WithRequired(p => p.Product)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Purchase>()
                .HasMany(p => p.PurchaseProducts)
                .WithRequired(p => p.Purchase)
                .HasForeignKey(p => p.PurchaseId);
            modelBuilder.Entity<Purchase>()
                .HasMany(p => p.Products)
                .WithOptional(p => p.Purchase);

        }
    }

}