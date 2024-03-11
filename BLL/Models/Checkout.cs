using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Checkout
    {
        public int CheckoutId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public string PaymentMethod { get; private set; }
        public string CardHolderName { get; private set; }
        public int CardNumber { get; private set; }
        public string CardExpiryDate { get; private set; }
        public string CVV { get; private set; }
        public int UserId { get; private set; }
        public string ProductsInBasket { get; private set; }
        public string OrderNumber { get; private set; }
        public Checkout(int checkoutId, string firstName, string lastName, string username, string email, string address, string country, string zipCode, 
            string paymentMethod, string cardHolderName, int cardNumber, string cardExpiryDate, string cVV, int userId, string productsInBasket, string orderNumber)
        {
            CheckoutId = checkoutId;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Address = address;
            Country = country;
            ZipCode = zipCode;
            PaymentMethod = paymentMethod;
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            CardExpiryDate = cardExpiryDate;
            CVV = cVV;
            UserId = userId;
            ProductsInBasket = productsInBasket;
            OrderNumber = orderNumber;
        }
        public Checkout(int checkoutId, string firstName, string lastName, string username, string email, string address, string country, string zipCode,
           string cardHolderName, int cardNumber, string cardExpiryDate, string cVV, int userId, string productsInBasket, string orderNumber)
        {
            CheckoutId = checkoutId;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Address = address;
            Country = country;
            ZipCode = zipCode;
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            CardExpiryDate = cardExpiryDate;
            CVV = cVV;
            UserId = userId;
            ProductsInBasket = productsInBasket;
            OrderNumber = orderNumber;
        }
    }
}
