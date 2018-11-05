namespace Gestión
{
    partial class Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aBMEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCompañíasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMTerminalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viajesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internacionalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nacionalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMEmpleadosToolStripMenuItem,
            this.aBMCompañíasToolStripMenuItem,
            this.aBMTerminalesToolStripMenuItem,
            this.viajesToolStripMenuItem,
            this.estadisticasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(514, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aBMEmpleadosToolStripMenuItem
            // 
            this.aBMEmpleadosToolStripMenuItem.Name = "aBMEmpleadosToolStripMenuItem";
            this.aBMEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.aBMEmpleadosToolStripMenuItem.Text = "ABMEmpleados";
            this.aBMEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.aBMEmpleadosToolStripMenuItem_Click);
            // 
            // aBMCompañíasToolStripMenuItem
            // 
            this.aBMCompañíasToolStripMenuItem.Name = "aBMCompañíasToolStripMenuItem";
            this.aBMCompañíasToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.aBMCompañíasToolStripMenuItem.Text = "ABMCompañías";
            this.aBMCompañíasToolStripMenuItem.Click += new System.EventHandler(this.aBMCompañíasToolStripMenuItem_Click);
            // 
            // aBMTerminalesToolStripMenuItem
            // 
            this.aBMTerminalesToolStripMenuItem.Name = "aBMTerminalesToolStripMenuItem";
            this.aBMTerminalesToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.aBMTerminalesToolStripMenuItem.Text = "ABMTerminales";
            this.aBMTerminalesToolStripMenuItem.Click += new System.EventHandler(this.aBMTerminalesToolStripMenuItem_Click);
            // 
            // viajesToolStripMenuItem
            // 
            this.viajesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.internacionalesToolStripMenuItem,
            this.nacionalesToolStripMenuItem});
            this.viajesToolStripMenuItem.Name = "viajesToolStripMenuItem";
            this.viajesToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.viajesToolStripMenuItem.Text = "Viajes";
            // 
            // internacionalesToolStripMenuItem
            // 
            this.internacionalesToolStripMenuItem.Name = "internacionalesToolStripMenuItem";
            this.internacionalesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.internacionalesToolStripMenuItem.Text = "Internacionales";
            this.internacionalesToolStripMenuItem.Click += new System.EventHandler(this.internacionalesToolStripMenuItem_Click);
            // 
            // nacionalesToolStripMenuItem
            // 
            this.nacionalesToolStripMenuItem.Name = "nacionalesToolStripMenuItem";
            this.nacionalesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.nacionalesToolStripMenuItem.Text = "Nacionales";
            this.nacionalesToolStripMenuItem.Click += new System.EventHandler(this.nacionalesToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblError});
            this.statusStrip1.Location = new System.Drawing.Point(0, 53);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(514, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.estadisticasToolStripMenuItem.Text = "Estadisticas";
            this.estadisticasToolStripMenuItem.Click += new System.EventHandler(this.estadisticasToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 75);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aBMEmpleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMCompañíasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMTerminalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viajesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internacionalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nacionalesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblError;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
    }
}