using BLL.Models;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class RecipeView : Form
    {
        public RecipeView(Recipe recipe)
        {
            InitializeComponent();

           
            try
            {
                async void DisplayImage()
                {
                    MemoryStream mStream = new MemoryStream();
                    HttpClient httpClient = new HttpClient();

                    Bitmap image = new Bitmap(await httpClient.GetStreamAsync("http://localhost:5287/" + recipe.ImagePath), false);
                    mStream.Dispose();

                    pbRecipe.Image = image;
                    pbRecipe.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch
            {
                MessageBox.Show("Something is wrong");
            }
        }
        
    }
}
