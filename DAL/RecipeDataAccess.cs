using BLL.Interfaces;
using BLL.Models;
using BLL.Models.Recipe_Classes;
using ClassLibrary.Extentions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RecipeDataAccess : IRecipeDataAccess
    {
        public bool CreateBreakfast(BreakfastRecipe breakfastRecipe)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    Conn.Open();
                    string concatenatedProducts = string.Join(",", breakfastRecipe.Ingredients);
                    string sql = "INSERT INTO recipe (name, type, mainIngredient, description, sweet, sideDish, protein, vegetable,image_path) " +
                        "VALUES (@name, @type, @mainIngredient, @description, @sweet, @sideDish, @protein, @vegetable,@image_path)";
                    var cmd = new MySqlCommand(sql, Conn);
                    cmd.Parameters.AddWithValue("@name", breakfastRecipe.Name);
                    cmd.Parameters.AddWithValue("@type", breakfastRecipe.Type.ToString());
                    cmd.Parameters.AddWithValue("@mainIngredient", concatenatedProducts);
                    cmd.Parameters.AddWithValue("@description", breakfastRecipe.Description);
                    cmd.Parameters.AddWithValue("@sweet", breakfastRecipe.Sweets);
                    cmd.Parameters.AddWithValue("@sideDish", 0);
                    cmd.Parameters.AddWithValue("@protein", 0);
                    cmd.Parameters.AddWithValue("@vegetable", 0);
                    cmd.Parameters.AddWithValue("@image_path", breakfastRecipe.ImagePath);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Sorry, the recipe COULD NOT be created currently. Please try again later!");
                }
                finally
                {
                    Conn.Close();
                }
            }
        }

        public bool CreateLunch(LunchRecipe lunchRecipe)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    Conn.Open();
                    string concatenatedProducts = string.Join(",", lunchRecipe.Ingredients);
                    string sql = "INSERT INTO recipe (name, type, mainIngredient, description, sweet, sideDish, protein, vegetable,image_path) " +
                        "VALUES (@name, @type, @mainIngredient, @description, @sweet, @sideDish, @protein, @vegetable, @image_path)";
                    var cmd = new MySqlCommand(sql, Conn);
                    cmd.Parameters.AddWithValue("@name", lunchRecipe.Name);
                    cmd.Parameters.AddWithValue("@type", lunchRecipe.Type.ToString());
                    cmd.Parameters.AddWithValue("@description", lunchRecipe.Description);
                    cmd.Parameters.AddWithValue("@mainIngredient", concatenatedProducts);
                    cmd.Parameters.AddWithValue("@sweet", 0);
                    cmd.Parameters.AddWithValue("@sideDish", lunchRecipe.SideDish);
                    cmd.Parameters.AddWithValue("@protein", 0);
                    cmd.Parameters.AddWithValue("@vegetable", 0);
                    cmd.Parameters.AddWithValue("@image_path", lunchRecipe.ImagePath);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Sorry, the recipe COULD NOT be created currently. Please try again later!");
                }
                finally
                {
                    Conn.Close();
                }
            }
        }
        public bool CreateDinner(DinnerRecipe dinnerRecipe)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    Conn.Open();
                    string concatenatedProducts = string.Join(",", dinnerRecipe.Ingredients);
                    string sql = "INSERT INTO recipe (name, type, mainIngredient, description, sweet, sideDish, protein, vegetable,image_path) " +
                        "VALUES (@name, @type, @mainIngredient, @description, @sweet, @sideDish, @protein, @vegetable, @image_path)";
                    var cmd = new MySqlCommand(sql, Conn);
                    cmd.Parameters.AddWithValue("@name", dinnerRecipe.Name);
                    cmd.Parameters.AddWithValue("@type", dinnerRecipe.Type.ToString());
                    cmd.Parameters.AddWithValue("@mainIngredient", concatenatedProducts);
                    cmd.Parameters.AddWithValue("@description", dinnerRecipe.Description);
                    cmd.Parameters.AddWithValue("@sweet", 0);
                    cmd.Parameters.AddWithValue("@sideDish", 0);
                    cmd.Parameters.AddWithValue("@protein", dinnerRecipe.Protein);
                    cmd.Parameters.AddWithValue("@vegetable", dinnerRecipe.Vegetable);
                    cmd.Parameters.AddWithValue("@image_path", dinnerRecipe.ImagePath);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Sorry, the recipe COULD NOT be created currently. Please try again later!");
                }
                finally
                {
                    Conn.Close();
                }
            }
        }
        public List<Recipe> GetAllRecipes()
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                Conn.Open();
                string sql = "SELECT * FROM recipe";
                var cmd = new MySqlCommand(sql, Conn);
                var reader = cmd.ExecuteReader();
                List<Recipe> recipes = new List<Recipe>();
                while (reader.Read())
                {
                    int recipeId = reader.GetInt32("recipe_id");
                    string name = reader.GetString("name");
                    RecipeType type = Extentions.ParseEnum<RecipeType>(reader.GetString("type"));
                    string mainIngredientString = reader.GetString("mainIngredient");
                    List<string> mainIngredient = mainIngredientString.Split(',').ToList();
                    string description = reader.GetString("description");
                    string sweets = reader.GetString("sweet");
                    string sideDish = reader.GetString("sideDish");
                    string protein = reader.GetString("protein");
                    string vegetable = reader.GetString("vegetable");   
                    string imagePath = reader.GetString("image_path");

                    Recipe recipe;
                    switch (type)
                    {
                        case RecipeType.BREAKFAST:
                            recipe = new BreakfastRecipe(recipeId, name, type, mainIngredient, description, imagePath, sweets);
                            break;
                        case RecipeType.LUNCH:
                            recipe = new LunchRecipe(recipeId, name, type, mainIngredient, description, imagePath, sideDish);
                            break;
                        case RecipeType.DINNER:
                            recipe = new DinnerRecipe(recipeId, name, type, mainIngredient, description, imagePath, protein, vegetable);
                            break;
                        default:
                            throw new InvalidOperationException("Unknown recipe type");
                    }

                    recipes.Add(recipe);
                }
                return recipes;
            }
        }
        public Recipe GetRecipeById(int id)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                Conn.Open();
                string sql = "SELECT * FROM recipe WHERE recipe_id = @recipeId";
                var cmd = new MySqlCommand(sql, Conn);
                cmd.Parameters.AddWithValue("@recipeId", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int recipeId = reader.GetInt32("recipe_id");
                        RecipeType recipeType = Extentions.ParseEnum<RecipeType>(reader.GetString("type"));
                        string ingredientsString = reader.GetString("mainIngredient");
                        List<string> ingredients = ingredientsString.Split(',').ToList();
                        string description = reader.GetString("description");
                        string sweet = reader.GetString("sweet");
                        string sideDish = reader.GetString("sideDish");
                        string protein = reader.GetString("protein");
                        string vegetable = reader.GetString("vegetable");
                        string imagePath = reader.GetString("image_path");

                        Recipe recipe;
                        if (recipeType == RecipeType.BREAKFAST)
                        {
                            recipe = new BreakfastRecipe(recipeId, reader.GetString("name"), recipeType, ingredients, description, imagePath, sweet);
                        }
                        else if (recipeType == RecipeType.LUNCH)
                        {
                            recipe = new LunchRecipe(recipeId, reader.GetString("name"), recipeType, ingredients, description, imagePath, sideDish);
                        }
                        else if (recipeType == RecipeType.DINNER)
                        {
                            recipe = new DinnerRecipe(recipeId, reader.GetString("name"), recipeType, ingredients, description, imagePath, protein, vegetable);
                        }
                        else {
                            throw new Exception("Error");
                        }
                        
                        return recipe;
                    }
                }

                return null;
            }
        }

        public bool AddImage(Image image)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                long id;
                Conn.Open();
                string sql = "INSERT INTO productimage (image_path, image_value) " +
                    "values (@image_path, @image_value)";

                var cmd = new MySqlCommand(sql, Conn);

                cmd.Parameters.AddWithValue("@image_id", image.Id);
                cmd.Parameters.AddWithValue("@image_value", image.ImageValue);
                return cmd.ExecuteNonQuery() > 0;
                try
                {
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Sorry, the account COULD NOT be created currently. Please try again later!");
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }
        }
        public bool DeleteRecipe(int id)
        {
            bool success = false;
            try
            {
                using (MySqlConnection con = ConnectionString.Connection())
                {
                    string sqlQuery = "DELETE FROM recipe WHERE recipe_id = @Id";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    success = (rowsAffected == 1);

                    if (success)
                    {
                        Product product = new Product(id);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("An error occurred while deleting a product: " + ex.Message);
            }

            return success;
        }
        public string GetImagePathById(int id)
        {
            string imagePath = null;
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    Conn.Open();
                    string sql = "select image_path FROM recipe WHERE recipe_id = @recipeId";
                    var cmd = new MySqlCommand(sql, Conn);

                    cmd.Parameters.AddWithValue("@recipeId", id);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        imagePath = reader.GetString("image_path");
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Failed to retrieve image path from the database. Please try again!", ex);
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }

            return imagePath;
        }
        public int GetAllRecipeCount()
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                Conn.Open();
                string sql = "SELECT COUNT(*) FROM recipe";
                var cmd = new MySqlCommand(sql, Conn);
                long count = (long)cmd.ExecuteScalar();
                return Convert.ToInt32(count);
            }
        }
        public List<Recipe> GetRecipesPagination(int page, int pageSize)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                Conn.Open();
                var offset = (page - 1) * pageSize;
                var selectCommand = new MySqlCommand("SELECT * FROM recipe ORDER BY recipe_id LIMIT @PageSize OFFSET @Offset", Conn);
                selectCommand.Parameters.AddWithValue("@Offset", offset);
                selectCommand.Parameters.AddWithValue("@PageSize", pageSize);

                var reader = selectCommand.ExecuteReader();
                List<Recipe> recipes = new List<Recipe>();

                while (reader.Read())
                {
                    int recipeId = reader.GetInt32("recipe_id");
                    string name = reader.GetString("name");
                    RecipeType type = Extentions.ParseEnum<RecipeType>(reader.GetString("type"));
                    string mainIngredientString = reader.GetString("mainIngredient");
                    List<string> mainIngredient = mainIngredientString.Split(',').ToList();
                    string description = reader.GetString("description");
                    string imagePath = reader.GetString("image_path");
                    string sweets = reader.GetString("sweet");
                    string sideDish = reader.GetString("sideDish");
                    string protein = reader.GetString("protein");
                    string vegetable = reader.GetString("vegetable");

                    Recipe recipe;

                    switch (type)
                    {
                        case RecipeType.BREAKFAST:
                            recipe = new BreakfastRecipe(recipeId, name, type, mainIngredient, description, imagePath, sweets);
                            break;
                        case RecipeType.LUNCH:
                            recipe = new LunchRecipe(recipeId, name, type, mainIngredient, description, imagePath, sideDish);
                            break;
                        case RecipeType.DINNER:
                            recipe = new DinnerRecipe(recipeId, name, type, mainIngredient, description, imagePath, protein, vegetable);
                            break;
                        default:
                            throw new InvalidOperationException("Unknown recipe type");
                    }

                    recipes.Add(recipe);
                }

                return recipes;
            }
        }
        public List<Recipe> GetRecipesForUser(int userId, int pageSize, int offset)
        {
            List<Recipe> recipes = new List<Recipe>();

            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                Conn.Open();

                using (MySqlCommand command = new MySqlCommand())
                {
                    command.Connection = Conn;
                    command.CommandType = CommandType.Text;

                    command.CommandText = "select * FROM product JOIN user_products_storage ON product.product_id = user_products_storage.product_id WHERE user_products_storage.user_id = @userId";
                    command.Parameters.AddWithValue("@UserId", userId);

                    List<string> products = new List<string>();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(reader["name"].ToString());
                        }
                    }

                    string productsString = string.Join("|", products);
                    string sqlQuery = "SELECT * FROM recipe WHERE mainIngredient REGEXP @Products";
               
                    using (MySqlCommand recipeCommand = new MySqlCommand(sqlQuery, Conn))
                    { 
                        recipeCommand.Parameters.AddWithValue("@Products", $"({productsString})");
                        recipeCommand.Parameters.AddWithValue("@PageSize", pageSize);
                        recipeCommand.Parameters.AddWithValue("@Offset", offset);

                        using (MySqlDataReader reader = recipeCommand.ExecuteReader())
                        {
                            try {
                                while (reader.Read())
                                {
                                    int recipeId = reader.GetInt32("recipe_id");
                                    string name = reader.GetString("name");
                                    RecipeType type = Extentions.ParseEnum<RecipeType>(reader.GetString("type"));
                                    string mainIngredientString = reader.GetString("mainIngredient");
                                    List<string> mainIngredient = mainIngredientString.Split(',').ToList();
                                    string description = reader.GetString("description");
                                    string imagePath = reader.GetString("image_path");
                                    string sweets = reader.GetString("sweet");
                                    string sideDish = reader.GetString("sideDish");
                                    string protein = reader.GetString("protein");
                                    string vegetable = reader.GetString("vegetable");

                                    Recipe recipe;

                                    switch (type)
                                    {
                                        case RecipeType.BREAKFAST:
                                            recipe = new BreakfastRecipe(recipeId, name, type, mainIngredient, description, imagePath, sweets);
                                            break;
                                        case RecipeType.LUNCH:
                                            recipe = new LunchRecipe(recipeId, name, type, mainIngredient, description, imagePath, sideDish);
                                            break;
                                        case RecipeType.DINNER:
                                            recipe = new DinnerRecipe(recipeId, name, type, mainIngredient, description, imagePath, protein, vegetable);
                                            break;
                                        default:
                                            throw new InvalidOperationException("Unknown recipe type");
                                    }

                                    recipes.Add(recipe);
                                }
                            } 
                            catch (Exception ex){ 
                                throw new Exception(ex.Message);
                            }
                           
                        }
                    }
                }
            }

            return recipes;
        }
        public IEnumerable<Recipe> RecipeFilterType(string type1)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    Conn.Open();
                    string sql = "SELECT * FROM recipe WHERE type = @type ORDER BY recipe_id LIMIT @PageSize OFFSET @Offset";
                    var cmd = new MySqlCommand(sql, Conn);
                    cmd.Parameters.AddWithValue("@type", type1);
                    var reader = cmd.ExecuteReader();

                    List<Recipe> recipes = new List<Recipe>();
                    while (reader.Read())
                    {
                        int recipeId = reader.GetInt32("recipe_id");
                        string name = reader.GetString("name");
                        RecipeType type = Extentions.ParseEnum<RecipeType>(reader.GetString("type"));
                        string mainIngredientString = reader.GetString("mainIngredient");
                        List<string> mainIngredient = mainIngredientString.Split(',').ToList();
                        string description = reader.GetString("description");
                        string sweets = reader.GetString("sweet");
                        string sideDish = reader.GetString("sideDish");
                        string protein = reader.GetString("protein");
                        string vegetable = reader.GetString("vegetable");
                        string imagePath = reader.GetString("image_path");

                        Recipe recipe;
                        switch (type)
                        {
                            case RecipeType.BREAKFAST:
                                recipe = new BreakfastRecipe(recipeId, name, type, mainIngredient, description, imagePath, sweets);
                                break;
                            case RecipeType.LUNCH:
                                recipe = new LunchRecipe(recipeId, name, type, mainIngredient, description, sideDish, imagePath);
                                break;
                            case RecipeType.DINNER:
                                recipe = new DinnerRecipe(recipeId, name, type, mainIngredient, description, protein, vegetable, imagePath);
                                break;
                            default:
                                throw new InvalidOperationException("Unknown recipe type");
                        }

                        recipes.Add(recipe);
                    }
                    return recipes;

                }
                catch (MySqlException ex)
                {
                    throw new Exception("Error occurred while searching recipes by type.", ex);
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }
        }

    }
}
