using BLL.Managers;
using BLL.Models;
using DAL;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UseYourFridge.Forms
{
    public partial class Profile : Form
    {
        public UserManager userManager;
        private BLL.Models.User user;
        private string? ImagePath;

        public Profile(BLL.Models.User user)
        {
            UserDataAccess userDataAccess = new UserDataAccess();
            userManager = new UserManager(userDataAccess);
            InitializeComponent();
            tbFirstName.ReadOnly = true;
            tbLastName.ReadOnly = true;
            tbUserName.ReadOnly = true;
            tbPhoneNumber.ReadOnly = true;

            this.user = user;

            pbProfilePicture.SizeMode = PictureBoxSizeMode.Zoom;

            lbFirstName.Text = user.FirstName;
            lbLastName.Text = user.LastName;

            tbFirstName.Text = user.FirstName;
            tbLastName.Text = user.LastName;
            tbPhoneNumber.Text = (user.PhoneNumber).ToString();
            tbUserName.Text = user.Username;
            //this.user = user;

            try
            {
                DiplayImage();
            }
            catch
            {
                MessageBox.Show("Something is wrong");
            }
            RefreshInfo();
        }
        public async void DiplayImage()
        {
            try
            {
                MemoryStream mStream = new MemoryStream();
                HttpClient httpClient = new HttpClient();

                Bitmap image = new Bitmap(await httpClient.GetStreamAsync("http://localhost:5287/" + user.ImagePath), false);
                mStream.Dispose();
                System.Drawing.Image img = null;
                pbProfilePicture.Image = image;
                pbProfilePicture.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
        public void RefreshInfo()
        {
            lbFirstName.Text = user.FirstName;
            lbLastName.Text = user.LastName;
            lbFirstName.Update();
            lbLastName.Update();

            tbFirstName.Refresh();
            tbLastName.Refresh();
            tbPhoneNumber.Refresh();
            tbUserName.Refresh();
            pbProfilePicture.Refresh();
        }

        private async void btnChangeProfilePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "C://Desktop";
            ofd.Title = "Select image to be uploaded.";
            ofd.Filter = "Image Files|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
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

                    string imageName = userManager.GetUserImageByUserId(user.Id);

                    bool imageDeleted = DeleteImage(imageName);

                    if (imageDeleted)
                    {
                        string currentPath = ImagePath;

                        user.UpdateImage(currentPath);

                        userManager.UpdateUserInfo(user);

                        MemoryStream mStream = new MemoryStream();
                        HttpClient httpClient = new HttpClient();

                        Bitmap image = new Bitmap(await httpClient.GetStreamAsync("http://localhost:5287/" + user.ImagePath), false);
                        mStream.Dispose();
                        System.Drawing.Image img = null;

                        pbProfilePicture.Image = image;
                        pbProfilePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        MessageBox.Show("Failed to remove product image.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please upload an image.");
            }
        }
        private void btnChangeCredentials_Click(object sender, EventArgs e)
        {
            if (!tbFirstName.ReadOnly)
            {
                btnChangeCredentials.Text = "Edit Information";
                tbFirstName.ReadOnly = true;
                tbLastName.ReadOnly = true;
                tbPhoneNumber.ReadOnly = true;
                tbUserName.ReadOnly = true;
                if (tbPhoneNumber.TextLength > tbPhoneNumber.MaxLength)
                {
                    MessageBox.Show("The Phone Number lenght is exceeding the limit. Please enter valid phone number!");
                }
                else { 
                    user.Update(tbFirstName.Text, tbLastName.Text, tbUserName.Text, Convert.ToInt32(tbPhoneNumber.Text));
                }

                if (!userManager.UpdateUserInfo(user))
                {
                    MessageBox.Show("Uppps!");
                }
                else
                {
                    RefreshInfo();
                }
            }
            else
            {
                btnChangeCredentials.Text = "Save Information";
                tbFirstName.ReadOnly = false;
                tbLastName.ReadOnly = false;
                tbPhoneNumber.ReadOnly = false;
                tbUserName.ReadOnly = false;

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
