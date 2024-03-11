using BLL.Managers;
using BLL.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Bcpg;
using System.Text.Json.Serialization;
using Web.ViewModels;

namespace Web.Pages
{
    public class PublicFridgeModel : PageModel
    {
        public ProductManager productManager;
        public UserManager userManager;

        public PublicFridgeModel()
        {
            productManager = new ProductManager(new ProductDataAccess());
            userManager = new UserManager(new UserDataAccess());
        }
        public string Message { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? Index { get; set; } = 1;
        public List<Product> Products { get; private set; }
        public int TotalPages { get; private set; }
        public Product Product { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ProductId { get; set; }
        [BindProperty]
        public UserViewModel UserModel { get; set; }
        public string ImagePath { get; set; }
        public int PageSizeDynamic { get; set; }
        public DateTime ProductDateOfAdding { get; set; }

            public void OnGet(int? Index, int? PageSizeDynamic)
            {
                int defaultPageSize = 6;
                var pageIndex = Index ?? 1;
                int pageSize = PageSizeDynamic ?? defaultPageSize;
                TotalPages = (int)Math.Ceiling((double)productManager.GetAllProductCount() / pageSize);

                // Ensure CurrentPage is within valid range
                pageIndex = Math.Max(1, Math.Min(pageIndex, TotalPages));

                Products = productManager.GetProductsPanagination(pageIndex, pageSize);
            }

        public IActionResult OnPostAddProductToUserFridge(int productId, int quantity) {
            Product = productManager.GetProductById(Convert.ToInt32(ProductId));


            //getting user data
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("LogIn");
            }
            var userId = User.FindFirst("id");
            if (userId == null)
            {
                return RedirectToPage("LogIn");
            }
            else
            {
                int id = int.Parse(userId.Value);
                var user = userManager.GetUserById(id);
                UserModel = new(
                    user.FirstName,
                    user.LastName,
                    user.PhoneNumber,
                    user.Username,
                    user.Email,
                    user.Password
                );
                ProductDateOfAdding = DateTime.Now;
                bool success = productManager.UserAddsProductToFridge(user.Id,productId, ProductDateOfAdding);
                if (success)
                {
                    TempData["Message"] = "The Product was successfully added!";
                }
                else {
                    string errorMessage = "Sorry! There was a problem with add the product to your fridge.";
                    ViewData["ErrorMessage"] = errorMessage;
                }
                return RedirectToPage("/PublicFridge", new { index = Index});
            }
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

            return RedirectToPage("/PublicFridge", new { index = Index });
        }

    }
}
