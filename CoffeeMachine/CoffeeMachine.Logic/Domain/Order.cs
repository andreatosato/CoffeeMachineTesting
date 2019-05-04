using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Logic.Domain
{
    public class Order
    {
        public Order(Drink drink, decimal paid)
        {
            Drink = drink;
            Paid = paid;
            IsWinner = CalculateWinner();
            if ((Paid - Drink.Price) < 0)
                throw new ArgumentOutOfRangeException($"Not enough money for paid {Drink.CodDrink}");
            else
            {
                if (IsWinner)
                    Rest = Paid;
                else
                    Rest = Paid - Drink.Price;
            }
        }

        public Drink Drink { get; }
        public decimal Paid { get; }
        public decimal Rest { get; }
        public bool IsWinner { get; }

        public bool CalculateWinner()
        {
            return true;
        }
    }
}
