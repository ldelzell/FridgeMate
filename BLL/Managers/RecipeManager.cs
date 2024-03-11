using BLL.Interfaces;
using BLL.Models;
using BLL.Models.Recipe_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class RecipeManager
    {
        public IRecipeDataAccess data;

        public RecipeManager(IRecipeDataAccess data)
        {
            this.data = data;
        }
        public bool CreateBreakfast(BreakfastRecipe breakfast)
        {
            return data.CreateBreakfast(breakfast);
        }
        public bool CreateLunch(LunchRecipe lunch)
        {
            return data.CreateLunch(lunch);
        }
        public bool CreateDinner(DinnerRecipe dinner)
        {
            return data.CreateDinner(dinner);
        }
        public List<Recipe> GetAllRecipes()
        {
            return data.GetAllRecipes();
        }
        public Recipe? GetRecipeById(int id)
        {
            return data.GetRecipeById(id);
        }
        public bool AddImage(Image image)
        {
            return data.AddImage(image);
        }
        public bool DeleteRecipe(Recipe recipe)
        {
            return data.DeleteRecipe(recipe.Id);
        }
        public string GetImagePathById(int id)
        {
            return data.GetImagePathById(id);
        }
        public int GetAllRecipeCount() { 
            return data.GetAllRecipeCount();
        }

        public List<Recipe> GetRecipesPagination(int page, int pageSize) { 
            return data.GetRecipesPagination(page, pageSize);
        }
        public List<Recipe> GetRecipesForUser(int userId, int pageSize, int offset) { 
            return data.GetRecipesForUser(userId, pageSize, offset);
        }
        public IEnumerable<Recipe> RecipeFilterType(string type)
        {
            return data.RecipeFilterType(type);
        }
    }
}
