using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Presentacion
{
    public partial class VentanaProductos : Form
    {
        CN_CargarLista cn_listaproveedor = new CN_CargarLista();

        CN_VentanaProductos cn_ventanaproductos = new CN_VentanaProductos();
        private string direccion_proveedor_original;
        private string numero_proveedor_original;

        private string descripcion_categoria_original;
        private string nombre_marca_original;

        string filtroProductos;
        string filtroProveedor;
        string filtroCategoria;
        string filtroMarca;

        public VentanaProductos() { InitializeComponent(); }
        private bool EsCaracterValido(char inputChar, string inputText)
        {
            if (inputChar == '\b')
            {
                return false;
            }
            if (!char.IsDigit(inputChar) && (inputChar != ',' || inputText.Length == 0))
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

        //--ACTUALIZAR AL SUBIR DESDE EL FORMULARIO PRODUCTO---------------------------------------------------------
        public void ActualizarAlSubirProducto()
        {
            CargarProducto();
            dgvProducto.ClearSelection();
        }
        //--ACTUALIZAR AL SUBIR DESDE EL FORMULARIO PROVEEDOR---------------------------------------------------------
        public void ActualizarAlSubirProveedor()
        {
            CargarProveedor();
            dgvProveedor.ClearSelection();

            CargarlistaProveedor();
        }
        //--ACTUALIZAR AL SUBIR DESDE EL FORMULARIO CATEGORIA---------------------------------------------------------
        public void ActualizarAlSubirCategoria()
        {
            CargarCategoria();
            dgvCategoria.ClearSelection();

            CargarlistaCategoria();
        }
        //--ACTUALIZAR AL SUBIR DESDE EL FORMULARIO MARCA---------------------------------------------------------
        public void ActualizarAlSubirMarca()
        {
            CargarMarca();
            dgvMarca.ClearSelection();

            CargarlistaMarca();
        }
        
        //-- ENVIARLE ESTE FORMULARIO PARA QUE ACCEDA A LOS METODOS-----------------------------------------------------
        private void btnAgregarProductoUnidad_Click(object sender, EventArgs e)
        {
            frmProducto frmProducto = new frmProducto(this);
            frmProducto.ShowDialog();
        }
        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            frmProveedor frmProveedor = new frmProveedor(this);
            frmProveedor.ShowDialog();
        }
        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            frmCategoria frmcategoria = new frmCategoria(this);
            frmcategoria.ShowDialog();
        }
        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            frmMarca frmmarca = new frmMarca(this);
            frmmarca.ShowDialog();
        }
        //-------------------------------------------------------------

        public void VentanaProductos_Load(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------------------------
            filtroProductos = "";
            CargarProducto();
            filtroProveedor = "";
            CargarProveedor();
            filtroCategoria = "";
            CargarCategoria();
            filtroMarca = "";
            CargarMarca();
            //-------------------------------------------------------------------------------------------------------------
            CargarlistaProveedor();
            CargarlistaCategoria();
            CargarlistaMarca();
            //--------------------------------------------------------------------------------------------------------------
            if (dgvProducto.RowCount >0)
            {
                DataGridViewCellEventArgs cellClickArgs = new DataGridViewCellEventArgs(1, 0);
                dgvProductos_CellClick(dgvProducto, cellClickArgs);
            }
        }
        private void CargarComboBox(DataTable dt, System.Windows.Forms.ComboBox comboBox, string valueMember, string displayMember, string defaultValue, int selectedIndex)
        {
            int prevSelectedIndex = comboBox.SelectedIndex;

            DataRow filaCero = dt.NewRow();
            filaCero[valueMember] = 0;
            filaCero[displayMember] = defaultValue;
            dt.Rows.InsertAt(filaCero, 0);
            comboBox.DataSource = dt;
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;

            if (prevSelectedIndex >= 0 && prevSelectedIndex < comboBox.Items.Count)
            {
                comboBox.SelectedIndex = prevSelectedIndex;
            }
            else
            {
                comboBox.SelectedIndex = selectedIndex;
            }
        }
        private void CargarlistaProveedor()
        {
            DataTable dt = cn_listaproveedor.ListarProveedor();
            CargarComboBox(dt, cmbProveedor, "idProveedor", "nombre_proveedor", "Seleccionar proveedor", cmbProveedor.SelectedIndex);
        }
        private void CargarlistaCategoria()
        {
            DataTable dt = cn_listaproveedor.ListarCategoria();
            CargarComboBox(dt, cmbCategoria, "idCategoria", "nombre_categoria", "Seleccionar Categoria", cmbCategoria.SelectedIndex);
        }
        private void CargarlistaMarca()
        {
            DataTable dt = cn_listaproveedor.ListarMarca();
            CargarComboBox(dt, cmbMarca, "idMarca", "nombre_marca", "Seleccionar Marca", cmbMarca.SelectedIndex);
        }
        private void CargarMarca()
        {
            DataTable dt = cn_ventanaproductos.tblMarca(txtBuscadorMarca.Text);
            dgvMarca.DataSource = dt;
        }
        private void CargarCategoria()
        {
            DataTable dt = cn_ventanaproductos.tblCategoria(txtBuscadorCategoria.Text);
            dgvCategoria.DataSource = dt;
        }

        private void CargarProveedor()
        {
            DataTable dt = cn_ventanaproductos.tblProveedor(txtBuscadorProveedor.Text);
            dgvProveedor.DataSource = dt;
        }

        private void CargarProducto()
        {
            DataTable dt = cn_ventanaproductos.tblProducto(txtBuscadorProducto.Text);
            dgvProducto.DataSource = dt;
        }

        private void btnCerrarVetana_Click(object sender, EventArgs e){ Close(); }
        private void btnActualizarTablaProducto_Click(object sender, EventArgs e)
        {
            CargarProducto();
            if (dgvProducto.RowCount > 0)
            {
                DataGridViewCellEventArgs cellClickArgs = new DataGridViewCellEventArgs(1, 0);
                dgvProductos_CellClick(dgvProducto, cellClickArgs);
            }
        }
        private void btnActualizarTablaProveedor_Click(object sender, EventArgs e){ CargarProveedor(); }
        private void btnActualizarTablaCategoria_Click(object sender, EventArgs e){ CargarCategoria();  }
        private void btnActulizarTablaMarca_Click(object sender, EventArgs e){ CargarMarca(); }

        private void txtBuscadorProductos_TextChanged(object sender, EventArgs e)
        {
            filtroProductos = txtBuscadorProducto.Text;
            CargarProducto();
        }
        private void txtBuscadorProveedor_TextChanged(object sender, EventArgs e)
        {
            filtroProveedor = txtBuscadorProveedor.Text;
            CargarProveedor();
        }
        private void txtBuscadorCategoria_TextChanged(object sender, EventArgs e)
        {
            filtroCategoria = txtBuscadorCategoria.Text;
            CargarCategoria();
        }
        private void txtBuscadorMarca_TextChanged(object sender, EventArgs e)
        {
            filtroMarca = txtBuscadorMarca.Text;
            CargarMarca();
        }
        private void btnLmprBscProducto_Click(object sender, EventArgs e){ txtBuscadorProducto.Text = ""; txtBuscadorProducto.Focus(); }
        private void btnLmprBscProveedor_Click(object sender, EventArgs e){ txtBuscadorProveedor.Text = ""; txtBuscadorProveedor.Focus(); }
        private void btnLmprBscCategoria_Click(object sender, EventArgs e){ txtBuscadorCategoria.Text = ""; txtBuscadorCategoria.Focus(); }
        private void btnLmprBscMarca_Click(object sender, EventArgs e){ txtBuscadorMarca.Text = ""; txtBuscadorMarca.Focus(); }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dgvProducto.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                object valor_nombre_original = dgvProducto.Rows[e.RowIndex].Cells[1].Value;
                cn_ventanaproductos.nombre_producto_original = valor_nombre_original.ToString();

                string cellValue = dgvProducto.Rows[e.RowIndex].Cells[0].Value.ToString();
                cn_ventanaproductos.idProducto = cellValue;
                List<string> datos = cn_ventanaproductos.ObtenerDatosid();

                txtID.Text = datos[0];
                txtNombre.Text = datos[1];
                txtDescripcion.Text = datos[2];
                txtPC.Text = datos[3];
                txtPV.Text = datos[4];
                txtMedida.Text = datos[5];
                txtStock.Text = datos[6];

                int indexCategoria = cmbCategoria.FindStringExact(datos[7]);
                if (indexCategoria >= 0){ cmbCategoria.SelectedIndex = indexCategoria; }
                else{ cmbCategoria.SelectedIndex = 0; }

                int indexProveedor = cmbProveedor.FindStringExact(datos[8]);
                if (indexProveedor >= 0){ cmbProveedor.SelectedIndex = indexProveedor; }
                else{ cmbProveedor.SelectedIndex = 0; }

                int indexMarca = cmbMarca.FindStringExact(datos[9]);
                if (indexMarca >= 0){ cmbMarca.SelectedIndex = indexMarca; }
                else{ cmbMarca.SelectedIndex = 0; }
            }

            if (double.TryParse(txtPC.Text, out double precioCompra) &&
                double.TryParse(txtPV.Text, out double precioVenta) &&
                int.TryParse(txtStock.Text, out int stock))
            {
                txtGU.Text = (precioVenta - precioCompra).ToString("F2"); 

                txtGT.Text = ((precioVenta - precioCompra) * stock).ToString("F2");
            }
            else
            {
                txtGU.Text = "";
                txtGT.Text = "";
            }
        }
        private void btnBorrarProducto_Click(object sender, EventArgs e)
        {
            if (dgvProducto.Rows.Count == 0)
            {
                MessageBox.Show("No hay filas para borrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show($"Se borrara el siguiente producto: \nID: {txtID.Text} \nNombre: {txtNombre.Text} \n\n¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }
            int indexActual = dgvProducto.CurrentRow.Index;
            if (cn_ventanaproductos.borrarProducto())
            {
                CargarProducto();
                if (indexActual >= dgvProducto.Rows.Count)
                {
                    indexActual = dgvProducto.Rows.Count - 1;
                }
                if (dgvProducto.RowCount > 0)
                {
                    dgvProducto.CurrentCell = dgvProducto.Rows[indexActual].Cells[0];
                    dgvProductos_CellClick(dgvProducto, new DataGridViewCellEventArgs(0, indexActual));
                }
                else
                {
                    txtID.Text = "";
                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    cmbCategoria.SelectedIndex = 0;
                    cmbProveedor.SelectedIndex = 0;
                    cmbMarca.SelectedIndex = 0;
                    txtPC.Text = "";
                    txtPV.Text = "";
                    txtMedida.Text = "";
                    txtStock.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //------------------------------------------------------------------------------------------------------
        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //verifica que sea el HEADER
            if (e.RowIndex >= 0 && dgvProveedor.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                cn_ventanaproductos.idProveedor = dgvProveedor.Rows[e.RowIndex].Cells[0].Value.ToString();

                cn_ventanaproductos.nombre_proveedor_original = dgvProveedor.Rows[e.RowIndex].Cells[1].Value.ToString();

                direccion_proveedor_original = dgvProveedor.Rows[e.RowIndex].Cells[2].Value.ToString();

                numero_proveedor_original = dgvProveedor.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }
        private void btnBorrarProveedor_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.Rows.Count == 0)
            {
                MessageBox.Show("No hay filas para borrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show($"Se borrara la fila de proveedores ¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }
            if (cn_ventanaproductos.borrarProveedor())
            {
                CargarProveedor();
                dgvProveedor.ClearSelection();

                CargarProducto();
                if (dgvProducto.RowCount > 0)
                {
                    DataGridViewCellEventArgs cellClickArgs = new DataGridViewCellEventArgs(1, 0);
                    dgvProductos_CellClick(dgvProducto, cellClickArgs);
                }
                CargarlistaProveedor();
            }
            else
            {
                MessageBox.Show("Seleccione una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //verifica que sea el HEADER
            if (e.RowIndex >= 0 && dgvCategoria.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                cn_ventanaproductos.idCategoria = dgvCategoria.Rows[e.RowIndex].Cells[0].Value.ToString();

                cn_ventanaproductos.nombre_categoria_original = dgvCategoria.Rows[e.RowIndex].Cells[1].Value.ToString();

                descripcion_categoria_original = dgvCategoria.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }
        private void btnBorrarCategoria_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.Rows.Count == 0)
            {
                MessageBox.Show("No hay filas para borrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show($"Se borrara la fila de Categoria ¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }
            if (cn_ventanaproductos.borrarCategoria())
            {
                CargarCategoria();
                dgvCategoria.ClearSelection();

                CargarProducto();
                if (dgvProducto.RowCount > 0)
                {
                    DataGridViewCellEventArgs cellClickArgs = new DataGridViewCellEventArgs(1, 0);
                    dgvProductos_CellClick(dgvProducto, cellClickArgs);
                }
                CargarlistaCategoria();
            }
            else
            {
                MessageBox.Show("Seleccione una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //verifica que sea el HEADER
            if (e.RowIndex >= 0 && dgvMarca.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                cn_ventanaproductos.idMarca = dgvMarca.Rows[e.RowIndex].Cells[0].Value.ToString();

                nombre_marca_original = dgvMarca.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }
        private void btnBorrarMarca_Click(object sender, EventArgs e)
        {
            if (dgvMarca.Rows.Count == 0)
            {
                MessageBox.Show("No hay filas para borrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show("¿Desea borrar la fila de Marca?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }
            if (cn_ventanaproductos.borrarMarca())
            {
                CargarMarca();
                        
                dgvMarca.ClearSelection();

                CargarProducto();
                        
                if (dgvProducto.RowCount > 0)
                {
                    DataGridViewCellEventArgs cellClickArgs = new DataGridViewCellEventArgs(1, 0);
                    dgvProductos_CellClick(dgvProducto, cellClickArgs);
                }
                CargarlistaMarca();
            }
            else
            {
                MessageBox.Show("Seleccione una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >=32 && e.KeyChar <=47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }
        }
        private void txtPC_KeyPress(object sender, KeyPressEventArgs e)
        {
            string inputText = txtPC.Text;
            char inputChar = e.KeyChar;
            if (EsCaracterValido(inputChar, inputText)) { e.Handled = true; }
        }
        private void txtPV_KeyPress(object sender, KeyPressEventArgs e)
        {
            string inputText = txtPV.Text;
            char inputChar = e.KeyChar;
            if (EsCaracterValido(inputChar, inputText)) { e.Handled = true; }
        }
        private void txtPC_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPC.Text) && !string.IsNullOrEmpty(txtPV.Text))
            {
                if (double.TryParse(txtPC.Text, out double precioCompra) && double.TryParse(txtPV.Text, out double precioVenta))
                {
                    txtGU.Text = (precioVenta - precioCompra).ToString("F2");
                }
            }
            else
            {
                txtGU.Text = "";
            }
        }
        private void txtPV_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPC.Text) && !string.IsNullOrEmpty(txtPV.Text))
            {
                if (double.TryParse(txtPC.Text, out double precioCompra) && double.TryParse(txtPV.Text, out double precioVenta))
                {
                    txtGU.Text = (precioVenta - precioCompra).ToString("F2");
                }
            }
            else
            {
                txtGU.Text = "";
            }
        }
        private void txtGU_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGU.Text) && !string.IsNullOrEmpty(txtStock.Text))
            {
                if (int.TryParse(txtStock.Text, out int stock) && double.TryParse(txtGU.Text, out double gananciaUnidad))
                {
                    txtGT.Text = (gananciaUnidad * stock).ToString("F2");
                }
            }
            else
            {
                txtGT.Text = "";
            }
        }
        private void txtStock_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGU.Text) && !string.IsNullOrEmpty(txtStock.Text))
            {
                if (int.TryParse(txtStock.Text, out int stock) && double.TryParse(txtGU.Text, out double gananciaUnidad))
                {
                    txtGT.Text = (gananciaUnidad * stock).ToString("F2");
                }
            }
            else
            {
                txtGT.Text = "";
            }
        }
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
        private void btnActualizarProducto_Click(object sender, EventArgs e)
        {
            if(txtID.Text!="" && txtNombre.Text != "" &&  txtPC.Text!="" && txtPV.Text!="" && txtMedida.Text!="" && txtStock.Text!="")
            {
                cn_ventanaproductos.idProducto = txtID.Text;
                cn_ventanaproductos.nombre_producto = txtNombre.Text;
                cn_ventanaproductos.descripcion_producto = txtDescripcion.Text;
                cn_ventanaproductos.categoria_producto = cmbCategoria.SelectedValue.ToString();
                cn_ventanaproductos.proveedor_producto = cmbProveedor.SelectedValue.ToString();
                cn_ventanaproductos.marca_producto = cmbMarca.SelectedValue.ToString();
                cn_ventanaproductos.precio_compra = txtPC.Text;
                cn_ventanaproductos.precio_venta = txtPV.Text;
                cn_ventanaproductos.medida = txtMedida.Text;
                cn_ventanaproductos.stock = txtStock.Text;

                string respuesta = cn_ventanaproductos.ActualizarProducto();

                CargarProducto();
                if (dgvProducto.RowCount > 0)
                {
                    DataGridViewCellEventArgs cellClickArgs = new DataGridViewCellEventArgs(1, 0);
                    dgvProductos_CellClick(dgvProducto, cellClickArgs);
                }

                MessageBox.Show(respuesta, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No puede dejar campos obligatorios vacios", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtPC_Click(object sender, EventArgs e){ txtPC.SelectionStart = txtPC.Text.Length; txtPC.SelectionLength = 0; }
        private void txtPV_Click(object sender, EventArgs e){ txtPV.SelectionStart = txtPV.Text.Length; txtPV.SelectionLength = 0; }
        private void txtPC_KeyDown(object sender, KeyEventArgs e){ e.Handled = true; }
        private void txtPV_KeyDown(object sender, KeyEventArgs e){ e.Handled = true; }

        private void dgvProveedor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila_a_actualizar = dgvProveedor.Rows[e.RowIndex];

            string columna_nombre = fila_a_actualizar.Cells[1].Value.ToString();
            string columna_direccion = fila_a_actualizar.Cells[2].Value.ToString();
            string columna_numero = fila_a_actualizar.Cells[3].Value.ToString();

            switch (e.ColumnIndex)
            {
                case 1:
                    if (string.IsNullOrWhiteSpace(columna_nombre))
                    {
                        MessageBox.Show($"La columna nombre no puede estar vacía, no se aplicaron cambios");
                        fila_a_actualizar.Cells[1].Value = cn_ventanaproductos.nombre_proveedor_original;
                        return;
                    }
                    if (cn_ventanaproductos.nombre_proveedor_original == columna_nombre){ return; }
                    break;
                case 2:
                    if (direccion_proveedor_original == columna_direccion){ return; }
                    break;
                case 3:
                    if (numero_proveedor_original == columna_numero){ return; }
                    break;
                default:
                    break;
            }
            DialogResult result = MessageBox.Show("¿Desea actualizar la fila de Proveedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                fila_a_actualizar.Cells[1].Value = cn_ventanaproductos.nombre_proveedor_original;
                fila_a_actualizar.Cells[2].Value = direccion_proveedor_original;
                fila_a_actualizar.Cells[3].Value = numero_proveedor_original;
                return;
            }
            cn_ventanaproductos.nombre_proveedor = char.ToUpper(columna_nombre[0]) + columna_nombre.Substring(1);
            cn_ventanaproductos.direccion_proveedor = columna_direccion;
            cn_ventanaproductos.numero_proveedor = columna_numero;

            string respuesta = cn_ventanaproductos.ActualizarProveedor();

            if (respuesta == "El proveedor se actualizó correctamente")
            {
                CargarProducto();
                CargarlistaProveedor();
                if (dgvProducto.RowCount > 0)
                {
                    DataGridViewCellEventArgs cellClickArgs = new DataGridViewCellEventArgs(1, 0);
                    dgvProductos_CellClick(dgvProducto, cellClickArgs);
                }
            }

            MessageBox.Show(respuesta, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvProveedor_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvProveedor.CurrentCell.ColumnIndex == 3) 
            {
                System.Windows.Forms.TextBox textBox = e.Control as System.Windows.Forms.TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += NumericOnly_KeyPress;
                }
            }
        }
        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length >= 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void dgvCategoria_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila_a_actualizar = dgvCategoria.Rows[e.RowIndex];

            string columna_nombre = fila_a_actualizar.Cells[1].Value.ToString();
            string columna_descripcion = fila_a_actualizar.Cells[2].Value.ToString();

            switch (e.ColumnIndex)
            {
                case 1:
                    if (string.IsNullOrWhiteSpace(columna_nombre))
                    {
                        MessageBox.Show($"La columna nombre no puede estar vacía, no se aplicaron cambios");
                        fila_a_actualizar.Cells[1].Value = cn_ventanaproductos.nombre_categoria_original;
                        return;
                    }
                    if (cn_ventanaproductos.nombre_categoria_original == columna_nombre) { return; }
                    break;
                case 2:
                    if (descripcion_categoria_original == columna_descripcion) { return; }
                    break;
                default:
                    break;
            }
            DialogResult result = MessageBox.Show("¿Desea actualizar la fila de Categoria?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                fila_a_actualizar.Cells[1].Value = cn_ventanaproductos.nombre_categoria_original;
                fila_a_actualizar.Cells[2].Value = descripcion_categoria_original;
                return;
            }
            cn_ventanaproductos.nombre_categoria = char.ToUpper(columna_nombre[0]) + columna_nombre.Substring(1);
            cn_ventanaproductos.descripcion_categoria = columna_descripcion;

            string respuesta = cn_ventanaproductos.ActualizarCategoria();

            if (respuesta == "La categoria se actualizó correctamente")
            {
                CargarProducto();
                CargarlistaCategoria();
                if (dgvProducto.RowCount > 0)
                {
                    DataGridViewCellEventArgs cellClickArgs = new DataGridViewCellEventArgs(1, 0);
                    dgvProductos_CellClick(dgvProducto, cellClickArgs);
                }
            }
            MessageBox.Show(respuesta, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dgvMarca_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila_a_actualizar = dgvMarca.Rows[e.RowIndex];
            string columna_nombre = fila_a_actualizar.Cells[1].Value.ToString();

            switch (e.ColumnIndex)
            {
                case 1:
                    if (string.IsNullOrWhiteSpace(columna_nombre))
                    {
                        MessageBox.Show($"La columna nombre no puede estar vacía, no se aplicaron cambios");
                        fila_a_actualizar.Cells[1].Value = nombre_marca_original;
                        return;
                    }
                    if (nombre_marca_original == columna_nombre) { return; }
                    break;
                default:
                    break;
            }
            DialogResult result = MessageBox.Show("¿Desea actualizar la fila de Marca?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                fila_a_actualizar.Cells[1].Value = nombre_marca_original;
                return;

            }
            cn_ventanaproductos.nombre_marca = char.ToUpper(columna_nombre[0]) + columna_nombre.Substring(1);

            string respuesta = cn_ventanaproductos.ActualizarMarca();

            if(respuesta == "La marca se actualizó correctamente")
            {
                CargarProducto();
                CargarlistaMarca();
                if (dgvProducto.RowCount > 0)
                {
                    DataGridViewCellEventArgs cellClickArgs = new DataGridViewCellEventArgs(1, 0);
                    dgvProductos_CellClick(dgvProducto, cellClickArgs);
                }
            }
            MessageBox.Show(respuesta, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
