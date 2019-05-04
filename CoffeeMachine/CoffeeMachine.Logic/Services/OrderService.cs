using CoffeeMachine.Logic.Domain;
using CoffeeMachine.Logic.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Logic.Services
{
    public class OrderService : IOrderService
    {
        private readonly DemoContext db;

        public OrderService(DemoContext db)
        {
            this.db = db;
        }

        public async Task CreateOrderAsync(Order order)
        {
            var drink = await db.Drinks.FindAsync(order.Drink.CodDrink);
            OrderEntity orderEntity = new OrderEntity
            {
                Drink = drink,
                IsWinner = order.IsWinner,
                OrderDate = DateTime.UtcNow,
                Rest = order.Rest
            };
            db.Add(orderEntity);
            await db.SaveChangesAsync();
        }
    }
}
