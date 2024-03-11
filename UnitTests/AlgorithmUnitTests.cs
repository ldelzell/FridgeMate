using BLL.Interfaces;
using BLL.Managers;
using BLL.Models;
using BLL.Models.Recipe_Classes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class AlgorithmUnitTests
    {
        public RecipeManager recipeManager = new(new Mock<IRecipeDataAccess>().Object);
        public ProductManager productManager = new(new Mock<IProductDataAccess>().Object);


        [TestMethod]
        public void TestGenerateRandomUsername()
        {
            Algorithm generator = new Algorithm(productManager, recipeManager);

            string originalUsername = "testUser";
            double probability = 0.1;
            string generatedUsername = generator.GenerateRandomUsername(originalUsername, probability);
            
            Assert.IsFalse(string.IsNullOrEmpty(generatedUsername));

            Assert.AreEqual(originalUsername.Length, generatedUsername.Length);

            bool atLeastOneDifferent = false;
            for (int i = 0; i < originalUsername.Length; i++)
            {
                if (originalUsername[i] != generatedUsername[i])
                {
                    atLeastOneDifferent = true;
                    break;
                }
            }
            Assert.IsTrue(atLeastOneDifferent);

            Assert.AreNotEqual(originalUsername, generatedUsername);
        }
        [TestMethod]
        public void TestHowRandomTheAlgorithmIs() {
            Algorithm generator = new Algorithm(productManager, recipeManager);

            Dictionary<char, int> charFrequency = new Dictionary<char, int>();

            for (int j = 0; j < 1000; j++)
            {
                string username = "testUser";
                string randomUsername = generator.GenerateRandomUsername(username, 0.1);

                Assert.AreNotEqual(username, randomUsername);

                for (int i = 0; i < username.Length; i++)
                {
                    char originalChar = username[i];
                    char generatedChar = randomUsername[i];

                    if (originalChar != generatedChar)
                    {
                        if (!charFrequency.ContainsKey(generatedChar))
                        {
                            charFrequency[generatedChar] = 1;
                        }
                        else
                        {
                            charFrequency[generatedChar]++;
                        }
                    }
                }
            }
            foreach (var pair in charFrequency)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        [TestMethod]
        public void GenerateRandomUsernameProbabilityIsOne()
        {
            Algorithm generator = new Algorithm(productManager, recipeManager);
            string username = "testUser";
            double probability = 1;

            string result = generator.GenerateRandomUsername(username, probability);

            Assert.AreNotEqual(username, result);
        }

        [TestMethod]
        public void GenerateRandomUsernameProbabilityBetweenZeroAndOne()
        {
            Algorithm generator = new Algorithm(productManager, recipeManager);
            string username = "testUser";
            double probability = 0.5;

            string result = generator.GenerateRandomUsername(username, probability);

            Assert.AreNotEqual(username, result);
            int differenceCount = generator.GetDifferenceCount(username, result);

            bool isTrue = differenceCount > 0 && differenceCount <= (int)(username.Length * probability);
            Assert.IsTrue(isTrue);
        }

        [TestMethod]
        public void GetMatchingRecipesWhenThereAreMatches()
        {
            var userProducts = new List<Product>
            {
            new Product(
                1,
                1,
                "Egg",
                "protein",
                600,
                DateTime.Now,
                13,
                "jhdjksmds.jpg"
                )
            {
            },
                new Product (
                     2,
                    1,
                    "Meat",
                    "Protein",
                    200,
                    DateTime.Now,
                    4,
                    "jhdjksmds.jpg"
                    )
                {
                }
            };
            var ingredientsList1 = new List<string> { "Meat", "Milk", "Rice" };
            var recipeMock1 = new BreakfastRecipe(1, "Recipe1", RecipeType.BREAKFAST, ingredientsList1, "s", "s", "s");

            var ingredientsList2 = new List<string> { "Milk", "Bread", "Butter" };
            var recipeMock2 = new BreakfastRecipe(2, "Recipe2", RecipeType.BREAKFAST, ingredientsList2, "s", "s", "s");

            var allRecipes = new List<Recipe>
            {
                recipeMock1,
                recipeMock2,
            };

            Algorithm generator = new Algorithm(productManager, recipeManager);

            var result = generator.FindMatchingRecipes(userProducts, allRecipes);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count); 
            Assert.AreEqual("Recipe1", result[0].Name); 
        }
    


        [TestMethod]
        public void FindMatchingRecipesWhenNoMatch()
        {
            var userProducts = new List<Product>
            {
            new Product(
                1,
                1,
                "Egg",
                "protein",
                600,
                DateTime.Now,
                13,
                "jhdjksmds.jpg"
                )
            {
            },
                new Product (
                     2,
                    1,
                    "Meat",
                    "Protein",
                    200,
                    DateTime.Now,
                    4,
                    "jhdjksmds.jpg"
                    )
                {
                }
            };
            var ingredientsList = new List<string> { "Potatos", "Milk", "Rice" };
            var recipeMock1 = new BreakfastRecipe(1, "d", RecipeType.BREAKFAST, ingredientsList, "s", "s", "s");

            var recipeMock2 = new BreakfastRecipe(2, "d", RecipeType.BREAKFAST, ingredientsList, "s", "s", "s");

            var allRecipes = new List<Recipe>
        {
            recipeMock1,
            recipeMock2,
        };

            Algorithm generator = new Algorithm(productManager, recipeManager);

            var result = generator.FindMatchingRecipes(userProducts, allRecipes);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count); 
        }
    }
    
}
