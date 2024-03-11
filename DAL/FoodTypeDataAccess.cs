using BLL.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.FoodTypeDataAccess;

namespace DAL
{
   
        public class FoodTypeDataAccess : IFoodTypeDataAccess
        {
            public List<string> GetFoodTypes()
            {
                List<string> foodTypeOptions = new List<string>();
                using (MySqlConnection Conn = ConnectionString.Connection())
                {
                    try
                    {
                        Conn.Open();
                        string sql = "SELECT type_name FROM food_type";
                        var cmd = new MySqlCommand(sql, Conn);
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string typeName = reader.GetString("type_name");
                            foodTypeOptions.Add(typeName);
                        }
                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
                return foodTypeOptions;
            }
            public int GetFoodTypeId(string foodName)
            {
                int foodId = 0;

                using (MySqlConnection Conn = ConnectionString.Connection())
                {
                    try
                    {
                        Conn.Open();
                        string sql = "SELECT type_id FROM food_type WHERE type_name = @type_name";
                        var cmd = new MySqlCommand(sql, Conn);
                        cmd.Parameters.AddWithValue("@type_name", foodName);

                        var reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            foodId = reader.GetInt32(0);
                        }

                        reader.Close();
                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }

                return foodId;
            }
            public string GetFoodTypeById(int food_Id)
            {
                string FoodName = null;

                using (MySqlConnection Conn = ConnectionString.Connection())
                {
                    string sql = "SELECT food_name FROM food_type WHERE food_id = @FoodId";

                    using (MySqlCommand command = new MySqlCommand(sql, Conn))
                    {
                        command.Parameters.AddWithValue("@FoodId", food_Id);

                        Conn.Open();

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            FoodName = result.ToString();
                        }
                    }
                }

                return FoodName;
            }
        }
    }

