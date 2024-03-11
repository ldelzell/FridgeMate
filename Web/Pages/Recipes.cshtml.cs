using BLL.Managers;
using BLL.Models;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using Web.ViewModels;

namespace Web.Pages
{
    public class RecipesModel : PageModel
    {
        private readonly RecipeManager recipeManager;
        private readonly UserManager userManager;
        public ProductManager productManager;
        public RecipesModel()
        {
            recipeManager = new RecipeManager(new RecipeDataAccess());
            userManager = new UserManager(new UserDataAccess());
            productManager = new ProductManager(new ProductDataAccess());   
        }

        public string Message { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? recipePageId { get; set; } = 1;
        public List<Recipe> Recipes { get; private set; }
        public Recipe Recipe { get; set; }
        [BindProperty(SupportsGet = true)]
        public string RecipetId { get; set; }
        public int TotalPages { get; private set; }
        public int PageSizeDynamic { get; set; }
        [BindProperty]
        public UserViewModel UserModel { get; set; }
        [BindProperty]
        public string RecipeType { get; set; }
        public IEnumerable<Recipe> FilteredRecipes { get; set; }
        public void OnGet(int? Index, int? PageSizeDynamic)
        {
            int defaultPageSize = 12;
            var pageIndex = Index ?? 1;
            int pageSize = PageSizeDynamic ?? defaultPageSize;
            TotalPages = (int)Math.Ceiling((double)recipeManager.GetAllRecipeCount() / pageSize);

            // Ensure CurrentPage is within valid range
            pageIndex = Math.Max(1, Math.Min(pageIndex, TotalPages));

            Recipes = recipeManager.GetRecipesPagination(pageIndex, pageSize);
        }
        public IActionResult OnPostGenerateRecipe() {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("LogIn");
            }
            var pageIndex = recipePageId ?? 1;
            int pageSize = 12;
            TotalPages = (int)Math.Ceiling((double)recipeManager.GetAllRecipeCount() / pageSize);

            pageIndex = Math.Max(1, Math.Min(pageIndex, TotalPages));


            var userId = User.FindFirst("id");
            if (userId == null)
            {
                return RedirectToPage("LogIn");
            }

            int id = int.Parse(userId.Value);

            //get recipes by users fridge
            Algorithm generator = new Algorithm(productManager, recipeManager);
            List<Recipe> matchingRecipes = generator.GetMatchingRecipes(id, pageIndex, pageSize);
            Recipes = matchingRecipes;

            if (Recipes == null)
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
        //public IActionResult OnPostFilter() {
        //    ModelState.Clear();
        //    if (!TryValidateModel(nameof(RecipeType)))
        //    {
        //        string errorMessage = "Null";
        //        ViewData["ErrorMessage"] = errorMessage;
        //        return Page();
        //    }
        //    else
        //    {

        //        FilteredRecipes = recipeManager.RecipeFilterType(RecipeType);
        //        return Page();
        //    }
        //}
    }
}
