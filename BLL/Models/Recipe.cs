using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public abstract class Recipe
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public RecipeType Type { get; private set; }
        public List<string> Ingredients { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public Recipe(int id, string name, RecipeType type, List<string> ingredients, string description, string imagePath)
        {
            Id = id;
            Name = name;
            Type = type;
            Description = description;
            Ingredients = ingredients;
            ImagePath = imagePath;
        }
        public Recipe(int id) { 
            Id = id;
        }

    }
}
