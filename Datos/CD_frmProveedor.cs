using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Datos
{
    public class CD_frmProveedor
    {
        private SQLiteCommand cmd;
        public bool VerSiNoExisteProveedor(string nombre_proveedor)
        {
            bool Noexiste = true;
            try
            {
                Conexion.Conectar();
                string sql = "SELECT COUNT(*) FROM proveedor WHERE nombre_proveedor = @textoEntrada";
                cmd = new SQLiteCommand(sql, Conexion.con);
                cmd.Parameters.AddWithValue("@textoEntrada", nombre_proveedor.Trim());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0){ Noexiste = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return Noexiste;
        }
        public bool AgregarProveedorDB(string[] datos_columnas)
        {
            bool rpta = false;
            try
            {
                Conexion.Conectar();
                string sql = "INSERT INTO proveedor (nombre_proveedor, direccion_proveedor, numero_contacto) VALUES (@nombre, @direccion, @numero)";
                cmd = new SQLiteCommand(sql, Conexion.con);
                cmd.Parameters.AddWithValue("@nombre", datos_columnas[0]);
                cmd.Parameters.AddWithValue("@direccion", datos_columnas[1]);
                cmd.Parameters.AddWithValue("@numero", datos_columnas[2]);
                int rowsAffected = cmd.ExecuteNonQuery();
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
