using BLL.Managers;
using BLL.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class RecipeInfoModel : PageModel
    {
        public Recipe? Recipe { get; private set; }
        [BindProperty(SupportsGet = true)]
        public string RecipeId { get; set; }
        RecipeManager recipeManager;

        public RecipeInfoModel()
        {
            recipeManager = new RecipeManager(new RecipeDataAccess());
        }

        public void OnGet()
        {
            if (int.TryParse(RecipeId, out int recipeIdInt))
            {
                Recipe = recipeManager.GetRecipeById(recipeIdInt);
            }
            else
            {
                RedirectToPage("Index");
            }
        }
    }

}
