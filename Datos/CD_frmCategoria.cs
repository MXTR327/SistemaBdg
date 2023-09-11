using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class CD_frmCategoria
    {
        private SQLiteCommand cmd;
        public bool VerSiNoExisteCategoria(string nombre_categoria)
        {
            bool Noexiste = true;
            try
            {
                Conexion.Conectar();
                string sql = "SELECT COUNT(*) FROM categoria WHERE nombre_categoria = @textoEntrada";
                cmd = new SQLiteCommand(sql, Conexion.con);
                cmd.Parameters.AddWithValue("@textoEntrada", nombre_categoria.Trim());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0){ Noexiste = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return Noexiste;
        }
        public bool AgregarCategoriaDB(string[] datos_columnas)
        {
            bool rpta = false;
            try
            {
                Conexion.Conectar();
                string sql = "INSERT INTO categoria (nombre_categoria, descripcion) VALUES (@nombre, @descripcion)";
                cmd = new SQLiteCommand(sql, Conexion.con);
                cmd.Parameters.AddWithValue("@nombre", datos_columnas[0]);
                cmd.Parameters.AddWithValue("@descripcion", datos_columnas[1]);
                int rowsAffected = cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return rpta;
        }
    }
}
