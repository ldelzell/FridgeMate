namespace UseYourFridge.Forms
{
    partial class Profile
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
            pbProfilePicture = new PictureBox();
            btnChangeProfilePic = new Button();
            tbFirstName = new TextBox();
            tbLastName = new TextBox();
            tbUserName = new TextBox();
            tbPhoneNumber = new TextBox();
            lbFirstName = new Label();
            panel1 = new Panel();
            btnChangeCredentials = new Button();
            lbLastName = new Label();
            ((System.ComponentModel.ISupportInitialize)pbProfilePicture).BeginInit();
            SuspendLayout();
            // 
            // pbProfilePicture
            // 
            pbProfilePicture.Location = new Point(1006, 25);
            pbProfilePicture.Name = "pbProfilePicture";
            pbProfilePicture.Size = new Size(591, 773);
            pbProfilePicture.TabIndex = 0;
            pbProfilePicture.TabStop = false;
            // 
            // btnChangeProfilePic
            // 
            btnChangeProfilePic.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            btnChangeProfilePic.Location = new Point(1176, 804);
            btnChangeProfilePic.Name = "btnChangeProfilePic";
            btnChangeProfilePic.Size = new Size(298, 55);
            btnChangeProfilePic.TabIndex = 1;
            btnChangeProfilePic.Text = "Change Picture";
            btnChangeProfilePic.UseVisualStyleBackColor = true;
            btnChangeProfilePic.Click += btnChangeProfilePic_Click;
            // 
            // tbFirstName
            // 
            tbFirstName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbFirstName.Location = new Point(64, 129);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.PlaceholderText = "First Name";
            tbFirstName.Size = new Size(195, 32);
            tbFirstName.TabIndex = 2;
            // 
            // tbLastName
            // 
            tbLastName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbLastName.Location = new Point(64, 200);
            tbLastName.Name = "tbLastName";
            tbLastName.PlaceholderText = "Last Name";
            tbLastName.Size = new Size(195, 32);
            tbLastName.TabIndex = 3;
            // 
            // tbUserName
            // 
            tbUserName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbUserName.Location = new Point(64, 264);
            tbUserName.Name = "tbUserName";
            tbUserName.PlaceholderText = "Username";
            tbUserName.Size = new Size(195, 32);
            tbUserName.TabIndex = 4;
            // 
            // tbPhoneNumber
            // 
            tbPhoneNumber.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbPhoneNumber.Location = new Point(64, 329);
            tbPhoneNumber.MaxLength = 999999999;
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.PlaceholderText = "Phone number";
            tbPhoneNumber.Size = new Size(195, 32);
            tbPhoneNumber.TabIndex = 5;
            // 
            // lbFirstName
            // 
            lbFirstName.AutoSize = true;
            lbFirstName.Font = new Font("Segoe UI", 26F, FontStyle.Regular, GraphicsUnit.Point);
            lbFirstName.Location = new Point(64, 15);
            lbFirstName.Name = "lbFirstName";
            lbFirstName.Size = new Size(112, 47);
            lbFirstName.TabIndex = 6;
            lbFirstName.Text = "label1";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGreen;
            panel1.Location = new Point(15, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(509, 10);
            panel1.TabIndex = 7;
            // 
            // btnChangeCredentials
            // 
            btnChangeCredentials.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnChangeCredentials.Location = new Point(64, 403);
            btnChangeCredentials.Name = "btnChangeCredentials";
            btnChangeCredentials.Size = new Size(195, 36);
            btnChangeCredentials.TabIndex = 8;
            btnChangeCredentials.Text = "Edit Information";
            btnChangeCredentials.UseVisualStyleBackColor = true;
            btnChangeCredentials.Click += btnChangeCredentials_Click;
            // 
            // lbLastName
            // 
            lbLastName.AutoSize = true;
            lbLastName.Font = new Font("Segoe UI", 26F, FontStyle.Regular, GraphicsUnit.Point);
            lbLastName.Location = new Point(260, 15);
            lbLastName.Name = "lbLastName";
            lbLastName.Size = new Size(112, 47);
            lbLastName.TabIndex = 9;
            lbLastName.Text = "label1";
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(1693, 864);
            Controls.Add(lbLastName);
            Controls.Add(btnChangeCredentials);
            Controls.Add(panel1);
            Controls.Add(lbFirstName);
            Controls.Add(tbPhoneNumber);
            Controls.Add(tbUserName);
            Controls.Add(tbLastName);
            Controls.Add(tbFirstName);
            Controls.Add(btnChangeProfilePic);
            Controls.Add(pbProfilePicture);
            Name = "Profile";
            Text = "Profile";
            ((System.ComponentModel.ISupportInitialize)pbProfilePicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbProfilePicture;
        private Button btnChangeProfilePic;
        private TextBox tbFirstName;
        private TextBox tbLastName;
        private TextBox tbUserName;
        private TextBox tbPhoneNumber;
        private Label lbFirstName;
        private Panel panel1;
        private Button btnChangeCredentials;
        private Label lbLastName;
    }
}