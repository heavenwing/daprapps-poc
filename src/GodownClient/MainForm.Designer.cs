namespace GodownClient
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basicSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBizScopeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLimitationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationFormToolStripMenuItem,
            this.basicSettingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationFormToolStripMenuItem
            // 
            this.applicationFormToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.applicationFormToolStripMenuItem.Name = "applicationFormToolStripMenuItem";
            this.applicationFormToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.applicationFormToolStripMenuItem.Text = "Application Form";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // basicSettingToolStripMenuItem
            // 
            this.basicSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBizScopeToolStripMenuItem,
            this.addLimitationToolStripMenuItem});
            this.basicSettingToolStripMenuItem.Name = "basicSettingToolStripMenuItem";
            this.basicSettingToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.basicSettingToolStripMenuItem.Text = "Basic Setting";
            // 
            // addBizScopeToolStripMenuItem
            // 
            this.addBizScopeToolStripMenuItem.Name = "addBizScopeToolStripMenuItem";
            this.addBizScopeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addBizScopeToolStripMenuItem.Text = "Add Biz Scope";
            this.addBizScopeToolStripMenuItem.Click += new System.EventHandler(this.addBizScopeToolStripMenuItem_Click);
            // 
            // addLimitationToolStripMenuItem
            // 
            this.addLimitationToolStripMenuItem.Name = "addLimitationToolStripMenuItem";
            this.addLimitationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addLimitationToolStripMenuItem.Text = "Add Limitation";
            this.addLimitationToolStripMenuItem.Click += new System.EventHandler(this.addLimitationToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Godown Client";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem applicationFormToolStripMenuItem;
        private ToolStripMenuItem createToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem basicSettingToolStripMenuItem;
        private ToolStripMenuItem addBizScopeToolStripMenuItem;
        private ToolStripMenuItem addLimitationToolStripMenuItem;
    }
}