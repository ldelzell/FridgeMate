namespace UseYourFridge.Forms
{
    partial class Products
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
            dgvProducts = new DataGridView();
            btnAddProduct = new Button();
            btnDeleteProduct = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(174, 12);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowTemplate.Height = 25;
            dgvProducts.Size = new Size(1442, 769);
            dgvProducts.TabIndex = 0;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddProduct.Location = new Point(174, 818);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(339, 93);
            btnAddProduct.TabIndex = 7;
            btnAddProduct.Text = "Add Product";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteProduct.Location = new Point(579, 818);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(339, 93);
            btnDeleteProduct.TabIndex = 8;
            btnDeleteProduct.Text = "Delete Product";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1628, 975);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnAddProduct);
            Controls.Add(dgvProducts);
            Name = "Products";
            Text = "Products";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProducts;
        private Button btnAddProduct;
        private Button btnDeleteProduct;
    }
}