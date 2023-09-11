using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion
{
    public partial class frmProducto : Form
    {
        CN_CargarLista cn_listaproveedor = new CN_CargarLista();

        private VentanaProductos ventanaProductos;
        public frmProducto(VentanaProductos variableVentanas)
        {
            InitializeComponent();
            this.ventanaProductos = variableVentanas;
        }
        private bool EsCaracterValido(char inputChar, string inputText)
        {
            if (!char.IsDigit(inputChar) && inputChar != '\b' && (inputChar != ',' || inputText.Length == 0))
            {
                return true;
            }
            else if (inputChar == ',')
            {
                if (inputText.Contains(",") || inputText.Length == 0 || inputText.StartsWith("0,"))
                {
                    return true;
                }
            }
            else if (inputText.Contains(","))
            {
                if (inputText.Split(',')[1].Length >= 2 && char.IsDigit(inputChar))
                {
                    return true;
                }
            }
            else if (inputText.StartsWith("0") && char.IsDigit(inputChar))
            {
                return true;
            }
            return false;
        }
        private void frmProducto_Load(object sender, EventArgs e)
        {
            CargarProveedor();
            CargarCategoria();
            CargarMarca();
        }
        private void CargarComboBox(DataTable dt, System.Windows.Forms.ComboBox comboBox, string valueMember, string displayMember, string defaultValue)
        {
            DataRow filaCero = dt.NewRow();
            filaCero[valueMember] = 0;
            filaCero[displayMember] = defaultValue;
            dt.Rows.InsertAt(filaCero, 0);
            comboBox.DataSource = dt;
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
        }
        private void CargarProveedor()
        {
            DataTable dt = cn_listaproveedor.ListarProveedor();
            CargarComboBox(dt, cmbProveedor, "idProveedor", "nombre_proveedor", "Seleccionar proveedor");
        }

        private void CargarCategoria()
        {
            DataTable dt = cn_listaproveedor.ListarCategoria();
            CargarComboBox(dt, cmbCategoria, "idCategoria", "nombre_categoria", "Seleccionar Categoria");
        }

        private void CargarMarca()
        {
            DataTable dt = cn_listaproveedor.ListarMarca();
            CargarComboBox(dt, cmbMarca, "idMarca", "nombre_marca", "Seleccionar Marca");
        }

        private void chkDescripcion_CheckedChanged_1(object sender, EventArgs e)
        {
            txtDescripcion.ReadOnly = !txtDescripcion.ReadOnly;
            txtDescripcion.Text = "";
        }
        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPrecioCompra.Text) && !string.IsNullOrEmpty(txtPrecioVenta.Text))
            {
                if (double.TryParse(txtPrecioCompra.Text, out double precioCompra) && double.TryParse(txtPrecioVenta.Text, out double precioVenta))
                {
                    double gananciaUnidad = precioVenta - precioCompra;
                    txtGananciaUnidad.Text = gananciaUnidad.ToString("F2");
                }
            }
            else
            {
                txtGananciaUnidad.Text = "";
            }
        }
        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPrecioCompra.Text) && !string.IsNullOrEmpty(txtPrecioVenta.Text))
            {
                if (double.TryParse(txtPrecioCompra.Text, out double precioCompra) && double.TryParse(txtPrecioVenta.Text, out double precioVenta))
                {
                    double gananciaUnidad = precioVenta - precioCompra;
                    txtGananciaUnidad.Text = gananciaUnidad.ToString("F2");
                }
            }
            else
            {
                txtGananciaUnidad.Text = "";
            }
        }
        private void txtGananciaUnidad_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGananciaUnidad.Text) && !string.IsNullOrEmpty(txtStock.Text))
            {
                if (int.TryParse(txtStock.Text, out int stock) && double.TryParse(txtGananciaUnidad.Text, out double gananciaUnidad))
                {
                    double gananciaTotal = gananciaUnidad * stock;
                    txtGananciaTotal.Text = gananciaTotal.ToString("F2");
                }
            }
            else
            {
                txtGananciaTotal.Text = "";
            }
        }
        private void txtStock_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGananciaUnidad.Text) && !string.IsNullOrEmpty(txtStock.Text))
            {
                if (int.TryParse(txtStock.Text, out int stock) && double.TryParse(txtGananciaUnidad.Text, out double gananciaUnidad))
                {
                    double gananciaTotal = gananciaUnidad * stock;
                    txtGananciaTotal.Text = gananciaTotal.ToString("F2");
                }
            }
            else
            {
                txtGananciaTotal.Text = "";
            }
        }
        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            string inputText = txtPrecioCompra.Text;
            char inputChar = e.KeyChar;
            if (EsCaracterValido(inputChar, inputText)) { e.Handled = true; }
        }
        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            string inputText = txtPrecioVenta.Text;
            char inputChar = e.KeyChar;
            if (EsCaracterValido(inputChar, inputText)) { e.Handled = true; }
        }
        private void txtPrecioCompra_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
        private void txtPrecioVenta_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool rpta = false;
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbProveedor.SelectedIndex == 0 || cmbCategoria.SelectedIndex == 0 || cmbMarca.SelectedIndex == 0 || string.IsNullOrWhiteSpace(txtStock.Text) || string.IsNullOrWhiteSpace(txtMedida.Text) || string.IsNullOrWhiteSpace(txtPrecioCompra.Text) || string.IsNullOrWhiteSpace(txtPrecioVenta.Text))
            {
                MessageBox.Show("No completó todos los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nombre_producto = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            string precio_compra = txtPrecioCompra.Text;
            string precio_venta = txtPrecioVenta.Text;
            string medida = txtMedida.Text;
            string stock = txtStock.Text;
            string nombre_Categoria = cmbCategoria.SelectedValue.ToString();
            string nombre_Proveedor = cmbProveedor.SelectedValue.ToString();
            string nombre_Marca = cmbMarca.SelectedValue.ToString();
            CN_frmProductos productos = new CN_frmProductos(nombre_producto, descripcion, precio_compra, precio_venta, medida, stock, nombre_Categoria, nombre_Proveedor, nombre_Marca);

            rpta = productos.SubirProducto();
            if (rpta)
            {
                if (ventanaProductos != null)
                {
                    ventanaProductos.ActualizarAlSubirProducto();
                }
                MessageBox.Show("El producto se subió correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                cmbProveedor.SelectedIndex = 0;
                cmbCategoria.SelectedIndex = 0;
                cmbMarca.SelectedIndex = 0;
                txtStock.Text = "";
                txtMedida.Text = "";
                txtPrecioCompra.Text = "";
                txtPrecioVenta.Text = "";
                txtNombre.Focus();
            }
            else
            {
                MessageBox.Show("El producto ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------\\
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                string newText = char.ToUpper(textBox.Text[0]) + textBox.Text.Substring(1).ToLower();
                textBox.Text = newText;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
        private void txtPrecioCompra_Click(object sender, EventArgs e)
        {
            txtPrecioCompra.SelectionStart = txtPrecioCompra.Text.Length;
            txtPrecioCompra.SelectionLength = 0;
        }

        private void txtPrecioVenta_Click(object sender, EventArgs e)
        {
            txtPrecioVenta.SelectionStart = txtPrecioVenta.Text.Length;
            txtPrecioVenta.SelectionLength = 0;
        }
        private void frmProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAgregar.PerformClick();
            }
        }
    }
}
