using BLL.Interfaces;
using BLL.Models;
using DAL.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDataAccess : IUserDataAccess
    {
        private static readonly string rootDirectory = Directory.GetParent(path: Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;
        public static readonly string settingsFile = Path.Combine(rootDirectory, "Databases", "settings.json");

        public bool Create(User user)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    byte[] salt;
                    long id;
                   // ImageDataAccess imageData = new ImageDataAccess();
                    Security security = new Security();
                   // imageData.CreateImageUser(user.Image, out id);
                    Conn.Open();
                    string sql = "insert into user (firstName, lastName, phoneNumber, email, username, password, hashed_password, salt,image_path) " +
                        "values (@firstName, @lastName, @phoneNumber, @email, @username, @password, @hashedPassword, @salt, @image_path)";

                    var cmd = new MySqlCommand(sql, Conn);

                    cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", user.LastName);
                    cmd.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@hashedPassword", security.HashPassword(user.Password, out salt));
                    cmd.Parameters.AddWithValue("@salt", Convert.ToBase64String(salt));
                    cmd.Parameters.AddWithValue("@image_path", user.ImagePath);
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
        public bool CheckLogIn(string username, string password, out int id)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                    byte[] salt;
                    Security security = new Security();
                    Conn.Open();
                    string sql = "select * FROM user WHERE username = @username";
                    var cmd = new MySqlCommand(sql, Conn);

                    cmd.Parameters.AddWithValue("@username", username);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string storedHashedPassword = reader.GetString("hashed_password");
                        salt = Convert.FromBase64String(reader.GetString("salt"));
                        if (security.VerifyPassword(password, storedHashedPassword, salt))
                        {
                            id = reader.GetInt32(0);
                            reader.Close();
                            return true;
                        }
                        reader.Close();
                        id = 0;
                        return false;
                    }
                    else
                    {
                        id = 0;
                        return false;
                    }
                try
                {
                }
                catch (MySqlException ex)
                {
                    id = 0;
                    throw new Exception("Loging in currently is UNavaliable! Please try again later.");
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }
        }
        public bool CheckLogInWithPhoneNumber(string phoneNumber, string password, out int id)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                byte[] salt;
                Security security = new Security();
                Conn.Open();
                string sql = "select * FROM user WHERE phoneNumber = @phoneNumber";
                var cmd = new MySqlCommand(sql, Conn);

                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedHashedPassword = reader.GetString("hashed_password");
                    salt = Convert.FromBase64String(reader.GetString("salt"));
                    if (security.VerifyPassword(password, storedHashedPassword, salt))
                    {
                        id = reader.GetInt32(0);
                        reader.Close();
                        return true;
                    }
                    reader.Close();
                    id = 0;
                    return false;
                }
                else
                {
                    id = 0;
                    return false;
                }
                try
                {
                }
                catch (MySqlException ex)
                {
                    id = 0;
                    throw new Exception("Loging in currently is UNavaliable! Please try again later.");
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }
        }
        public List<User> GetAllUsers()
        {
            byte[] data = null;
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                    Conn.Open();
                    string sql = "select * from user";
                    var cmd = new MySqlCommand(sql, Conn);
                    var reader = cmd.ExecuteReader();
                    List<User> users = new List<User>();
                    while (reader.Read())
                    {
                        User user = new User(
                        reader.GetInt32("user_id"),
                        reader.GetString("firstName"),
                        reader.GetString("lastName"),
                        reader.GetInt32("phoneNumber"),
                        reader.GetString("email"),
                        reader.GetString("username"),
                        reader.GetString("password"),
                        reader.GetString("image_path")
                        );
                        users.Add(user);
                    }
                    return users;
                try
                {
                }
                catch (MySqlException ex)
                {
                    throw new Exception("We could load users");
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }
        }
        public User GetUserById(int id)
        {
            byte[] data = null;
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                    Conn.Open();
                    string sql = "select * FROM user WHERE user_id = @userId";
                    var cmd = new MySqlCommand(sql, Conn);

                    cmd.Parameters.AddWithValue("@userId", id);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        User user = new User(
                        reader.GetInt32("user_id"),
                        reader.GetString("firstName"),
                        reader.GetString("lastName"),
                        reader.GetInt32("phoneNumber"),
                        reader.GetString("email"),
                        reader.GetString("username"),
                        reader.GetString("password"),
                        reader.GetString("image_path")
                        );
                        return user;
                    }
                    return null;
                try
                {
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
        public bool UpdateUserInfo(User user)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    string sql = "UPDATE user SET firstName = @firstName,  lastName = @lastName, phoneNumber = @phoneNumber, email = @email, username = @username, image_path = @image_path WHERE user_id = @userId";
                    var cmd = new MySqlCommand(sql, Conn);
                    Conn.Open();

                    cmd.Parameters.AddWithValue("@userId", user.Id);
                    cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", user.LastName);
                    cmd.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@image_path", user.ImagePath);

                    int result = cmd.ExecuteNonQuery();
                    return result == 1;
                }
                catch (Exception ex)
                {
                    throw new Exception("We could not update your information at the moment. Please try again!");
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }
        }
        //THIS METHOD WILL BE NEED JUST FOR THIS SUBMISSION - IT WILL BE REMOVED SOON
        public bool UpdateUserInfoWithoutImage(User user)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    string sql = "UPDATE user SET firstName = @firstName,  lastName = @lastName, phoneNumber = @phoneNumber, email = @email, username = @username WHERE user_id = @userId";
                    var cmd = new MySqlCommand(sql, Conn);
                    Conn.Open();

                    cmd.Parameters.AddWithValue("@userId", user.Id);
                    cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", user.LastName);
                    cmd.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@username", user.Username);

                    int result = cmd.ExecuteNonQuery();
                    return result == 1;
                }
                catch (Exception ex)
                {
                    throw new Exception("We could not update your information at the moment. Please try again!");
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }
        }
        public string GetUserImageByUserId(int id) {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                Conn.Open();
                string sql = "select * FROM user WHERE user_id = @userId";
                var cmd = new MySqlCommand(sql, Conn);

                cmd.Parameters.AddWithValue("@userId", id);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    User user = new User(
                    reader.GetInt32("user_id"),
                    reader.GetString("firstName"),
                    reader.GetString("lastName"),
                    reader.GetInt32("phoneNumber"),
                    reader.GetString("email"),
                    reader.GetString("username"),
                    reader.GetString("password"),
                    reader.GetString("image_path")
                    );
                    return user.ImagePath ;
                }
                return null;
                try
                {
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
        public bool UsernameInExistance(string username)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    string sql = "SELECT COUNT(*) FROM user WHERE username = @username";
                    var cmd = new MySqlCommand(sql, Conn);

                    Conn.Open();
                    cmd.Parameters.AddWithValue("username", username);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        return true;
                    }
                    return false;
                }
                catch (MySqlException ex)
                {
                    throw new Exception("There was a problem. Please try again");
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }
        }
        //public bool UpdateUserImage(User user)
        //{
        //    using (MySqlConnection Conn = ConnectionString.Connection())
        //    {
        //            long id;
        //            ImageDataAccess imageData = new ImageDataAccess();
        //            imageData.UpdateImageUser(user.Image, out id);
        //            string sql = "UPDATE userimage SET image_value = @imageValue";
        //            var cmd = new MySqlCommand(sql, Conn);
        //            Conn.Open();

        //            cmd.Parameters.AddWithValue("@imageValue", user.Image);

        //            int result = cmd.ExecuteNonQuery();
        //            return result == 1;
        //        try
        //        {
        //        }
        //        catch (MySqlException ex)
        //        {
        //            throw new Exception("We could not update your Image at the moment. Please try again!");
        //        }
        //        finally
        //        {
        //            Conn.Close();
        //            Conn.Dispose();
        //        }
        //    }
        //}
        public void SetSetting(string key, dynamic? value)
        {
            // read file as text
            using StreamReader reader = new StreamReader(settingsFile);
            string json = reader.ReadToEnd();
            reader.Close();

            // text -> object
            JsonNode? data = JsonNode.Parse(json);

            data![key] = value;

            // write the new value to the file
            using StreamWriter writer = new StreamWriter(settingsFile);
            writer.Write(JsonSerializer.Serialize(data));
            writer.Close();
        }
        public dynamic? GetSetting(string key)
        {
            // read the file as text
            using StreamReader reader = new StreamReader(settingsFile);
            string json = reader.ReadToEnd();
            reader.Close();

            // text -> object
            JsonNode? data = JsonNode.Parse(json);

            if (data!.AsObject().ContainsKey(key)) return data[key];

            return null;
        }
    }
}
