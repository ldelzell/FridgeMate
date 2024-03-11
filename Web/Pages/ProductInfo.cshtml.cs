using BLL.Managers;
using BLL.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class ProductInfoModel : PageModel
    {
        public Product? Product { get; private set; }
        [BindProperty(SupportsGet = true)]
        public string ProductId { get; set; }
        ProductManager productManager;  
        public ProductInfoModel() 
        {
            productManager = new ProductManager(new ProductDataAccess());
        }
        public void OnGet()
        {
            Product = productManager.GetProductById(Convert.ToInt32(ProductId));
        }
        public IActionResult OnPostAddToBasket(int itemId)
        {
            Product = productManager.GetProductById(itemId);
            var basketItemIds = new List<int>();

            if (Request.Cookies["basket"] != null)
            {
                var cookieValues = Request.Cookies["basket"].Split(',');

                foreach (var value in cookieValues)
                {
                    if (int.TryParse(value, out int parsedItemId))
                    {
                        basketItemIds.Add(parsedItemId);
                    }
                    // Handle the case where parsing fails, if necessary
                }
            }

            basketItemIds.Add(itemId);

            Response.Cookies.Append("basket", string.Join(",", basketItemIds), new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(1),
                Path = "/"
            });

            return RedirectToPage("/PublicFridge");
        }
    }
}

