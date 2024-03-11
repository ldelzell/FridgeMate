using BLL.Interfaces;
using BLL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CheckoutDataAccess : ICheckoutDataAccess
    {
        public bool CreateCheckout(Checkout checkout)
        {
            using (MySqlConnection Conn = ConnectionString.Connection())
            {
                try
                {
                    Conn.Open();
                    string sql = @"INSERT INTO Checkout (FirstName, LastName, Username, Email, Address, Country, ZipCode, PaymentMethod, CardHolderName, CardNumber, CardExpiryDate, CVV, UserId, Products, OrderNumber)
                                       VALUES (@FirstName, @LastName, @Username, @Email, @Address, @Country, @ZipCode, @PaymentMethod, @CardHolderName, @CardNumber, @CardExpiryDate, @CVV, @UserId, @Products, @OrderNumber);";

                    var cmd = new MySqlCommand(sql, Conn);

                    cmd.Parameters.AddWithValue("@FirstName", checkout.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", checkout.LastName);
                    cmd.Parameters.AddWithValue("@Username", checkout.Username);
                    cmd.Parameters.AddWithValue("@Email", checkout.Email);
                    cmd.Parameters.AddWithValue("@Address", checkout.Address);
                    cmd.Parameters.AddWithValue("@Country", checkout.Country);
                    cmd.Parameters.AddWithValue("@ZipCode", checkout.ZipCode);
                    cmd.Parameters.AddWithValue("@PaymentMethod", checkout.PaymentMethod);
                    cmd.Parameters.AddWithValue("@CardHolderName", checkout.CardHolderName);
                    cmd.Parameters.AddWithValue("@CardNumber", checkout.CardNumber);
                    cmd.Parameters.AddWithValue("@CardExpiryDate", checkout.CardExpiryDate);
                    cmd.Parameters.AddWithValue("@CVV", checkout.CVV);
                    cmd.Parameters.AddWithValue("@UserId", checkout.UserId);
                    cmd.Parameters.AddWithValue("@Products", checkout.ProductsInBasket);
                    cmd.Parameters.AddWithValue("@OrderNumber", checkout.OrderNumber);


                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Sorry, the checkout COULD NOT be created currently. Please try again later!");
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
