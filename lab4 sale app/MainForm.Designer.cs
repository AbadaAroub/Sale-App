namespace lab4_sale_app
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.kassatab = new System.Windows.Forms.TabPage();
            this.invtab = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.kassatab);
            this.tabControl1.Controls.Add(this.invtab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // kassatab
            // 
            this.kassatab.Location = new System.Drawing.Point(4, 22);
            this.kassatab.Name = "kassatab";
            this.kassatab.Padding = new System.Windows.Forms.Padding(3);
            this.kassatab.Size = new System.Drawing.Size(792, 424);
            this.kassatab.TabIndex = 0;
            this.kassatab.Text = "checkout";
            this.kassatab.UseVisualStyleBackColor = true;
            // 
            // invtab
            // 
            this.invtab.Location = new System.Drawing.Point(4, 22);
            this.invtab.Name = "invtab";
            this.invtab.Padding = new System.Windows.Forms.Padding(3);
            this.invtab.Size = new System.Drawing.Size(792, 424);
            this.invtab.TabIndex = 1;
            this.invtab.Text = "Inventory";
            this.invtab.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Library Managment";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage kassatab;
        private System.Windows.Forms.TabPage invtab;
    }
}

