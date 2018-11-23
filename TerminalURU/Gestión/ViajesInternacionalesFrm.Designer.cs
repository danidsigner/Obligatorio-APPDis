namespace Gestión
{
    partial class ViajesInternacionalesFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViajesInternacionalesFrm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.btnModificar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDocumentacion = new System.Windows.Forms.RichTextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtCantAsientos = new System.Windows.Forms.TextBox();
            this.cbTerminal = new System.Windows.Forms.ComboBox();
            this.cbCompañia = new System.Windows.Forms.ComboBox();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.dtpPartida = new System.Windows.Forms.DateTimePicker();
            this.dtpArribo = new System.Windows.Forms.DateTimePicker();
            this.cbServAbordo = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregar,
            this.btnModificar,
            this.btnEliminar,
            this.btnCancelar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(325, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAgregar
            // 
            this.btnAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(23, 22);
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(23, 22);
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(23, 22);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(23, 22);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblError});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(325, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad de Asientos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Partida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Arribo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Empleado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Terminal";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Compañía";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 435);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Documentación";
            // 
            // txtDocumentacion
            // 
            this.txtDocumentacion.Location = new System.Drawing.Point(16, 460);
            this.txtDocumentacion.MaximumSize = new System.Drawing.Size(250, 250);
            this.txtDocumentacion.MaxLength = 250;
            this.txtDocumentacion.Name = "txtDocumentacion";
            this.txtDocumentacion.Size = new System.Drawing.Size(250, 75);
            this.txtDocumentacion.TabIndex = 8;
            this.txtDocumentacion.Text = "";
            this.txtDocumentacion.Validating += new System.ComponentModel.CancelEventHandler(this.txtDocumentacion_Validating);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(144, 50);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 0;
            this.txtNumero.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumero_Validating);
            // 
            // txtCantAsientos
            // 
            this.txtCantAsientos.Location = new System.Drawing.Point(144, 88);
            this.txtCantAsientos.Name = "txtCantAsientos";
            this.txtCantAsientos.Size = new System.Drawing.Size(100, 20);
            this.txtCantAsientos.TabIndex = 1;
            this.txtCantAsientos.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantAsientos_Validating);
            // 
            // cbTerminal
            // 
            this.cbTerminal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTerminal.FormattingEnabled = true;
            this.cbTerminal.Location = new System.Drawing.Point(91, 309);
            this.cbTerminal.Name = "cbTerminal";
            this.cbTerminal.Size = new System.Drawing.Size(121, 21);
            this.cbTerminal.TabIndex = 4;
            this.cbTerminal.Validating += new System.ComponentModel.CancelEventHandler(this.cbTerminal_Validating);
            // 
            // cbCompañia
            // 
            this.cbCompañia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompañia.FormattingEnabled = true;
            this.cbCompañia.Location = new System.Drawing.Point(91, 345);
            this.cbCompañia.Name = "cbCompañia";
            this.cbCompañia.Size = new System.Drawing.Size(121, 21);
            this.cbCompañia.TabIndex = 5;
            this.cbCompañia.Validating += new System.ComponentModel.CancelEventHandler(this.cbCompañia_Validating);
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Enabled = false;
            this.txtEmpleado.Location = new System.Drawing.Point(91, 272);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(121, 20);
            this.txtEmpleado.TabIndex = 11;
            // 
            // dtpPartida
            // 
            this.dtpPartida.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpPartida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPartida.Location = new System.Drawing.Point(21, 165);
            this.dtpPartida.Name = "dtpPartida";
            this.dtpPartida.Size = new System.Drawing.Size(200, 20);
            this.dtpPartida.TabIndex = 2;
            // 
            // dtpArribo
            // 
            this.dtpArribo.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpArribo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpArribo.Location = new System.Drawing.Point(21, 232);
            this.dtpArribo.Name = "dtpArribo";
            this.dtpArribo.Size = new System.Drawing.Size(200, 20);
            this.dtpArribo.TabIndex = 3;
            // 
            // cbServAbordo
            // 
            this.cbServAbordo.AutoSize = true;
            this.cbServAbordo.Location = new System.Drawing.Point(21, 402);
            this.cbServAbordo.Name = "cbServAbordo";
            this.cbServAbordo.Size = new System.Drawing.Size(101, 17);
            this.cbServAbordo.TabIndex = 6;
            this.cbServAbordo.Text = "Servicio Abordo";
            this.cbServAbordo.UseVisualStyleBackColor = true;
            // 
            // ViajesInternacionalesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(325, 566);
            this.Controls.Add(this.cbServAbordo);
            this.Controls.Add(this.dtpArribo);
            this.Controls.Add(this.dtpPartida);
            this.Controls.Add(this.txtEmpleado);
            this.Controls.Add(this.cbCompañia);
            this.Controls.Add(this.cbTerminal);
            this.Controls.Add(this.txtCantAsientos);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtDocumentacion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ViajesInternacionalesFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViajesInternacionales";
            this.Load += new System.EventHandler(this.ViajesInternacionales_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private System.Windows.Forms.ToolStripButton btnModificar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblError;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtDocumentacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtCantAsientos;
        private System.Windows.Forms.ComboBox cbCompañia;
        private System.Windows.Forms.ComboBox cbTerminal;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.DateTimePicker dtpArribo;
        private System.Windows.Forms.DateTimePicker dtpPartida;
        private System.Windows.Forms.CheckBox cbServAbordo;
    }
}