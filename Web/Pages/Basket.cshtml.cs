using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Net.Http.Json;
using BLL.Managers;
using DAL;
using Microsoft.AspNetCore.Authorization;

namespace Web.Pages
{
    [Authorize]
    public class BasketModel : PageModel
    {
        private  ProductManager productManager;
        public OrderNumberGenerator randomNumberGenerator;
        public List<Product> BasketItems { get; set; }
        public string OrderNumber { get; set; }
        public double ProductSum { get; set; }
        public double ShippingPrice { get; set; }
        public double TotalSum { get; set; }
        public string BasketItemsCheck { get; set; }
        public BasketModel()
        {
            productManager = new ProductManager(new ProductDataAccess());
            randomNumberGenerator = new OrderNumberGenerator();
        }

        public IActionResult OnGet()
        {
            var basketItemIds = Request.Cookies["basket"]?.Split(',')
                                .Where(itemId => !string.IsNullOrWhiteSpace(itemId))
                                .Select(int.Parse)
                                .ToList() ?? new List<int>();

            var validBasketItemIds = basketItemIds
                                    .Where(itemId => itemId != 0)
                                    .ToList();

            var basketItems = validBasketItemIds
                              .Select(itemId => productManager.GetProductById(itemId))
                              .ToList();

            BasketItems = basketItems;

            Response.Cookies.Append("basket", string.Join(",", validBasketItemIds), new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(1),
                Path = "/"
            });

            OrderNumber = randomNumberGenerator.GenerateOrderNumber();
            ProductSum = basketItems.Sum(item => item.Price);
            ShippingPrice = 12.99;
            TotalSum = Math.Round(ProductSum + ShippingPrice, 2);
            return Page();
        }

        public IActionResult OnPostRemoveItem(string itemId)
        {
            string basketCookie = Request.Cookies["basket"];
            
            if (!string.IsNullOrEmpty(basketCookie))
            {
                var basketItems = basketCookie.Split(',');

                basketItems = basketItems.Where(id => id != itemId).ToArray();

                string updatedBasketCookie = string.Join(",", basketItems);

                Response.Cookies.Append("basket", updatedBasketCookie);
            }
            return RedirectToPage("/Basket");
        }
    }
}
