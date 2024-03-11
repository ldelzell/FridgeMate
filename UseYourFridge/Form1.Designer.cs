namespace UseYourFridge
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelDesktopPane = new Panel();
            panelMenu = new Panel();
            btnLogOut = new Button();
            btnProfile = new Button();
            btnRecipes = new Button();
            btnProducts = new Button();
            panelLogo = new Panel();
            btnHome = new Button();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            SuspendLayout();
            // 
            // panelDesktopPane
            // 
            panelDesktopPane.BackColor = Color.LightBlue;
            panelDesktopPane.Dock = DockStyle.Fill;
            panelDesktopPane.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panelDesktopPane.Location = new Point(216, 0);
            panelDesktopPane.Margin = new Padding(3, 2, 3, 2);
            panelDesktopPane.Name = "panelDesktopPane";
            panelDesktopPane.Size = new Size(584, 450);
            panelDesktopPane.TabIndex = 3;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(96, 108, 56);
            panelMenu.Controls.Add(btnLogOut);
            panelMenu.Controls.Add(btnProfile);
            panelMenu.Controls.Add(btnRecipes);
            panelMenu.Controls.Add(btnProducts);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(3, 2, 3, 2);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(216, 450);
            panelMenu.TabIndex = 4;
            // 
            // btnLogOut
            // 
            btnLogOut.Cursor = Cursors.Hand;
            btnLogOut.Dock = DockStyle.Bottom;
            btnLogOut.FlatAppearance.BorderSize = 0;
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogOut.ForeColor = Color.White;
            btnLogOut.Image = (Image)resources.GetObject("btnLogOut.Image");
            btnLogOut.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogOut.Location = new Point(0, 403);
            btnLogOut.Margin = new Padding(3, 2, 3, 2);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Padding = new Padding(10, 0, 0, 0);
            btnLogOut.Size = new Size(216, 47);
            btnLogOut.TabIndex = 7;
            btnLogOut.Text = "Log Out";
            btnLogOut.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnProfile
            // 
            btnProfile.Cursor = Cursors.Hand;
            btnProfile.Dock = DockStyle.Top;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnProfile.ForeColor = Color.White;
            btnProfile.ImageAlign = ContentAlignment.MiddleLeft;
            btnProfile.Location = new Point(0, 176);
            btnProfile.Margin = new Padding(3, 2, 3, 2);
            btnProfile.Name = "btnProfile";
            btnProfile.Padding = new Padding(10, 0, 0, 0);
            btnProfile.Size = new Size(216, 45);
            btnProfile.TabIndex = 3;
            btnProfile.Text = "Profile";
            btnProfile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnRecipes
            // 
            btnRecipes.BackColor = Color.FromArgb(96, 108, 56);
            btnRecipes.Cursor = Cursors.Hand;
            btnRecipes.Dock = DockStyle.Top;
            btnRecipes.FlatAppearance.BorderSize = 0;
            btnRecipes.FlatStyle = FlatStyle.Flat;
            btnRecipes.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnRecipes.ForeColor = Color.White;
            btnRecipes.ImageAlign = ContentAlignment.MiddleLeft;
            btnRecipes.Location = new Point(0, 131);
            btnRecipes.Margin = new Padding(3, 2, 3, 2);
            btnRecipes.Name = "btnRecipes";
            btnRecipes.Padding = new Padding(10, 0, 0, 0);
            btnRecipes.Size = new Size(216, 45);
            btnRecipes.TabIndex = 2;
            btnRecipes.Text = "Recipes";
            btnRecipes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRecipes.UseVisualStyleBackColor = false;
            btnRecipes.Click += btnRecipes_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(96, 108, 56);
            btnProducts.Cursor = Cursors.Hand;
            btnProducts.Dock = DockStyle.Top;
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnProducts.ForeColor = Color.White;
            btnProducts.ImageAlign = ContentAlignment.MiddleLeft;
            btnProducts.Location = new Point(0, 86);
            btnProducts.Margin = new Padding(3, 2, 3, 2);
            btnProducts.Name = "btnProducts";
            btnProducts.Padding = new Padding(10, 0, 0, 0);
            btnProducts.Size = new Size(216, 45);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "Products";
            btnProducts.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = SystemColors.InfoText;
            panelLogo.Controls.Add(btnHome);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(3, 2, 3, 2);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(216, 86);
            panelLogo.TabIndex = 0;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(40, 54, 24);
            btnHome.Cursor = Cursors.Hand;
            btnHome.Dock = DockStyle.Left;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Sitka Small", 19.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(0, 0);
            btnHome.Margin = new Padding(3, 2, 3, 2);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(216, 86);
            btnHome.TabIndex = 0;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelDesktopPane);
            Controls.Add(panelMenu);
            Name = "Form1";
            Text = "Form1";
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelDesktopPane;
        private Panel panelMenu;
        private Button btnLogOut;
        private Button btnProfile;
        private Button btnRecipes;
        private Button btnProducts;
        private Panel panelLogo;
        private Button btnHome;
    }
}