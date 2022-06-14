namespace GodownClient
{
    partial class AddBizScopeOrLimitationForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 41);
            this.label3.TabIndex = 5;
            this.label3.Text = "Biz Entity";
            // 
            // comboBox3
            // 
            this.comboBox3.DisplayMember = "Name";
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(29, 123);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(735, 49);
            this.comboBox3.TabIndex = 4;
            this.comboBox3.ValueMember = "Id";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(603, 732);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(182, 63);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(29, 219);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(735, 444);
            this.checkedListBox1.TabIndex = 7;
            // 
            // AddBizScopeOrLimitationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 822);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox3);
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "AddBizScopeOrLimitationForm";
            this.Text = "AddB izScope or Limitation Form";
            this.Load += new System.EventHandler(this.AddBizScopeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label3;
        private ComboBox comboBox3;
        private Button btnAdd;
        private CheckedListBox checkedListBox1;
    }
}