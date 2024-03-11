namespace UseYourFridge.Forms
{
    partial class AddProduct
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
            btnAddImage = new Button();
            label2 = new Label();
            pbProductImage = new PictureBox();
            dtExpirationDate = new DateTimePicker();
            nudQuantity = new NumericUpDown();
            cbType = new ComboBox();
            tbNutrients = new TextBox();
            tbName = new TextBox();
            btnAddProduct = new Button();
            panel1 = new Panel();
            label1 = new Label();
            label3 = new Label();
            tbPrice = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pbProductImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddImage
            // 
            btnAddImage.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddImage.Location = new Point(185, 557);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(190, 32);
            btnAddImage.TabIndex = 22;
            btnAddImage.Text = "Add Image";
            btnAddImage.UseVisualStyleBackColor = true;
            btnAddImage.Click += btnAddImage_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(185, 232);
            label2.Name = "label2";
            label2.Size = new Size(180, 25);
            label2.TabIndex = 21;
            label2.Text = "Quantity (in Grams):";
            // 
            // pbProductImage
            // 
            pbProductImage.Location = new Point(157, 394);
            pbProductImage.Name = "pbProductImage";
            pbProductImage.Size = new Size(239, 157);
            pbProductImage.TabIndex = 18;
            pbProductImage.TabStop = false;
            // 
            // dtExpirationDate
            // 
            dtExpirationDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtExpirationDate.Location = new Point(151, 298);
            dtExpirationDate.Name = "dtExpirationDate";
            dtExpirationDate.Size = new Size(268, 29);
            dtExpirationDate.TabIndex = 17;
            // 
            // nudQuantity
            // 
            nudQuantity.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            nudQuantity.Location = new Point(174, 260);
            nudQuantity.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(222, 32);
            nudQuantity.TabIndex = 16;
            // 
            // cbType
            // 
            cbType.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(176, 154);
            cbType.Name = "cbType";
            cbType.Size = new Size(219, 33);
            cbType.TabIndex = 15;
            // 
            // tbNutrients
            // 
            tbNutrients.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbNutrients.Location = new Point(176, 193);
            tbNutrients.Name = "tbNutrients";
            tbNutrients.PlaceholderText = "Nutrients";
            tbNutrients.Size = new Size(219, 32);
            tbNutrients.TabIndex = 14;
            // 
            // tbName
            // 
            tbName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbName.Location = new Point(176, 116);
            tbName.Name = "tbName";
            tbName.PlaceholderText = "Product Name";
            tbName.Size = new Size(219, 32);
            tbName.TabIndex = 13;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddProduct.Location = new Point(129, 595);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(300, 68);
            btnAddProduct.TabIndex = 23;
            btnAddProduct.Text = "Add Product";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(567, 109);
            panel1.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 40F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(116, 9);
            label1.Name = "label1";
            label1.Size = new Size(331, 72);
            label1.TabIndex = 0;
            label1.Text = "Add Product";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(185, 330);
            label3.Name = "label3";
            label3.Size = new Size(58, 25);
            label3.TabIndex = 26;
            label3.Text = "Price:";
            // 
            // tbPrice
            // 
            tbPrice.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbPrice.Location = new Point(176, 356);
            tbPrice.Name = "tbPrice";
            tbPrice.Size = new Size(222, 32);
            tbPrice.TabIndex = 27;
            tbPrice.TextChanged += tbPrice_TextChanged;
            // 
            // AddProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(566, 675);
            Controls.Add(tbPrice);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(btnAddProduct);
            Controls.Add(btnAddImage);
            Controls.Add(label2);
            Controls.Add(pbProductImage);
            Controls.Add(dtExpirationDate);
            Controls.Add(nudQuantity);
            Controls.Add(cbType);
            Controls.Add(tbNutrients);
            Controls.Add(tbName);
            Name = "AddProduct";
            Text = "AddProduct";
            ((System.ComponentModel.ISupportInitialize)pbProductImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddImage;
        private Label label2;
        private PictureBox pbProductImage;
        private DateTimePicker dtExpirationDate;
        private NumericUpDown nudQuantity;
        private ComboBox cbType;
        private TextBox tbNutrients;
        private TextBox tbName;
        private Button btnAddProduct;
        private Panel panel1;
        private Label label1;
        private Label label3;
        private TextBox tbPrice;
    }
}