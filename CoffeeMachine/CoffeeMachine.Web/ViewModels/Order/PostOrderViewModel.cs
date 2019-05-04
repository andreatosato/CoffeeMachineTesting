using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMachine.Web.ViewModels.Order
{
    public class PostOrderViewModel
    {
        public string DrinkSelected { get; set; }
        public decimal CoinInserted { get; set; }
    }
}
