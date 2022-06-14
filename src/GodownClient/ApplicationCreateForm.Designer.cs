namespace GodownClient
{
    partial class ApplicationCreateForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.productListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCreate = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.providerListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.companyListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnLoadProducts = new System.Windows.Forms.Button();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.providerListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(351, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 338);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productNameDataGridViewTextBoxColumn,
            this.AllowAmount,
            this.productAmountDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.productsBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(365, 316);
            this.dataGridView1.TabIndex = 0;
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataMember = "Details";
            this.productsBindingSource.DataSource = this.bindingSource1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(GodownClient.ViewModels.ApplicationOrderModel);
            // 
            // productListBindingSource
            // 
            this.productListBindingSource.DataMember = "ProductList";
            this.productListBindingSource.DataSource = this.bindingSource1;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 287);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(305, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create Application Order";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource1, "ProviderId", true));
            this.comboBox1.DataSource = this.providerListBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 104);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(305, 23);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.ValueMember = "Id";
            // 
            // providerListBindingSource
            // 
            this.providerListBindingSource.DataMember = "ProviderList";
            this.providerListBindingSource.DataSource = this.bindingSource1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Provider";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.productListBindingSource;
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(12, 217);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(305, 23);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.ValueMember = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(242, 246);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 326);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(305, 23);
            this.textBox1.TabIndex = 4;
            // 
            // comboBox3
            // 
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource1, "CompanyId", true));
            this.comboBox3.DataSource = this.companyListBindingSource;
            this.comboBox3.DisplayMember = "Name";
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(12, 37);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(305, 23);
            this.comboBox3.TabIndex = 2;
            this.comboBox3.ValueMember = "Id";
            // 
            // companyListBindingSource
            // 
            this.companyListBindingSource.DataMember = "CompanyList";
            this.companyListBindingSource.DataSource = this.bindingSource1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Company";
            // 
            // btnLoadProducts
            // 
            this.btnLoadProducts.Location = new System.Drawing.Point(12, 149);
            this.btnLoadProducts.Name = "btnLoadProducts";
            this.btnLoadProducts.Size = new System.Drawing.Size(305, 23);
            this.btnLoadProducts.TabIndex = 1;
            this.btnLoadProducts.Text = "Load Products";
            this.btnLoadProducts.UseVisualStyleBackColor = true;
            this.btnLoadProducts.Click += new System.EventHandler(this.btnLoadProducts_Click);
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // AllowAmount
            // 
            this.AllowAmount.DataPropertyName = "AllowAmount";
            this.AllowAmount.HeaderText = "AllowAmount";
            this.AllowAmount.Name = "AllowAmount";
            this.AllowAmount.ReadOnly = true;
            // 
            // productAmountDataGridViewTextBoxColumn
            // 
            this.productAmountDataGridViewTextBoxColumn.DataPropertyName = "ProductAmount";
            this.productAmountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.productAmountDataGridViewTextBoxColumn.Name = "productAmountDataGridViewTextBoxColumn";
            // 
            // ApplicationCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 361);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnLoadProducts);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.groupBox1);
            this.Name = "ApplicationCreateForm";
            this.Text = "ApplicationFormForm";
            this.Load += new System.EventHandler(this.ApplicationFormForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.providerListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Button btnCreate;
        private ComboBox comboBox1;
        private Label label1;
        private BindingSource bindingSource1;
        private BindingSource productListBindingSource;
        private BindingSource productsBindingSource;
        private BindingSource providerListBindingSource;
        private DataGridViewComboBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private ComboBox comboBox2;
        private Label label2;
        private Button btnAdd;
        private DataGridView dataGridView1;
        private TextBox textBox1;
        private ComboBox comboBox3;
        private Label label3;
        private Button btnLoadProducts;
        private BindingSource companyListBindingSource;
        private DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn AllowAmount;
        private DataGridViewTextBoxColumn productAmountDataGridViewTextBoxColumn;
    }
}
