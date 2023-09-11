using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class CD_CargarLista
    {
        private SQLiteDataAdapter da;
        private DataTable dt;
        public DataTable Consultar(string filas, string tabla)
        {
            try
            {
                string consulta = $"SELECT {filas} FROM {tabla}";
                Conexion.Conectar();
                da = new SQLiteDataAdapter(consulta, Conexion.con);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        public DataTable ConsultarProveedor()
        {
            return Consultar("idProveedor, nombre_proveedor", "proveedor");
        }
        public DataTable ConsultarCategoria()
        {
            return Consultar("idCategoria, nombre_categoria", "categoria");
        }
        public DataTable ConsultarMarca()
        {
            return Consultar("idMarca, nombre_marca", "marca");
        }
    }
}