namespace UseYourFridge.Forms
{
    partial class Recipes
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
            btnAddRecipe = new Button();
            dgvRecipes = new DataGridView();
            btnDeleteRecipe = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRecipes).BeginInit();
            SuspendLayout();
            // 
            // btnAddRecipe
            // 
            btnAddRecipe.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddRecipe.Location = new Point(596, 824);
            btnAddRecipe.Name = "btnAddRecipe";
            btnAddRecipe.Size = new Size(361, 104);
            btnAddRecipe.TabIndex = 0;
            btnAddRecipe.Text = "Add Recipe";
            btnAddRecipe.UseVisualStyleBackColor = true;
            btnAddRecipe.Click += btnAddRecipe_Click;
            // 
            // dgvRecipes
            // 
            dgvRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecipes.Location = new Point(129, -3);
            dgvRecipes.Name = "dgvRecipes";
            dgvRecipes.RowTemplate.Height = 25;
            dgvRecipes.Size = new Size(1526, 810);
            dgvRecipes.TabIndex = 1;
            // 
            // btnDeleteRecipe
            // 
            btnDeleteRecipe.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteRecipe.Location = new Point(129, 824);
            btnDeleteRecipe.Name = "btnDeleteRecipe";
            btnDeleteRecipe.Size = new Size(361, 104);
            btnDeleteRecipe.TabIndex = 2;
            btnDeleteRecipe.Text = "Delete";
            btnDeleteRecipe.UseVisualStyleBackColor = true;
            btnDeleteRecipe.Click += btnDeleteRecipe_Click;
            // 
            // Recipes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btnDeleteRecipe);
            Controls.Add(dgvRecipes);
            Controls.Add(btnAddRecipe);
            Name = "Recipes";
            Text = "Recipes";
            Load += Recipes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRecipes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAddRecipe;
        private DataGridView dgvRecipes;
        private Button btnDeleteRecipe;
    }
}