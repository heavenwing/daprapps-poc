namespace GodownClient
{
    partial class ApplicationLoadForm
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
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnTake = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(12, 12);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(694, 366);
            this.txtInfo.TabIndex = 0;
            // 
            // btnTake
            // 
            this.btnTake.Location = new System.Drawing.Point(12, 384);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(121, 23);
            this.btnTake.TabIndex = 1;
            this.btnTake.Text = "Take Delivery";
            this.btnTake.UseVisualStyleBackColor = true;
            this.btnTake.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // ApplicationShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.btnTake);
            this.Controls.Add(this.txtInfo);
            this.Name = "ApplicationShowForm";
            this.Text = "ApplicationShowForm";
            this.Load += new System.EventHandler(this.ApplicationShowForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtInfo;
        private Button btnTake;
    }
}