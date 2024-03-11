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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UseYourFridge.Forms
{
    public partial class Recipes : Form
    {
        RecipeManager recipeManager;
        public Recipes()
        {
            recipeManager = new RecipeManager(new RecipeDataAccess());
            InitializeComponent();
            DisplayRecipes();
        }
        private async void DisplayRecipes()
        {
            dgvRecipes.Rows.Clear();
            dgvRecipes.Columns.Clear();
            List<Recipe> recipes = recipeManager.GetAllRecipes();

            dgvRecipes.Columns.Add("recipe_id", "id");
            dgvRecipes.Columns.Add("name", "Product Name");
            dgvRecipes.Columns.Add("type", "Type Name");
            dgvRecipes.Columns.Add("mainIngredient", "Ingredients");
            dgvRecipes.Columns.Add("description", "Description");
            dgvRecipes.Columns.Add("sweets", "Sweets");
            dgvRecipes.Columns.Add("sideDish", "Side Dish");
            dgvRecipes.Columns.Add("protein", "Protein");
            dgvRecipes.Columns.Add("vegetable", "Vegetable");


            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "Image";
            imageColumn.Name = "image_path";
            imageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRecipes.Columns.Add(imageColumn);

            foreach (Recipe recip in recipes)
            {
                int rowIndex = dgvRecipes.Rows.Add();
                dgvRecipes.Rows[rowIndex].Cells["recipe_id"].Value = recip.Id;
                dgvRecipes.Rows[rowIndex].Cells["name"].Value = recip.Name;
                dgvRecipes.Rows[rowIndex].Cells["type"].Value = recip.Type.ToString();
                dgvRecipes.Rows[rowIndex].Cells["mainIngredient"].Value = string.Join(", ", recip.Ingredients);
                dgvRecipes.Rows[rowIndex].Cells["description"].Value = recip.Description;
                if (recip is BreakfastRecipe)
                {
                    var breakfastRecipe = (BreakfastRecipe)recip;
                    // Access properties specific to BreakfastRecipe, e.g., breakfastRecipe.CookingTime
                    dgvRecipes.Rows[rowIndex].Cells["sweets"].Value = breakfastRecipe.Sweets;
                }
                else if (recip is LunchRecipe)
                {
                    var lunchRecipe = (LunchRecipe)recip;
                    // Access properties specific to LunchRecipe, e.g., lunchRecipe.Cuisine
                    dgvRecipes.Rows[rowIndex].Cells["sideDish"].Value = lunchRecipe.SideDish;
                }
                else if (recip is DinnerRecipe)
                {
                    var dinnerRecipe = (DinnerRecipe)recip;
                    // Access properties specific to DinnerRecipe, e.g., dinnerRecipe.IsFancy
                    dgvRecipes.Rows[rowIndex].Cells["protein"].Value = dinnerRecipe.Protein;
                    dgvRecipes.Rows[rowIndex].Cells["vegetable"].Value = dinnerRecipe.Vegetable;

                }

                string imagePath = recip.ImagePath;

                MemoryStream mStream = new MemoryStream();
                HttpClient httpClient = new HttpClient();
                Bitmap image = new Bitmap(await httpClient.GetStreamAsync("http://localhost:5287/" + recip.ImagePath), false);
                mStream.Dispose();
                if (this.IsDisposed) return;
                if (!string.IsNullOrEmpty(imagePath))
                {
                    // Resize the image
                    int newWidth = 100;
                    int newHeight = 100;
                    System.Drawing.Image resizedImg = new Bitmap(image, new Size(newWidth, newHeight));

                    dgvRecipes.Rows[rowIndex].Cells["image_path"].Value = resizedImg;
                }
                else
                {
                    dgvRecipes.Rows[rowIndex].Cells["image_path"].Value = null;
                }

                dgvRecipes.Rows[rowIndex].Height = 65;
            }
        }
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            var addRecipe = new AddRecipe();
            addRecipe.ShowDialog(this);
        }

        private void Recipes_Load(object sender, EventArgs e)
        {

        }

        private void btnDeleteRecipe_Click(object sender, EventArgs e)
        {
            if (dgvRecipes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvRecipes.SelectedRows[0];
                int recipeId = Convert.ToInt32(selectedRow.Cells["recipe_id"].Value);
                string recipeName = Convert.ToString(selectedRow.Cells["name"].Value);
                RecipeManager recipeManager = new RecipeManager(new RecipeDataAccess());

                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove the recipe with Name: {recipeName}?", "Confirm Deletion",
                    MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    string recipeType = Convert.ToString(selectedRow.Cells["type"].Value);

                    Recipe recipeToDelete;
                    if (recipeType == "BREAKFAST")
                    {
                        recipeToDelete = new BreakfastRecipe(recipeId);
                    }
                    else if (recipeType == "LUNCH")
                    {
                        recipeToDelete = new LunchRecipe(recipeId);
                    }
                    else if (recipeType == "DINNER")
                    {
                        recipeToDelete = new DinnerRecipe(recipeId);
                    }
                    else
                    {
                        // Handle unsupported recipe types if necessary
                        MessageBox.Show("Unsupported recipe type.");
                        return; // Exit the method if the recipe type is unsupported
                    }
                    string imageName = recipeManager.GetImagePathById(recipeId);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Delete the image first
                        bool imageDeleted = DeleteImage(imageName);

                        if (imageDeleted)
                        {
                            bool result = recipeManager.DeleteRecipe(recipeToDelete);

                            if (result)
                            {
                                DisplayRecipes();
                                MessageBox.Show("Recipe removed successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Failed to remove recipe.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to remove recipes image.");
                        }
                    }
                }
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

        private void btnPreviewRecipe_Click(object sender, EventArgs e)
        {
            if (dgvRecipes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a car from the list.");
            }
            else
            {
                DataGridViewRow selectedRow = dgvRecipes.SelectedRows[0];
                Recipe selectedRecipe = (Recipe)selectedRow.DataBoundItem;

                var recipeView = new RecipeView(selectedRecipe);
                recipeView.ShowDialog(this);


            }
        }
    }
}
