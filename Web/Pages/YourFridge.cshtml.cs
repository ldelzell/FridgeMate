using BLL.Managers;
using BLL.Models;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.ViewModels;

namespace Web.Pages
{
    public class YourFridgeModel : PageModel
    {
        public ProductManager productManager;
        public UserManager userManager;
        public YourFridgeModel()
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
        public IActionResult OnGet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("LogIn");
            }
            var pageIndex = Index ?? 1;
            int pageSize = 12;
            TotalPages = (int)Math.Ceiling((double)productManager.GetAllProductCount() / pageSize);

            // Ensure CurrentPage is within valid range
            pageIndex = Math.Max(1, Math.Min(pageIndex, TotalPages));


            var userId = User.FindFirst("id");
            if (userId == null)
            {
                return RedirectToPage("LogIn");
            }

            int id = int.Parse(userId.Value);
            Products = productManager.GetProductsByUserId(id, pageIndex, pageSize);
            if (Products == null)
            {
                string errorMessage = "Null";
                ViewData["ErrorMessage"] = errorMessage;
            }
            else
            {
                var user = userManager.GetUserById(id);
                if (user == null)
                {
                    string errorMessage = "User Null";
                    ViewData["ErrorMessage"] = errorMessage;
                }
                else
                {
                    UserModel = new(
                        user.FirstName,
                        user.LastName,
                        user.PhoneNumber,
                        user.Username,
                        user.Email,
                        user.Password
                    );
                }
            }
            return Page();
        }
        public IActionResult OnPostRemoveProduct()
        {
            if (!int.TryParse(ProductId, out int productId))
            {
                return RedirectToPage("ErrorPage");
            }

            bool success = productManager.RemoveProductFromUserFridge(productId);

            if (success)
            {
                TempData["Message"] = "The Product was successfully removed!";
            }
            else
            {
                string errorMessage = "There was a problem with removing the product!";
                ViewData["ErrorMessage"] = errorMessage;
            }

            return RedirectToPage(); // Redirect back to the same page after processing the removal
        }


    }
}
