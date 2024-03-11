using BLL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class ImageDataAccess
    {
        public bool CreateImageUser(byte[] image, out long id)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    Conn.Open();
                    string sql = "INSERT INTO userimage (image_value) " +
                    "values ( @imageValue)";

                    var cmd = new MySqlCommand(sql, Conn);
                    cmd.Parameters.AddWithValue("@imageValue", image);

                    bool isSuccessful = cmd.ExecuteNonQuery() > 0;
                    id = cmd.LastInsertedId;
                    return isSuccessful;
                }
                catch (Exception ex)
                {
                    id = 0;
                    return false;
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }
        }
        public bool CreateImageProduct(byte[] image, out long id)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    Conn.Open();
                    string sql = "insert into productimage (image_value) " +
                    "values ( @imageValue)";

                    var cmd = new MySqlCommand(sql, Conn);
                    cmd.Parameters.AddWithValue("@imageValue", image);

                    bool isSuccessful = cmd.ExecuteNonQuery() > 0;
                    id = cmd.LastInsertedId;
                    return isSuccessful;
                }
                catch (Exception ex)
                {
                    id = 0;
                    return false;
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }

        }
        public bool UpdateImageUser(byte[] image, out long id)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                    Conn.Open();
                    string sql = "UPDATE userimage SET image_value = @imageValue WHERE image_id = image_Id";

                    var cmd = new MySqlCommand(sql, Conn);
                    cmd.Parameters.AddWithValue("@imageValue", image);

                    bool isSuccessful = cmd.ExecuteNonQuery() > 0;
                    id = cmd.LastInsertedId;
                    return isSuccessful;
                try
                {
                }
                catch (Exception ex)
                {
                    id = 0;
                    return false;
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
