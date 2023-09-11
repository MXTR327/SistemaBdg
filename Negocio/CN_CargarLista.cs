using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class CN_CargarLista
    {
        CD_CargarLista cd_listaproveedor= new CD_CargarLista();
        public DataTable ListarProveedor()
        {
            DataTable dt = new DataTable();
            dt = cd_listaproveedor.ConsultarProveedor();
            return dt;
        }
        public DataTable ListarCategoria()
        {
            DataTable dt = new DataTable();
            dt = cd_listaproveedor.ConsultarCategoria();
            return dt;
        }
        public DataTable ListarMarca()
        {
            DataTable dt = new DataTable();
            dt = cd_listaproveedor.ConsultarMarca();
            return dt;
        }
    }
}
