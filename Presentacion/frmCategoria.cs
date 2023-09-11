using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmCategoria : Form
    {
        private VentanaProductos ventanaProducto;
        public frmCategoria(VentanaProductos variableVentana)
        {
            InitializeComponent();
            this.ventanaProducto = variableVentana;
        }
        private void chkDescripcion_CheckedChanged(object sender, EventArgs e){ txtDescripcion.Enabled = chkDescripcion.Checked; txtDescripcion.Text = chkDescripcion.Text; }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool rpta = false;
            if (string.IsNullOrWhiteSpace(txtNombreCategoria.Text))
            {
                MessageBox.Show("No completó el campo obligatorio Nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreCategoria.Focus();
                return;
            }

            string nombre_categoria = txtNombreCategoria.Text;
            string descripcion_categoria = txtDescripcion.Text;

            CN_frmCategoria cn_frmcategoria = new CN_frmCategoria(nombre_categoria, descripcion_categoria);

            rpta = cn_frmcategoria.SubirCategoria();
            if (rpta)
            {
                if (ventanaProducto != null)
                {
                    ventanaProducto.ActualizarAlSubirCategoria();
                }
                MessageBox.Show("La marca se subió correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreCategoria.Text = "";
                txtDescripcion.Text = "";
                txtNombreCategoria.Focus();
            }
            else
            {
                MessageBox.Show("La marca ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAgregar.PerformClick();
            }
        }
        private void txtNombreCategoria_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                string newText = char.ToUpper(textBox.Text[0]) + textBox.Text.Substring(1).ToLower();
                textBox.Text = newText;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
    }
}
