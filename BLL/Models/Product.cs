using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Product
    {
        public int Id { get; private set; }
        public int TypeId { get; private set; }
        public string Name { get; private set; }
        public string Nutrients { get; private set; }
        public int Quantity { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public double Price { get; private set; }
        public string ImagePath { get; private set; }
        public Product(int id, int typeId, string name, string nutrients, int quantity, DateTime expirationDate, double price,string imagePath)
        {
            Id = id;
            TypeId = typeId;
            Name = name;
            Nutrients = nutrients;
            Quantity = quantity;
            ExpirationDate = expirationDate;
            Price = price;
            ImagePath = imagePath;
        }
        public Product(int id)
        {
            Id = id;
        }
        public string GetName() {
            return Name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
