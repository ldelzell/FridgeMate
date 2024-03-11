using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Recipe_Classes
{
    public class BreakfastRecipe : Recipe
    {
        public string Sweets { get; private set; }
        public BreakfastRecipe(int id, string name, RecipeType type, List<string> ingredients, string description, string image, string sweets)
            : base(id, name, type, ingredients, description, image)
        {
            Sweets = sweets;
        }
        public BreakfastRecipe(int id) : base(id)
        {
        }
    }
}
