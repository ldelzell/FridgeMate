using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BLL.Models.Recipe_Classes
{
    public class DinnerRecipe : Recipe
    {
        public string Protein { get; set; }
        public string Vegetable { get; set; }
        public DinnerRecipe(int id, string name, RecipeType type, List<string> ingredients, string description, string image, string protein, string vegetable)
            : base(id, name, type, ingredients, description, image)
        {
            Protein = protein;
            Vegetable = vegetable;
        }
        public DinnerRecipe(int id)  : base(id)
        { 
        }
    }
}
