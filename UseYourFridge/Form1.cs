using BLL.Managers;
using BLL.Models;
using DAL;

namespace UseYourFridge
{
    public partial class Form1 : Form
    {
        private UserManager userManager;
        private User? user = null;
        private Form? activeForm;
        private Button? activeButton = null;
        public Form1()
        {
            userManager = new UserManager(new UserDataAccess());
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;


            var a = userManager.GetAllUsers();
            if (a == null)
            {
                MessageBox.Show("Error");
            }
            int? userId = (int?)userManager.GetSetting("loggedAs");
            if (userId == null)
            {
                OpenLogIn();
            }
            else
            {
                user = userManager.GetUserById((int)userId);
                if (user == null)
                {
                    OpenLogIn();
                }
                else
                {
                    OpenChildForm(new Forms.Profile(user));
                }
            }
        }
        private void OpenLogIn()
        {
            void CloseLogIn(User user)
            {
                panelMenu.Visible = true;
                this.user = user;
                OpenChildForm(new Forms.Profile(user));
            }
            panelMenu.Visible = false;
            OpenChildForm(new Forms.LogIn(CloseLogIn));
        }
        private void OpenChildForm(Form childForm)
        {
            activeForm?.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void ChangeButtonColor(Button pressedButton)
        {
            Color defaultBtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(108)))), ((int)(((byte)(56)))));
            if (activeButton != null) activeButton.BackColor = defaultBtnColor;

            pressedButton.BackColor = Color.FromArgb(defaultBtnColor.A, defaultBtnColor.R + 57, defaultBtnColor.G + 57, defaultBtnColor.B + 57);
            activeButton = pressedButton;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Products());
            ChangeButtonColor(btnProducts);
        }

        private void btnRecipes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Recipes());
            ChangeButtonColor(btnRecipes);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Profile(user));
            ChangeButtonColor(btnProfile);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            userManager.SetSetting("loggedAs", null);
            OpenLogIn();
        }
    }
}