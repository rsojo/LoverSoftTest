namespace Data.Migrations
{
    using Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.DBContext context)
        {
            var products = new List<Product>
            {
                new Product { Name = "Product 1", Description="Description for Product 1", Price = 100 , Img ="Product1.jpg"},
                new Product { Name = "Product 2", Description="Description for Product 2",Price = 190, Img ="Product2.jpg" },
                new Product { Name = "Product 3", Description="Description for Product 3",Price = 50, Img ="Product3.jpg" }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
