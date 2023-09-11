using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class frmProveedor : Form
    {
        private VentanaProductos ventanaProducto;
        public frmProveedor(VentanaProductos variableVentana) 
        { 
            InitializeComponent();
            this.ventanaProducto = variableVentana;
        }
        CN_frmProveedor cn_frmproveedor = new CN_frmProveedor();
        
        //--CHECKBOX DIRECCION--
        private void chkDireccion_CheckedChanged(object sender, EventArgs e){ txtDireccion.Enabled = chkDireccion.Checked; txtDireccion.Text = chkDireccion.Text; }
        //--CHECKBOX NUMERO--
        private void chkNumero_CheckedChanged(object sender, EventArgs e){ txtNumeroContacto.Enabled = chkNumero.Checked; txtNumeroContacto.Text = chkDireccion.Text; }
        //--CONTROLADOR NUMERO CONTACTO--
        private void txtNumeroContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        //--BOTON AGREGAR--
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool rpta = false;
            if (string.IsNullOrWhiteSpace(txtNombreProveedor.Text))
            {
                MessageBox.Show("No completó el campo obligatorio Nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreProveedor.Focus();
                return; 
            }
            string nombre_proveedor = txtNombreProveedor.Text;
            string direccion_proveedor = txtDireccion.Text;
            string numero_contacto = txtNumeroContacto.Text;

            CN_frmProveedor proveedor = new CN_frmProveedor(nombre_proveedor, direccion_proveedor, numero_contacto);

            rpta = proveedor.SubirProveedor();

            if (rpta)
            {
                if (ventanaProducto != null)
                {
                    ventanaProducto.ActualizarAlSubirProveedor();
                }
                MessageBox.Show("El proveedor se subió correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreProveedor.Text = "";
                txtDireccion.Text = "";
                txtNumeroContacto.Text = "";
                txtNombreProveedor.Focus();
            }
            else
            {
                MessageBox.Show("El proveedor ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //--BOTON SALIR--
        private void btnSalir_Click(object sender, EventArgs e) { Close(); }
        //--SUBIR AL PRESIONAR ENTER
        private void frmProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAgregar.PerformClick();
            }
        }

        private void txtNombreProveedor_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                // Convierte la primera letra en mayúscula y el resto en minúscula
                string newText = char.ToUpper(textBox.Text[0]) + textBox.Text.Substring(1).ToLower();
                // Actualiza el texto en el TextBox
                textBox.Text = newText;
                // Mueve el cursor al final del texto
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
    }
}
