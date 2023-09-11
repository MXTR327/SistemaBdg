using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;

namespace Datos
{
    public class CD_frmProductos
    {
        private SQLiteCommand cmd;
        public bool VerSiNoExisteProducto(string texto_entrada)
        {
            bool Noexiste = true;
            try
            {
                Conexion.Conectar();

                string sql = "SELECT COUNT(*) FROM producto WHERE nombre_producto = @textoEntrada";
                cmd = new SQLiteCommand(sql, Conexion.con);
                cmd.Parameters.AddWithValue("@textoEntrada", texto_entrada.Trim());
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0) { Noexiste = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return Noexiste;
        }
        public bool SubirProductoDB(string[] datos_columnas)
        {
            bool rpta = false;
            try
            {
                Conexion.Conectar();

                string sql = "INSERT INTO producto (nombre_producto, descripcion, precio_compra, precio_venta, medida, stock, Categoria_idCategoria, Proveedor_idProveedor, marca_idMarca) " +
                                 "VALUES (@nombre, @descripcion, @precio_compra, @precio_venta, @medida, @stock, @Categoria_idCategoria, @Proveedor_idProveedor, @marca_idMarca)";

                cmd = new SQLiteCommand(sql, Conexion.con);
                cmd.Parameters.AddWithValue("@nombre", datos_columnas[0]);
                cmd.Parameters.AddWithValue("@descripcion", datos_columnas[1]);
                cmd.Parameters.AddWithValue("@precio_compra", datos_columnas[2]);
                cmd.Parameters.AddWithValue("@precio_venta", datos_columnas[3]);
                cmd.Parameters.AddWithValue("@medida", datos_columnas[4]);
                cmd.Parameters.AddWithValue("@stock", datos_columnas[5]);
                cmd.Parameters.AddWithValue("@Categoria_idCategoria", datos_columnas[6]);
                cmd.Parameters.AddWithValue("@Proveedor_idProveedor", datos_columnas[7]);
                cmd.Parameters.AddWithValue("@marca_idMarca", datos_columnas[8]);
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return rpta;
        }
    }
}
