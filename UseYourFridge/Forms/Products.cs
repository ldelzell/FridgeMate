using BLL.Managers;
using BLL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UseYourFridge.Forms
{
    public partial class Products : Form
    {
        public ProductManager productManager;
        public FoodTypeManager foodTypeManager;
        public Products()
        {
            productManager = new ProductManager(new ProductDataAccess());
            foodTypeManager = new FoodTypeManager(new FoodTypeDataAccess());
            InitializeComponent();
            DisplayProducts();
        }
        private async void DisplayProducts()
        {
            dgvProducts.Rows.Clear();
            dgvProducts.Columns.Clear();
            List<Product> products = productManager.GetAllProducts();

            dgvProducts.Columns.Add("product_id", "id");
            dgvProducts.Columns.Add("name", "Product Name");
            dgvProducts.Columns.Add("type", "Type Name");
            dgvProducts.Columns.Add("nutrients", "Nutrients");
            dgvProducts.Columns.Add("quantity", "Quantity");
            dgvProducts.Columns.Add("expirationDate", "Expiration Date");
            dgvProducts.Columns.Add("price", "Price");

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "Image";
            imageColumn.Name = "image_path";
            imageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvProducts.Columns.Add(imageColumn);

            foreach (Product prod in products)
            {
                int rowIndex = dgvProducts.Rows.Add();
                dgvProducts.Rows[rowIndex].Cells["product_id"].Value = prod.Id;
                dgvProducts.Rows[rowIndex].Cells["name"].Value = prod.Name;
                dgvProducts.Rows[rowIndex].Cells["type"].Value = prod.TypeId;
                dgvProducts.Rows[rowIndex].Cells["nutrients"].Value = prod.Nutrients;
                dgvProducts.Rows[rowIndex].Cells["quantity"].Value = prod.Quantity + "grams";
                dgvProducts.Rows[rowIndex].Cells["expirationDate"].Value = prod.ExpirationDate;
                dgvProducts.Rows[rowIndex].Cells["price"].Value = prod.Price;

                // Load image from file path and resize it
                string imagePath = prod.ImagePath;

                MemoryStream mStream = new MemoryStream();
                HttpClient httpClient = new HttpClient();
                Bitmap image = new Bitmap(await httpClient.GetStreamAsync("http://localhost:5287/" + prod.ImagePath), false);
                mStream.Dispose();

                if (this.IsDisposed) return;

                if (!string.IsNullOrEmpty(imagePath))
                {
                    // Resize the image
                    int newWidth = 100;
                    int newHeight = 100;
                    System.Drawing.Image resizedImg = new Bitmap(image, new Size(newWidth, newHeight));

                    dgvProducts.Rows[rowIndex].Cells["image_path"].Value = resizedImg;
                }
                else
                {
                    dgvProducts.Rows[rowIndex].Cells["image_path"].Value = null;
                }

                dgvProducts.Rows[rowIndex].Height = 65;
            }
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var addProductForm = new AddProduct();
            addProductForm.ShowDialog(this);
        }
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducts.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvProducts.SelectedRows[0];
                    int productId = Convert.ToInt32(selectedRow.Cells["product_id"].Value);
                    string productName = Convert.ToString(selectedRow.Cells["name"].Value);
                    ProductManager productManager = new ProductManager(new ProductDataAccess());
                    string imageName = productManager.GetImagePathById(productId); // Assuming the image name is stored in a cell named "image_name"

                    DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove the product with Name: {productName}?", "Confirm Deletion",
                        MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Delete the image first
                        bool imageDeleted = DeleteImage(imageName);

                        if (imageDeleted)
                        {
                            bool result = productManager.DeleteProduct(new Product(productId));

                            if (result)
                            {
                                MessageBox.Show("Product removed successfully.");
                                DisplayProducts();
                            }
                            else
                            {
                                MessageBox.Show("Failed to remove product.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to remove product image.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private bool DeleteImage(string imageName)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync("http://localhost:5287/" + imageName).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                // Handle error here, you might want to log the error or handle it in some way
                return false;
            }
        }





    }
}
