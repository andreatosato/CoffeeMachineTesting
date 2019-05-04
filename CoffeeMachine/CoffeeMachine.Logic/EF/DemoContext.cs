using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Logic.EF
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<DrinkEntity> Drinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var coffee = new DrinkEntity
            {
                CodDrink = "COFFEE",
                DrinkName = "Italian Coffee",
                Price = 1m
            };
            var the = new DrinkEntity
            {
                CodDrink = "THE",
                DrinkName = "Tè",
                Price = 0.8m
            };
            var cappuccino = new DrinkEntity
            {
                CodDrink = "CAPPUCCINO",
                DrinkName = "Cappuccino",
                Price = 1.2m
            };
            modelBuilder.Entity<DrinkEntity>().HasData(new [] { coffee, the, cappuccino });
        }
    }
}
