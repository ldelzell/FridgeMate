using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductDataAccess
    {
        bool CreateProduct(Product product);
        List<Product> GetAllProducts();
        List<Product> GetProductsPanagination(int page, int pageSize);
        int GetAllProductCount();
        Product GetProductById(int id);
        bool UserAddsProductToFridge(int userId, int productId, DateTime dateOfAdding);
        List<Product> GetProductsByUserId(int userId, int page, int pageSize);
        bool AddImage(Image image);
        bool DeleteProduct(int id);
        bool RemoveProductFromUserFridge(int id);
        string GetImagePathById(int id);
    }
}
