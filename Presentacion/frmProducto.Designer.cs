namespace Presentacion
{
    partial class frmProducto
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.txtGananciaTotal = new System.Windows.Forms.TextBox();
            this.txtGananciaUnidad = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkDescripcion = new System.Windows.Forms.CheckBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.txtMedida = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cNfrmProductosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cNfrmProductosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Producto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbMarca);
            this.groupBox1.Controls.Add(this.cmbCategoria);
            this.groupBox1.Controls.Add(this.cmbProveedor);
            this.groupBox1.Controls.Add(this.txtGananciaTotal);
            this.groupBox1.Controls.Add(this.txtGananciaUnidad);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.chkDescripcion);
            this.groupBox1.Controls.Add(this.txtPrecioVenta);
            this.groupBox1.Controls.Add(this.txtPrecioCompra);
            this.groupBox1.Controls.Add(this.txtMedida);
            this.groupBox1.Controls.Add(this.txtStock);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 646);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.IntegralHeight = false;
            this.cmbMarca.ItemHeight = 24;
            this.cmbMarca.Items.AddRange(new object[] {
            "Seleccione marca"});
            this.cmbMarca.Location = new System.Drawing.Point(186, 230);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(243, 32);
            this.cmbMarca.TabIndex = 37;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.IntegralHeight = false;
            this.cmbCategoria.ItemHeight = 24;
            this.cmbCategoria.Items.AddRange(new object[] {
            "Seleccione categoria"});
            this.cmbCategoria.Location = new System.Drawing.Point(599, 161);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(233, 32);
            this.cmbCategoria.TabIndex = 36;
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.IntegralHeight = false;
            this.cmbProveedor.ItemHeight = 24;
            this.cmbProveedor.Items.AddRange(new object[] {
            "Seleccione Proveedor"});
            this.cmbProveedor.Location = new System.Drawing.Point(186, 161);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(243, 32);
            this.cmbProveedor.TabIndex = 35;
            // 
            // txtGananciaTotal
            // 
            this.txtGananciaTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGananciaTotal.Location = new System.Drawing.Point(281, 578);
            this.txtGananciaTotal.Name = "txtGananciaTotal";
            this.txtGananciaTotal.ReadOnly = true;
            this.txtGananciaTotal.Size = new System.Drawing.Size(194, 29);
            this.txtGananciaTotal.TabIndex = 22;
            // 
            // txtGananciaUnidad
            // 
            this.txtGananciaUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGananciaUnidad.Location = new System.Drawing.Point(281, 510);
            this.txtGananciaUnidad.Name = "txtGananciaUnidad";
            this.txtGananciaUnidad.ReadOnly = true;
            this.txtGananciaUnidad.Size = new System.Drawing.Size(194, 29);
            this.txtGananciaUnidad.TabIndex = 20;
            this.txtGananciaUnidad.TextChanged += new System.EventHandler(this.txtGananciaUnidad_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 575);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(212, 40);
            this.label12.TabIndex = 21;
            this.label12.Text = "Ganancia total";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 506);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(269, 40);
            this.label11.TabIndex = 19;
            this.label11.Text = "Ganancia x unidad";
            // 
            // chkDescripcion
            // 
            this.chkDescripcion.AutoSize = true;
            this.chkDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDescripcion.Location = new System.Drawing.Point(599, 97);
            this.chkDescripcion.Name = "chkDescripcion";
            this.chkDescripcion.Size = new System.Drawing.Size(227, 29);
            this.chkDescripcion.TabIndex = 4;
            this.chkDescripcion.Text = "Agregar Descripcion";
            this.chkDescripcion.UseVisualStyleBackColor = true;
            this.chkDescripcion.CheckedChanged += new System.EventHandler(this.chkDescripcion_CheckedChanged_1);
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioVenta.Location = new System.Drawing.Point(267, 442);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.ShortcutsEnabled = false;
            this.txtPrecioVenta.Size = new System.Drawing.Size(194, 29);
            this.txtPrecioVenta.TabIndex = 18;
            this.txtPrecioVenta.Click += new System.EventHandler(this.txtPrecioVenta_Click);
            this.txtPrecioVenta.TextChanged += new System.EventHandler(this.txtPrecioVenta_TextChanged);
            this.txtPrecioVenta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrecioVenta_KeyDown);
            this.txtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioVenta_KeyPress);
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioCompra.Location = new System.Drawing.Point(267, 374);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.ShortcutsEnabled = false;
            this.txtPrecioCompra.Size = new System.Drawing.Size(194, 29);
            this.txtPrecioCompra.TabIndex = 16;
            this.txtPrecioCompra.Click += new System.EventHandler(this.txtPrecioCompra_Click);
            this.txtPrecioCompra.TextChanged += new System.EventHandler(this.txtPrecioCompra_TextChanged);
            this.txtPrecioCompra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrecioCompra_KeyDown);
            this.txtPrecioCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioCompra_KeyPress);
            // 
            // txtMedida
            // 
            this.txtMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedida.Location = new System.Drawing.Point(599, 297);
            this.txtMedida.Name = "txtMedida";
            this.txtMedida.Size = new System.Drawing.Size(233, 29);
            this.txtMedida.TabIndex = 14;
            // 
            // txtStock
            // 
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(186, 306);
            this.txtStock.MaxLength = 5;
            this.txtStock.Name = "txtStock";
            this.txtStock.ShortcutsEnabled = false;
            this.txtStock.Size = new System.Drawing.Size(275, 29);
            this.txtStock.TabIndex = 12;
            this.txtStock.TextChanged += new System.EventHandler(this.txtStock_TextChanged);
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStock_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(186, 96);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(402, 29);
            this.txtDescripcion.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(186, 28);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(402, 29);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 299);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 40);
            this.label10.TabIndex = 11;
            this.label10.Text = "Stock";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(479, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 40);
            this.label9.TabIndex = 13;
            this.label9.Text = "Medida";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 40);
            this.label6.TabIndex = 9;
            this.label6.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(446, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 40);
            this.label3.TabIndex = 7;
            this.label3.Text = "Categoria";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 40);
            this.label8.TabIndex = 2;
            this.label8.Text = "Descripcion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 437);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 40);
            this.label7.TabIndex = 17;
            this.label7.Text = "Precio de venta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 40);
            this.label5.TabIndex = 15;
            this.label5.Text = "Precio de compra";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 40);
            this.label4.TabIndex = 5;
            this.label4.Text = "Proveedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 40);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(465, 702);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(156, 41);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(257, 702);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(156, 41);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cNfrmProductosBindingSource
            // 
            this.cNfrmProductosBindingSource.DataSource = typeof(Negocio.CN_frmProductos);
            // 
            // frmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 761);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(910, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(910, 800);
            this.Name = "frmProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario Productos";
            this.Load += new System.EventHandler(this.frmProducto_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmProducto_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cNfrmProductosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.TextBox txtMedida;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.CheckBox chkDescripcion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtGananciaTotal;
        private System.Windows.Forms.TextBox txtGananciaUnidad;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.BindingSource cNfrmProductosBindingSource;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbMarca;
    }
}

