using BLL.Interfaces.Strategy_Pattern;
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
    public partial class LogIn : Form
    {
        private Action<User> closeForm;
        public UserManager userManager;
        private LogInManager loginManager;
        private bool isUserNameLoging = false;
        public LogIn(Action<User> closeForm)
        {
            userManager = new UserManager(new UserDataAccess());
            loginManager = new LogInManager(new UsernameLoginStrategy(userManager));
            this.closeForm = closeForm;
            InitializeComponent();

        }
        private void ValidateUser()
        {
            try
            {
                string usernameOrPhoneNumber = tbUserName.Text;
                string password = tbPassword.Text;
                bool isValidUser = loginManager.Authenticate(usernameOrPhoneNumber, password, out int id);
                //bool isValidUser = userManager.CheckLogIn(usernameOrPhoneNumber, password, out int id);
                if (isValidUser)
                {
                    User? user = userManager.GetUserById(id);
                    if (user == null)
                    {
                        MessageBox.Show("Wrong");
                    }
                    else
                    {
                        userManager.SetSetting("loggedAs", id);
                        closeForm(user);
                    }
                }
                else
                {
                    MessageBox.Show("Wrong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            ValidateUser();
        }
        private void btnCreateAccountLogIn_Click(object sender, EventArgs e)
        {
            var CreateAccount = new CreateAccount();

            this.Hide();
            CreateAccount.ShowDialog();
            this.Show();
        }

        private void btnChangeLogInType_Click(object sender, EventArgs e)
        {
            if (!isUserNameLoging)
            {
                loginManager = new LogInManager(new PhoneNumberLoginStrategy(userManager));
                MessageBox.Show("Changed to Phone Number login.");
                btnChangeLogInType.Text = "Use Username";
            }
            else
            {
                loginManager = new LogInManager(new UsernameLoginStrategy(userManager));
                MessageBox.Show("Changed to Username login.");
                btnChangeLogInType.Text = "Use Phone Number";
                tbUserName.PlaceholderText = "Phone Numbercfxc";
            }

            isUserNameLoging = !isUserNameLoging;
        }
    }
}
