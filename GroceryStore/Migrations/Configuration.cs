namespace GroceryStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<GroceryStore.DAL.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GroceryStore.DAL.StoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var categories = new List<Category>
            {
                new Category { Name = "Clothes" },
                new Category { Name = "Play and Toys" },
                new Category { Name = "Feeding" },
                new Category { Name = "Medicine" },
                new Category { Name= "Travel" },
                new Category { Name= "Sleeping" }
            };
            categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
            var products = new List<Product>
            {
                new Product { Name = "Sleep Suit", Description="For sleeping or general wear", Price=4.99M, CategoryID=categories.Single( c => c.Name == "Clothes").ID }, new Product { Name = "Vest", Description="For sleeping or general wear",
                        Price=2.99M, CategoryID=categories.Single( c => c.Name == "Clothes").ID },
                new Product { Name = "Orange and Yellow Lion", Description="Makes a squeaking noise", Price=1.99M, CategoryID=categories.Single( c => c.Name == "Play and Toys").ID },
                new Product { Name = "Blue Rabbit", Description="Baby comforter", Price=2.99M, CategoryID=categories.Single(c => c.Name == "Play and Toys").ID }
            };

            products.ForEach(c => context.Products.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

        }
    }
}
