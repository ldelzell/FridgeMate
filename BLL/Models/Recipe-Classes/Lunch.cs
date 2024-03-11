using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BLL.Models.Recipe_Classes
{
    public class LunchRecipe : Recipe
    {
        public string SideDish { get; private set; }
        public LunchRecipe(int id, string name, RecipeType type,  List<string> ingredients, string description, string image, string sideDish)
            : base(id, name, type, ingredients, description,  image)
        {
            SideDish = sideDish;
        }
        public LunchRecipe(int id) : base(id)
        {
        }
    }
}
