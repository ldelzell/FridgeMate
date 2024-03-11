using BLL.Interfaces;
using BLL.Models;
using DAL.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductDataAccess : IProductDataAccess
    {
        public bool CreateProduct(Product product)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    long id;
                    Conn.Open();
                    string sql = "INSERT INTO product (type_id, name, nutrients, quantity, expirationDate, price, image_path) " +
                        "values (@type_id, @name, @nutrients, @quantity,@expirationDate, @price,@image_path)";
                    var cmd = new MySqlCommand(sql, Conn);
                    cmd.Parameters.AddWithValue("@type_id", product.TypeId);
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@nutrients", product.Nutrients);
                    cmd.Parameters.AddWithValue("@quantity", product.Quantity);
                    cmd.Parameters.AddWithValue("@expirationDate", product.ExpirationDate);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@image_path", product.ImagePath);
                    return cmd.ExecuteNonQuery() > 0;
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
        
        public List<Product> GetAllProducts()
        {
            byte[] data = null;
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    Conn.Open();
                    string sql = "SELECT * FROM product JOIN food_type ON product.type_id = food_type.type_id";
                    var cmd = new MySqlCommand(sql, Conn);
                    var reader = cmd.ExecuteReader();
                    List<Product> products = new List<Product>();
                    while (reader.Read())
                    {
                        Product product = new Product(
                        reader.GetInt32("product_id"),
                        reader.GetInt32("type_id"),
                        reader.GetString("name"),
                        reader.GetString("nutrients"),
                        reader.GetInt32("quantity"),
                        reader.GetDateTime("expirationDate"),
                        reader.GetDouble("price"),
                        reader.GetString("image_path")
                        );
                        products.Add(product);
                    }
                    return products;
                }
                catch (MySqlException ex)
                {
                    throw new Exception("We couldn't load products");
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }
        }
        public List<Product> GetProductsPanagination(int page, int pageSize)
        {
            var products = new List<Product>();
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                Conn.Open();
                var offset = (page - 1) * pageSize;
                var selectCommand = new MySqlCommand("SELECT * FROM product ORDER BY product_id LIMIT @PageSize OFFSET @Offset", Conn);
                selectCommand.Parameters.AddWithValue("@Offset", offset);
                selectCommand.Parameters.AddWithValue("@PageSize", pageSize);

                using (var reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product(
                        reader.GetInt32("product_id"),
                        reader.GetInt32("type_id"),
                        reader.GetString("name"),
                        reader.GetString("nutrients"),
                        reader.GetInt32("quantity"),
                        reader.GetDateTime("expirationDate"),
                        reader.GetDouble("price"),
                        reader.GetString("image_path")
                        );
                        products.Add(product);
                    }
                }
            }
            return products;
        }
        public int GetAllProductCount() {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                Conn.Open();
                string sql = "SELECT COUNT(*) FROM product JOIN food_type ON product.type_id = food_type.type_id";
                var cmd = new MySqlCommand(sql, Conn);
                long count = (long)cmd.ExecuteScalar();
                return Convert.ToInt32(count);
            }
        }
       public Product GetProductById(int id){

            byte[] data = null;
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    Conn.Open();
                    string sql = "select * FROM product WHERE product_id = @productId";
                    var cmd = new MySqlCommand(sql, Conn);

                    cmd.Parameters.AddWithValue("@productId", id);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Product product = new Product(
                        reader.GetInt32("product_id"),
                        reader.GetInt32("type_id"),
                        reader.GetString("name"),
                        reader.GetString("nutrients"),
                        reader.GetInt32("quantity"),
                        reader.GetDateTime("expirationDate"),
                        reader.GetDouble("price"),
                        reader.GetString("image_path")
                        );
                        return product;
                    }
                    return null;
                }
                catch (MySqlException ex)
                {
                    throw new Exception("We could load your data. Please try again!");
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }
        }
        public bool UserAddsProductToFridge(int userId, int productId, DateTime dateOfAdding)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    Conn.Open();
                    string sql = "INSERT INTO user_products_storage (user_id, product_id, dateOfAdding) VALUES (@userId, @productId, @dateOfAdding)";
                    var cmd = new MySqlCommand(sql, Conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Parameters.AddWithValue("@dateOfAdding", dateOfAdding);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Failed to add product to fridge. Please try again!", ex);
                }
            }
        }
        public List<Product> GetProductsByUserId(int userId, int page, int pageSize)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                    Conn.Open();

                    string sql = "select * FROM product JOIN user_products_storage ON product.product_id = user_products_storage.product_id WHERE user_products_storage.user_id = @userId ORDER BY product.product_id LIMIT @PageSize OFFSET @Offset";
                    var cmd = new MySqlCommand(sql, Conn);
                    var offset = (page - 1) * pageSize;
                    cmd.Parameters.AddWithValue("@Offset", offset);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    List<Product> products = new List<Product>();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new Product(
                            reader.GetInt32("product_id"),
                            reader.GetInt32("type_id"),
                            reader.GetString("name"),
                            reader.GetString("nutrients"),
                            reader.GetInt32("quantity"),
                            reader.GetDateTime("expirationDate"),
                            reader.GetDouble("price"),
                            reader.GetString("image_path")
                            );
                        products.Add(product);
                    }
                    return products;
                    
                try
                {
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Sorry! We could load your products.");
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
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
        public bool DeleteProduct(int id)
        {
            bool success = false;
            try
            {
                using (MySqlConnection con = ConnectionString.Connection())
                {
                    string sqlQuery = "DELETE FROM product WHERE product_id = @Id";
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
        public bool RemoveProductFromUserFridge(int id) {
            bool success = false;
            try
            {
                using (MySqlConnection con = ConnectionString.Connection())
                {
                    string sqlQuery = "DELETE FROM user_products_storage WHERE product_id = @Id";
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
                    string sql = "select image_path FROM product WHERE product_id = @productId";
                    var cmd = new MySqlCommand(sql, Conn);

                    cmd.Parameters.AddWithValue("@productId", id);

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

    }
}
