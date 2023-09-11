using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class CD_frmMarca
    {
        private SQLiteCommand cmd;
        public bool VerSiNoExisteMarca(string nombre_marca)
        {
            bool Noexiste = true;
            try
            {
                Conexion.Conectar();
                string sql = "SELECT COUNT(*) FROM marca WHERE nombre_marca = @textoEntrada";

                cmd = new SQLiteCommand(sql, Conexion.con);

                cmd.Parameters.AddWithValue("@textoEntrada", nombre_marca.Trim());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0){ Noexiste = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return Noexiste;
        }
        public bool AgregarMarcaDB(string[] datos_columnas)
        {
            bool rpta = false;
            try
            {
                Conexion.Conectar();
                string sql = "INSERT INTO marca (nombre_marca) VALUES (@nombre)";
                cmd = new SQLiteCommand(sql, Conexion.con);
                cmd.Parameters.AddWithValue("@nombre", datos_columnas[0]);
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
