using BLL.Managers;
using BLL.Models;
using DAL;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UseYourFridge.Forms
{
    public partial class AddProduct : Form
    {
        ProductManager productManager;
        private string? FileName;
        private string? ImagePath;
        public FoodTypeManager foodTypeManager;
        public AddProduct()
        {
            productManager = new ProductManager(new ProductDataAccess());
            foodTypeManager = new FoodTypeManager(new FoodTypeDataAccess());
            InitializeComponent();

            List<string> foodTypeOptions = foodTypeManager.GetFoodTypes();
            cbType.DataSource = foodTypeOptions;
        }
        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            string input = tbPrice.Text;

            string pattern = "^[0-9]+$";

            Regex regex = new Regex(pattern);

            if (regex.IsMatch(input))
            {
                label3.Text = "Valid input";
            }
            else
            {
                label3.Text = "Invalid input. Please enter only numbers.";
            }
        }


        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void tbNutrients_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void btnAddProduct_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbName.Text))
                {
                    MessageBox.Show("Please enter a valid product name.");
                    return;
                }
                string selectedType = cbType.SelectedItem?.ToString();
                if (string.IsNullOrWhiteSpace(selectedType))
                {
                    MessageBox.Show("Please select a valid product type.");
                    return;
                }
                string nutrients = tbNutrients.Text.Trim();
                if (string.IsNullOrWhiteSpace(nutrients))
                {
                    MessageBox.Show("Please enter valid nutrient information.");
                    return;
                }

                int quantity = Convert.ToInt32(nudQuantity.Value);
                if (quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity greater than zero.");
                    return;
                }
                double price = Convert.ToDouble(tbPrice.Text.Trim());
                if (string.IsNullOrWhiteSpace(nutrients))
                {
                    MessageBox.Show("Please enter valid nutrient information.");
                    return;
                }
                DateTime selectedDateTime = dtExpirationDate.Value;
                if (selectedDateTime < DateTime.Now)
                {
                    MessageBox.Show("Please select a future expiration date.");
                    return;
                }
                if (ImagePath == null)
                {
                    MessageBox.Show("Invalid Image. Pease input an image.");
                    return;
                }
                int typeId = foodTypeManager.GetFoodTypeId(selectedType);

                Product createProduct = new Product(0, typeId, tbName.Text, nutrients, quantity, selectedDateTime, price, ImagePath);

                bool isAdded = productManager.CreateProduct(createProduct);

                if (isAdded)
                {
                    MessageBox.Show($"The Products: {tbName.Text} has been added successfully!");
                    tbName.Clear();
                    tbNutrients.Clear();
                    nudQuantity.Value = 1;
                    dtExpirationDate.Value = DateTime.Now;
                }
                else
                {
                    MessageBox.Show("Error occurred while adding the product.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private async void btnAddImage_Click_1(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "C://Desktop";
            ofd.Title = "Select image to be uploaded.";
            ofd.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using var content = new MultipartFormDataContent();
                using var fileStream = File.OpenRead(ofd.FileName);
                content.Add(new StreamContent(fileStream), "file", Path.GetFileName(ofd.FileName));

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync("http://localhost:5287/images", content);


                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Failed to upload image. Please try again later.");
                }
                else
                {
                    ImagePath = await response.Content.ReadAsStringAsync();
                }
            }
            else
            {
                MessageBox.Show("Please upload an image.");
            }
        }
    }
}
