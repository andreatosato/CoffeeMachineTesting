using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeMachine.Logic.Domain;
using CoffeeMachine.Logic.Services;
using CoffeeMachine.Web.ViewModels.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
                

        [HttpPost]
        public async Task<IActionResult> PostOrder(PostOrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO Logic
                Drink drinkSelected = null;
                switch (orderViewModel.DrinkSelected)
                {
                    case "coffee":
                        drinkSelected = new Coffee();
                        break;
                    case "te":
                        drinkSelected = new The();
                        break;
                    case "cappuccino":
                        drinkSelected = new Cappuccino();
                        break;
                }
                await _orderService.CreateOrderAsync(new Logic.Domain.Order(drinkSelected, orderViewModel.CoinInserted));
            }
            return Ok();
        }
    }
}