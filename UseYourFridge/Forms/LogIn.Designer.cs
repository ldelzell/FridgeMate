namespace UseYourFridge.Forms
{
    partial class LogIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            loginPanel = new Panel();
            btnChangeLogInType = new Button();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label1 = new Label();
            btnCreateAccountLogIn = new Button();
            tbPassword = new TextBox();
            tbUserName = new TextBox();
            btnLogIn = new Button();
            loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // loginPanel
            // 
            loginPanel.Anchor = AnchorStyles.None;
            loginPanel.AutoSize = true;
            loginPanel.BackColor = Color.FromArgb(96, 108, 56);
            loginPanel.Controls.Add(btnChangeLogInType);
            loginPanel.Controls.Add(pictureBox1);
            loginPanel.Controls.Add(panel1);
            loginPanel.Controls.Add(btnCreateAccountLogIn);
            loginPanel.Controls.Add(tbPassword);
            loginPanel.Controls.Add(tbUserName);
            loginPanel.Controls.Add(btnLogIn);
            loginPanel.Location = new Point(346, 28);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(430, 587);
            loginPanel.TabIndex = 1;
            // 
            // btnChangeLogInType
            // 
            btnChangeLogInType.Location = new Point(118, 178);
            btnChangeLogInType.Name = "btnChangeLogInType";
            btnChangeLogInType.Size = new Size(121, 23);
            btnChangeLogInType.TabIndex = 8;
            btnChangeLogInType.Text = "Use Phone Number";
            btnChangeLogInType.UseVisualStyleBackColor = true;
            btnChangeLogInType.Click += btnChangeLogInType_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(145, 87);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(145, 67);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 54, 24);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(425, 79);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 39.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(125, -2);
            label1.Name = "label1";
            label1.Size = new Size(176, 71);
            label1.TabIndex = 0;
            label1.Text = "Log In";
            // 
            // btnCreateAccountLogIn
            // 
            btnCreateAccountLogIn.BackColor = Color.SteelBlue;
            btnCreateAccountLogIn.Cursor = Cursors.Hand;
            btnCreateAccountLogIn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreateAccountLogIn.ForeColor = Color.White;
            btnCreateAccountLogIn.Location = new Point(118, 536);
            btnCreateAccountLogIn.Name = "btnCreateAccountLogIn";
            btnCreateAccountLogIn.Size = new Size(190, 29);
            btnCreateAccountLogIn.TabIndex = 5;
            btnCreateAccountLogIn.Text = "Create Account?";
            btnCreateAccountLogIn.UseVisualStyleBackColor = false;
            btnCreateAccountLogIn.Click += btnCreateAccountLogIn_Click;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword.Location = new Point(118, 262);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.PlaceholderText = "Password";
            tbPassword.Size = new Size(206, 31);
            tbPassword.TabIndex = 2;
            // 
            // tbUserName
            // 
            tbUserName.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            tbUserName.Location = new Point(118, 207);
            tbUserName.Name = "tbUserName";
            tbUserName.PlaceholderText = "Username";
            tbUserName.Size = new Size(206, 31);
            tbUserName.TabIndex = 1;
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = Color.SteelBlue;
            btnLogIn.BackgroundImageLayout = ImageLayout.None;
            btnLogIn.Cursor = Cursors.Hand;
            btnLogIn.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogIn.ForeColor = Color.White;
            btnLogIn.Location = new Point(145, 346);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(135, 48);
            btnLogIn.TabIndex = 0;
            btnLogIn.Text = "Log In";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1122, 659);
            Controls.Add(loginPanel);
            Name = "LogIn";
            Text = "LogIn";
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel loginPanel;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label1;
        private Button btnCreateAccountLogIn;
        private TextBox tbPassword;
        private TextBox tbUserName;
        private Button btnLogIn;
        private Button btnChangeLogInType;
    }
}