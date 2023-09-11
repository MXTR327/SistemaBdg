namespace Presentacion
{

    partial class frmProveedor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNumero = new System.Windows.Forms.CheckBox();
            this.chkDireccion = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroContacto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreProveedor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkNumero);
            this.groupBox1.Controls.Add(this.chkDireccion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNumeroContacto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNombreProveedor);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(737, 302);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // chkNumero
            // 
            this.chkNumero.AutoSize = true;
            this.chkNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNumero.Location = new System.Drawing.Point(267, 249);
            this.chkNumero.Name = "chkNumero";
            this.chkNumero.Size = new System.Drawing.Size(15, 14);
            this.chkNumero.TabIndex = 7;
            this.chkNumero.UseVisualStyleBackColor = true;
            this.chkNumero.CheckedChanged += new System.EventHandler(this.chkNumero_CheckedChanged);
            // 
            // chkDireccion
            // 
            this.chkDireccion.AutoSize = true;
            this.chkDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDireccion.Location = new System.Drawing.Point(267, 147);
            this.chkDireccion.Name = "chkDireccion";
            this.chkDireccion.Size = new System.Drawing.Size(15, 14);
            this.chkDireccion.TabIndex = 6;
            this.chkDireccion.UseVisualStyleBackColor = true;
            this.chkDireccion.CheckedChanged += new System.EventHandler(this.chkDireccion_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "Numero contacto";
            // 
            // txtNumeroContacto
            // 
            this.txtNumeroContacto.Enabled = false;
            this.txtNumeroContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroContacto.Location = new System.Drawing.Point(288, 235);
            this.txtNumeroContacto.MaxLength = 9;
            this.txtNumeroContacto.Name = "txtNumeroContacto";
            this.txtNumeroContacto.Size = new System.Drawing.Size(293, 38);
            this.txtNumeroContacto.TabIndex = 5;
            this.txtNumeroContacto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroContacto_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Agregar direccion";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(288, 138);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(443, 29);
            this.txtDireccion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre proveedor";
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreProveedor.Location = new System.Drawing.Point(288, 29);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(443, 38);
            this.txtNombreProveedor.TabIndex = 1;
            this.txtNombreProveedor.TextChanged += new System.EventHandler(this.txtNombreProveedor_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(217, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(355, 38);
            this.label5.TabIndex = 0;
            this.label5.Text = "Agregar Proveedor";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(158, 358);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(232, 41);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(396, 358);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(232, 41);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 410);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProveedor";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmProveedor_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroContacto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.CheckBox chkDireccion;
        private System.Windows.Forms.CheckBox chkNumero;
    }
}