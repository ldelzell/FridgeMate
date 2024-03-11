using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class ProductManager
    {
        public IProductDataAccess data;

        public ProductManager(IProductDataAccess data) {
            this.data = data;
        }
        public bool CreateProduct(Product product)
        {
            return data.CreateProduct(product);
        }
        public List<Product> GetAllProducts()
        {
            return data.GetAllProducts();
        }
        public List<Product> GetProductsPanagination(int page, int pageSize)
        {
            return data.GetProductsPanagination(page, pageSize);
        }
        public int GetAllProductCount() {
            return data.GetAllProductCount();
        }
        public Product? GetProductById(int id)
        {
            return data.GetProductById(id);
        }
        public bool UserAddsProductToFridge(int userId, int productId, DateTime dateOfAdding) {
            return data.UserAddsProductToFridge(userId, productId, dateOfAdding);
        }
        public List<Product> GetProductsByUserId(int userId, int page, int pageSize) {
            return data.GetProductsByUserId(userId, page, pageSize);
        }
        public bool AddImage(Image image)
        {
            return data.AddImage(image);
        }
        public bool DeleteProduct(Product product) {
            return data.DeleteProduct(product.Id);
        }
        public bool RemoveProductFromUserFridge(int id) {
            return data.RemoveProductFromUserFridge(id);
        }
        public string GetImagePathById(int id) { 
            return data.GetImagePathById(id);
        }
    }
}
