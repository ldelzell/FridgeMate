using BLL.Interfaces;
using BLL.Managers;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Algorithm
    {
        private static readonly Random random = new Random();
        public ProductManager productManager;
        public RecipeManager recipeManager;

        public Algorithm(ProductManager productManager, RecipeManager recipeManager)
        {
            this.productManager = productManager;
            this.recipeManager = recipeManager;
        }

        public string GenerateRandomUsername(string username, double probability = 0.1)
        {
            probability = Math.Max(0, Math.Min(1, probability));
            string currentUsername = username;

            // String manipulation
            StringBuilder newUsername = new StringBuilder(currentUsername);

            if (probability > 0)
            {
                bool atLeastOneChange = false;

                for (int i = 0; i < newUsername.Length; i++)
                {
                    if (random.NextDouble() < probability || !atLeastOneChange)
                    {
                        char randomChar = (char)random.Next('a', 'z' + 1);

                        while (randomChar == newUsername[i])
                        {
                            randomChar = (char)random.Next('a', 'z' + 1);
                        }
                        newUsername[i] = randomChar;
                        atLeastOneChange = true;
                    }
                }
            }

            string suggestedUsername = newUsername.ToString();
            while (suggestedUsername == currentUsername)
            {
                suggestedUsername = GenerateRandomUsername(username, probability);
            }
            return suggestedUsername;
        }
        public int GetDifferenceCount(string str1, string str2)
        {
            int count = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    count++;
                }
            }
            return count;
        }
        public List<Recipe> GetMatchingRecipes(int userId, int page, int pageSize)
        {
            List<Product> userProducts = productManager.GetProductsByUserId(userId, page, pageSize);
            List<Recipe> allRecipes = recipeManager.GetAllRecipes();

            return FindMatchingRecipes(userProducts, allRecipes);
        }

        public List<Recipe> FindMatchingRecipes(List<Product> userProducts, List<Recipe> allRecipes)
        {
            allRecipes
                .Where(recipe => recipe.Ingredients.Any(ingredient => userProducts.Any(product => product.Name == ingredient)))
                .ToList();

            var filteredRecipes = allRecipes
                .Where(recipe => recipe.Ingredients.Intersect(userProducts.Select(product => product.Name)).Any())
                .ToList();

            return filteredRecipes;
        }
    }
}
