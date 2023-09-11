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
    public partial class frmMarca : Form
    {
        private VentanaProductos ventanaProducto;
        public frmMarca(VentanaProductos variableVentana)
        {
            InitializeComponent();
            this.ventanaProducto = variableVentana;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool rpta = false;
            if (string.IsNullOrWhiteSpace(txtNombreMarca.Text))
            {
                MessageBox.Show("No completó el campo obligatorio Nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreMarca.Focus();
                return;
            }
            string nombre_marca = txtNombreMarca.Text;

            CN_frmMarca Marca = new CN_frmMarca(nombre_marca);

            rpta = Marca.SubirMarca();
            if (rpta)
            {
                if (ventanaProducto != null)
                {
                    ventanaProducto.ActualizarAlSubirMarca();
                }
                MessageBox.Show("La marca se subió correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreMarca.Text = "";
                txtNombreMarca.Focus();
            }
            else
            {
                MessageBox.Show("Marca ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAgregar.PerformClick();
            }
        }
        private void txtNombreMarca_TextChanged(object sender, EventArgs e)
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
