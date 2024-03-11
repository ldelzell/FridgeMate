using BLL.Managers;
using BLL.Models;
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

namespace UseYourFridge.Forms
{
    public partial class CreateAccount : Form
    {
        public UserManager userManager;
        private string? FileName;
        private string? ImagePath;
        public RecipeManager recipeManager;
        public ProductManager productManager;
        public CreateAccount()
        {
            InitializeComponent();
            userManager = new UserManager(new UserDataAccess());
            productManager = new ProductManager(new ProductDataAccess());
            recipeManager = new RecipeManager(new RecipeDataAccess());
        }
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbFirstName.Text) || string.IsNullOrEmpty(tbLastName.Text) ||
                    string.IsNullOrEmpty(tbEmail.Text) || string.IsNullOrEmpty(tbUserName.Text) ||
                    string.IsNullOrEmpty(tbPasswordd.Text))
                {
                    MessageBox.Show("All fields are required. Please fill out all the fields.");
                    return;
                }
                if (!IsValidEmail(tbEmail.Text))
                {
                    MessageBox.Show("Invalid email address. Please enter a valid email.");
                    return;
                }
                if (ImagePath == null)
                {
                    MessageBox.Show("Invalid Image. Pease input an image.");
                    return;
                }
                bool usernameExicts = userManager.UsernameInExistance(tbUserName.Text);
                if (usernameExicts)
                {
                    MessageBox.Show("Username is in use. Please try something else");

                    string currentUsername = tbUserName.Text;

                    Algorithm usernameGenerator = new Algorithm(productManager,recipeManager);

                    string suggestedUsername = usernameGenerator.GenerateRandomUsername(currentUsername);

                    bool suggestedUsernameAlreadyExists = userManager.UsernameInExistance(suggestedUsername);

                    while (suggestedUsernameAlreadyExists)
                    {
                        suggestedUsername = usernameGenerator.GenerateRandomUsername(currentUsername);
                        suggestedUsernameAlreadyExists = userManager.UsernameInExistance(suggestedUsername);
                    }
                    label3.BackColor = Color.White;
                    label3.Text = "Suggested Username:   " + suggestedUsername;

                    this.Show();
                }
                else
                {
                    User createUser = new User(0, tbFirstName.Text, tbLastName.Text, Convert.ToInt32(nudPhoneNumber.Value),
                            tbEmail.Text, tbUserName.Text, tbPasswordd.Text, ImagePath);
                    userManager.Create(createUser);

                    tbFirstName.Clear();
                    tbLastName.Clear();
                    tbEmail.Clear();
                    tbPasswordd.Clear();
                    tbUserName.Clear();

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
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
    }
}
