using BLL.Managers;
using BLL.Models;
using BLL.Models.Recipe_Classes;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UseYourFridge.Forms
{
    public partial class AddRecipe : Form
    {
        private string? FileName;
        private string? ImagePath;

        RecipeManager recipeManager;
        ProductManager productManager;
        private List<RecipeType> recipeTypes = new List<RecipeType>();
        public AddRecipe()
        {
            InitializeComponent();

            recipeManager = new RecipeManager(new RecipeDataAccess());
            productManager = new ProductManager(new ProductDataAccess());

            foreach (RecipeType recipeType in Enum.GetValues(typeof(RecipeType)))
            {
                recipeTypes.Add(recipeType);
                cbType.Items.Add(recipeType);
            }
            cbType.DataSource = recipeTypes;

            List<Product> products = new List<Product>();
            products = productManager.GetAllProducts();
            foreach (var item in products)
            {
                cbProducts.Items.Add(item.GetName());
            }
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                RecipeType recipeType = (RecipeType)cbType.SelectedItem;
                if (string.IsNullOrWhiteSpace(tbName.Text))
                {
                    MessageBox.Show("Please enter a valid product name.");
                    return;
                }

                List<string> ingredients = lbIngredients.Items.Cast<string>().ToList();

                bool isValid = ingredients.All(item => !string.IsNullOrWhiteSpace(item));

                if (!isValid)
                {
                    MessageBox.Show("Please enter valid nutrient information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string description = rtbDescription.Text.Trim();
                if (string.IsNullOrWhiteSpace(description))
                {
                    MessageBox.Show("Please enter valid description.");
                    return;
                }


                if (ImagePath == null)
                {
                    MessageBox.Show("Invalid Image. Pease input an image.");
                    return;
                }

                if (cbType.SelectedIndex == 0)
                {
                    lbProtein.Hide();
                    tbSweets.Show();
                    tbSideDish.Hide();
                    string sweets = tbSweets.Text.Trim();
                    if (string.IsNullOrWhiteSpace(sweets))
                    {
                        MessageBox.Show("Please enter valid nutrient information.");
                        return;
                    }
                    

                    BreakfastRecipe createBreakFastRecipe = new BreakfastRecipe(0, tbName.Text, recipeType, ingredients, description, ImagePath, sweets);
                    bool isAdded = recipeManager.CreateBreakfast(createBreakFastRecipe);

                    if (isAdded)
                    {

                        tbName.Clear();
                        rtbDescription.Clear();
                        tbSweets.Clear();
                        lbIngredients.Items.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error occurred while adding the product.");
                    }
                }
                else if (cbType.SelectedIndex == 1)
                {
                    lbProtein.Hide();
                    tbSweets.Hide();
                    string sideDish = tbSideDish.Text.Trim();
                    if (string.IsNullOrWhiteSpace(sideDish))
                    {
                        MessageBox.Show("Please enter valid nutrient information.");
                        return;
                    }

                    LunchRecipe createLunchFastRecipe = new LunchRecipe(0, tbName.Text, recipeType, ingredients, description, sideDish, ImagePath);
                    bool isAdded = recipeManager.CreateLunch(createLunchFastRecipe);

                    if (isAdded)
                    {

                        tbName.Clear();
                        rtbDescription.Clear();
                        tbSideDish.Clear();
                        lbIngredients.Items.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error occurred while adding the product.");
                    }
                }
                else
                {
                    int protein = Convert.ToInt32(nudProtein.Value);
                    if (protein <= 0)
                    {
                        MessageBox.Show("Please enter a valid quantity greater than zero.");
                        return;
                    }
                    string vegetable = tbVegetable.Text.Trim();
                    if (string.IsNullOrWhiteSpace(vegetable))
                    {
                        MessageBox.Show("Please enter valid nutrient information.");
                        return;
                    }

                    DinnerRecipe createDinnerFastRecipe = new DinnerRecipe(0, tbName.Text, recipeType, ingredients, description, ImagePath, protein.ToString(), vegetable);
                    bool isAdded = recipeManager.CreateDinner(createDinnerFastRecipe);

                    if (isAdded)
                    {

                        tbName.Clear();
                        rtbDescription.Clear();
                        nudProtein.Value = 1;
                        tbVegetable.Clear();
                        lbIngredients.Items.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error occurred while adding the product.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private async void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "C://Desktop";
            ofd.Title = "Select image to be upload.";
            ofd.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            ofd.FilterIndex = 1;
            try
            {

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
            catch
            {
                MessageBox.Show("Please Choose another image to upload");
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbType.SelectedItem.ToString();

            if (selectedValue == "BREAKFAST")
            {
                tbSweets.Show();
                lbProtein.Hide();
                tbSideDish.Hide();
                nudProtein.Hide();
                tbVegetable.Hide();
            }
            else if (selectedValue == "LUNCH")
            {
                tbSideDish.Show();
                lbProtein.Hide();
                tbSweets.Hide();
                nudProtein.Hide();
                tbVegetable.Hide();
            }
            else
            {
                lbProtein.Show();
                nudProtein.Show();
                tbVegetable.Show();
                tbSweets.Hide();
                tbSideDish.Hide();
            }
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void tbIngredients_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void tbVegetable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            if (cbProducts.SelectedItem == null)
            {
                MessageBox.Show("Please select a product to add.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedProduct = cbProducts.SelectedItem.ToString();

            if (lbIngredients.Items.Contains(selectedProduct))
            {
                MessageBox.Show("This product is already in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                lbIngredients.Items.Add(selectedProduct);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDeleteIngredient_Click(object sender, EventArgs e)
        {
            if (lbIngredients.Items.Count == 0)
            {
                MessageBox.Show("There are no items to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lbIngredients.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    lbIngredients.Items.Remove(lbIngredients.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Deletion canceled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddRecipe_Load(object sender, EventArgs e)
        {

        }

        private void nudProtein_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
