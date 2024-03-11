namespace UseYourFridge.Forms
{
    partial class CreateAccount
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
            createAccountPannel = new Panel();
            label3 = new Label();
            tbPasswordd = new TextBox();
            label2 = new Label();
            nudPhoneNumber = new NumericUpDown();
            lbSuggestedUsername = new Label();
            panel1 = new Panel();
            pbProfileImage = new PictureBox();
            btnAddImage = new Button();
            panel2 = new Panel();
            label1 = new Label();
            tbUserName = new TextBox();
            btnCreateAccount = new Button();
            tbPassword = new TextBox();
            tbEmail = new TextBox();
            tbLastName = new TextBox();
            tbFirstName = new TextBox();
            createAccountPannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPhoneNumber).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbProfileImage).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // createAccountPannel
            // 
            createAccountPannel.Anchor = AnchorStyles.None;
            createAccountPannel.BackColor = Color.FromArgb(96, 108, 56);
            createAccountPannel.Controls.Add(label3);
            createAccountPannel.Controls.Add(tbPasswordd);
            createAccountPannel.Controls.Add(label2);
            createAccountPannel.Controls.Add(nudPhoneNumber);
            createAccountPannel.Controls.Add(lbSuggestedUsername);
            createAccountPannel.Controls.Add(panel1);
            createAccountPannel.Controls.Add(btnAddImage);
            createAccountPannel.Controls.Add(panel2);
            createAccountPannel.Controls.Add(tbUserName);
            createAccountPannel.Controls.Add(btnCreateAccount);
            createAccountPannel.Controls.Add(tbPassword);
            createAccountPannel.Controls.Add(tbEmail);
            createAccountPannel.Controls.Add(tbLastName);
            createAccountPannel.Controls.Add(tbFirstName);
            createAccountPannel.Location = new Point(119, 11);
            createAccountPannel.Name = "createAccountPannel";
            createAccountPannel.Size = new Size(837, 566);
            createAccountPannel.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.Location = new Point(109, 270);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 15;
            // 
            // tbPasswordd
            // 
            tbPasswordd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbPasswordd.Location = new Point(110, 341);
            tbPasswordd.Name = "tbPasswordd";
            tbPasswordd.PlaceholderText = "Password";
            tbPasswordd.Size = new Size(213, 29);
            tbPasswordd.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(110, 214);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 13;
            label2.Text = "Phone Number:";
            // 
            // nudPhoneNumber
            // 
            nudPhoneNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nudPhoneNumber.Location = new Point(110, 237);
            nudPhoneNumber.Maximum = new decimal(new int[] { 1569325056, 23283064, 0, 0 });
            nudPhoneNumber.Name = "nudPhoneNumber";
            nudPhoneNumber.Size = new Size(213, 29);
            nudPhoneNumber.TabIndex = 12;
            // 
            // lbSuggestedUsername
            // 
            lbSuggestedUsername.AutoSize = true;
            lbSuggestedUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbSuggestedUsername.ForeColor = SystemColors.ButtonFace;
            lbSuggestedUsername.Location = new Point(169, 349);
            lbSuggestedUsername.Name = "lbSuggestedUsername";
            lbSuggestedUsername.Size = new Size(0, 21);
            lbSuggestedUsername.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pbProfileImage);
            panel1.Location = new Point(414, 71);
            panel1.Name = "panel1";
            panel1.Size = new Size(344, 409);
            panel1.TabIndex = 10;
            // 
            // pbProfileImage
            // 
            pbProfileImage.Location = new Point(16, 3);
            pbProfileImage.Name = "pbProfileImage";
            pbProfileImage.Size = new Size(312, 395);
            pbProfileImage.TabIndex = 8;
            pbProfileImage.TabStop = false;
            // 
            // btnAddImage
            // 
            btnAddImage.BackColor = Color.SteelBlue;
            btnAddImage.Cursor = Cursors.Hand;
            btnAddImage.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddImage.ForeColor = Color.White;
            btnAddImage.Location = new Point(138, 438);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(148, 54);
            btnAddImage.TabIndex = 9;
            btnAddImage.Text = "Add Image";
            btnAddImage.UseVisualStyleBackColor = false;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(40, 54, 24);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(847, 65);
            panel2.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(252, 0);
            label1.Name = "label1";
            label1.Size = new Size(351, 65);
            label1.TabIndex = 0;
            label1.Text = "Create Account";
            // 
            // tbUserName
            // 
            tbUserName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbUserName.Location = new Point(110, 289);
            tbUserName.Name = "tbUserName";
            tbUserName.PlaceholderText = "Username";
            tbUserName.Size = new Size(213, 29);
            tbUserName.TabIndex = 6;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.BackColor = Color.SteelBlue;
            btnCreateAccount.Cursor = Cursors.Hand;
            btnCreateAccount.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreateAccount.ForeColor = Color.White;
            btnCreateAccount.Location = new Point(447, 486);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(295, 57);
            btnCreateAccount.TabIndex = 4;
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.UseVisualStyleBackColor = false;
            btnCreateAccount.Click += btnCreateAccount_Click;
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.None;
            tbPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword.Location = new Point(428, 669);
            tbPassword.Name = "tbPassword";
            tbPassword.PlaceholderText = "Password";
            tbPassword.Size = new Size(213, 29);
            tbPassword.TabIndex = 3;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbEmail.Location = new Point(110, 393);
            tbEmail.Name = "tbEmail";
            tbEmail.PlaceholderText = "Email";
            tbEmail.Size = new Size(213, 27);
            tbEmail.TabIndex = 2;
            // 
            // tbLastName
            // 
            tbLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbLastName.Location = new Point(110, 171);
            tbLastName.Name = "tbLastName";
            tbLastName.PlaceholderText = "Last Name";
            tbLastName.Size = new Size(213, 29);
            tbLastName.TabIndex = 1;
            // 
            // tbFirstName
            // 
            tbFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbFirstName.Location = new Point(110, 102);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.PlaceholderText = "First Name";
            tbFirstName.Size = new Size(213, 29);
            tbFirstName.TabIndex = 0;
            // 
            // CreateAccount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 615);
            Controls.Add(createAccountPannel);
            Name = "CreateAccount";
            Text = "CreateAccount";
            createAccountPannel.ResumeLayout(false);
            createAccountPannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPhoneNumber).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbProfileImage).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel createAccountPannel;
        private Label label2;
        private NumericUpDown nudPhoneNumber;
        private Label lbSuggestedUsername;
        private Panel panel1;
        private PictureBox pbProfileImage;
        private Button btnAddImage;
        private Panel panel2;
        private Label label1;
        private TextBox tbUserName;
        private Button btnCreateAccount;
        private TextBox tbPassword;
        private TextBox tbEmail;
        private TextBox tbLastName;
        private TextBox tbFirstName;
        private TextBox tbPasswordd;
        private Label label3;
    }
}