using BLL.Models;
using BLL.Models.Recipe_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRecipeDataAccess
    {
        bool CreateBreakfast(BreakfastRecipe breakfast);
        bool CreateLunch(LunchRecipe lunchRecipe);
        bool CreateDinner(DinnerRecipe dinner);
        List<Recipe> GetAllRecipes();
        Recipe GetRecipeById(int id);
        bool AddImage(Image image);
        bool DeleteRecipe(int id);
        string GetImagePathById(int id);
        int GetAllRecipeCount();
        List<Recipe> GetRecipesPagination(int page, int pageSize);
        List<Recipe> GetRecipesForUser(int userId, int pageSize, int offset);
        IEnumerable<Recipe> RecipeFilterType(string type);
    }
}
