namespace UseYourFridge.Forms
{
    partial class AddRecipe
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
            panel1 = new Panel();
            label1 = new Label();
            btnAddRecipe = new Button();
            btnAddImage = new Button();
            pbProductImage = new PictureBox();
            cbType = new ComboBox();
            tbName = new TextBox();
            rtbDescription = new RichTextBox();
            tbSweets = new TextBox();
            tbSideDish = new TextBox();
            nudProtein = new NumericUpDown();
            lbIngredients = new ListBox();
            cbProducts = new ComboBox();
            btnAddIngredient = new Button();
            btnDeleteIngredient = new Button();
            groupBox1 = new GroupBox();
            tbVegetable = new TextBox();
            lbProtein = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbProductImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudProtein).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-7, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(567, 109);
            panel1.TabIndex = 34;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 40F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(116, 9);
            label1.Name = "label1";
            label1.Size = new Size(300, 72);
            label1.TabIndex = 0;
            label1.Text = "Add Recipe";
            // 
            // btnAddRecipe
            // 
            btnAddRecipe.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddRecipe.Location = new Point(120, 730);
            btnAddRecipe.Name = "btnAddRecipe";
            btnAddRecipe.Size = new Size(300, 68);
            btnAddRecipe.TabIndex = 33;
            btnAddRecipe.Text = "Add Recipe";
            btnAddRecipe.UseVisualStyleBackColor = true;
            btnAddRecipe.Click += btnAddRecipe_Click;
            // 
            // btnAddImage
            // 
            btnAddImage.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddImage.Location = new Point(181, 683);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(190, 32);
            btnAddImage.TabIndex = 32;
            btnAddImage.Text = "Add Image";
            btnAddImage.UseVisualStyleBackColor = true;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // pbProductImage
            // 
            pbProductImage.Location = new Point(158, 604);
            pbProductImage.Name = "pbProductImage";
            pbProductImage.Size = new Size(239, 73);
            pbProductImage.TabIndex = 30;
            pbProductImage.TabStop = false;
            // 
            // cbType
            // 
            cbType.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(167, 114);
            cbType.Name = "cbType";
            cbType.Size = new Size(217, 33);
            cbType.TabIndex = 27;
            cbType.SelectedIndexChanged += cbType_SelectedIndexChanged;
            // 
            // tbName
            // 
            tbName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbName.Location = new Point(167, 153);
            tbName.Name = "tbName";
            tbName.PlaceholderText = "Product Name";
            tbName.Size = new Size(217, 32);
            tbName.TabIndex = 25;
            tbName.KeyPress += tbName_KeyPress;
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(167, 191);
            rtbDescription.MaxLength = 2147;
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(217, 118);
            rtbDescription.TabIndex = 35;
            rtbDescription.Text = "";
            // 
            // tbSweets
            // 
            tbSweets.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbSweets.Location = new Point(167, 343);
            tbSweets.Name = "tbSweets";
            tbSweets.PlaceholderText = "Sweet";
            tbSweets.Size = new Size(217, 32);
            tbSweets.TabIndex = 36;
            // 
            // tbSideDish
            // 
            tbSideDish.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbSideDish.Location = new Point(167, 343);
            tbSideDish.Name = "tbSideDish";
            tbSideDish.PlaceholderText = "Side Dish";
            tbSideDish.Size = new Size(217, 32);
            tbSideDish.TabIndex = 37;
            // 
            // nudProtein
            // 
            nudProtein.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            nudProtein.Location = new Point(167, 344);
            nudProtein.Name = "nudProtein";
            nudProtein.Size = new Size(217, 32);
            nudProtein.TabIndex = 40;
            nudProtein.ValueChanged += nudProtein_ValueChanged;
            // 
            // lbIngredients
            // 
            lbIngredients.FormattingEnabled = true;
            lbIngredients.ItemHeight = 15;
            lbIngredients.Location = new Point(18, 57);
            lbIngredients.Name = "lbIngredients";
            lbIngredients.Size = new Size(217, 79);
            lbIngredients.TabIndex = 41;
            // 
            // cbProducts
            // 
            cbProducts.FormattingEnabled = true;
            cbProducts.Location = new Point(18, 28);
            cbProducts.Name = "cbProducts";
            cbProducts.Size = new Size(217, 23);
            cbProducts.TabIndex = 42;
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.Location = new Point(18, 142);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(101, 23);
            btnAddIngredient.TabIndex = 43;
            btnAddIngredient.Text = "Add";
            btnAddIngredient.UseVisualStyleBackColor = true;
            btnAddIngredient.Click += btnAddIngredient_Click;
            // 
            // btnDeleteIngredient
            // 
            btnDeleteIngredient.Location = new Point(134, 142);
            btnDeleteIngredient.Name = "btnDeleteIngredient";
            btnDeleteIngredient.Size = new Size(101, 23);
            btnDeleteIngredient.TabIndex = 44;
            btnDeleteIngredient.Text = "Delete";
            btnDeleteIngredient.UseVisualStyleBackColor = true;
            btnDeleteIngredient.Click += btnDeleteIngredient_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbIngredients);
            groupBox1.Controls.Add(btnDeleteIngredient);
            groupBox1.Controls.Add(cbProducts);
            groupBox1.Controls.Add(btnAddIngredient);
            groupBox1.Location = new Point(148, 426);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(254, 172);
            groupBox1.TabIndex = 45;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingredient";
            // 
            // tbVegetable
            // 
            tbVegetable.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbVegetable.Location = new Point(167, 384);
            tbVegetable.Name = "tbVegetable";
            tbVegetable.PlaceholderText = "Vegetable";
            tbVegetable.Size = new Size(217, 32);
            tbVegetable.TabIndex = 39;
            tbVegetable.KeyPress += tbVegetable_KeyPress;
            // 
            // lbProtein
            // 
            lbProtein.AutoSize = true;
            lbProtein.Location = new Point(166, 325);
            lbProtein.Name = "lbProtein";
            lbProtein.Size = new Size(99, 15);
            lbProtein.TabIndex = 46;
            lbProtein.Text = "Protein(in grams)";
            // 
            // AddRecipe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 836);
            Controls.Add(lbProtein);
            Controls.Add(groupBox1);
            Controls.Add(nudProtein);
            Controls.Add(tbVegetable);
            Controls.Add(tbSideDish);
            Controls.Add(tbSweets);
            Controls.Add(rtbDescription);
            Controls.Add(panel1);
            Controls.Add(btnAddRecipe);
            Controls.Add(btnAddImage);
            Controls.Add(pbProductImage);
            Controls.Add(cbType);
            Controls.Add(tbName);
            Name = "AddRecipe";
            Text = "AddRecipe";
            Load += AddRecipe_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbProductImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudProtein).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button btnAddRecipe;
        private Button btnAddImage;
        private PictureBox pbProductImage;
        private ComboBox cbType;
        private TextBox tbName;
        private RichTextBox rtbDescription;
        private TextBox tbSweets;
        private TextBox tbSideDish;
        private NumericUpDown nudProtein;
        private ListBox lbIngredients;
        private ComboBox cbProducts;
        private Button btnAddIngredient;
        private Button btnDeleteIngredient;
        private GroupBox groupBox1;
        private TextBox tbVegetable;
        private Label lbProtein;
    }
}