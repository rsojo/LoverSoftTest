namespace Products.Migrations
{
    using Products.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Products.Data.ProductsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Products.Data.ProductsContext";
        }

        protected override void Seed(Products.Data.ProductsContext context)
        {
            var products = new List<Product>
            {
                new Product { Name = "Product 1", Description="Description for Product 1", Price = 100 },
                new Product { Name = "Product 2", Description="Description for Product 2",Price = 190 },
                new Product { Name = "Product 3", Description="Description for Product 3",Price = 50 },
                new Product { Name = "Product 4", Description="Description for Product 4",Price = 100 },
                new Product { Name = "Product 5", Description="Description for Product 5",Price = 190 },
                new Product { Name = "Product 6", Description="Description for Product 6",Price = 50}
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
