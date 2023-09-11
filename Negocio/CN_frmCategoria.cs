using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CN_frmCategoria
    {
        CD_frmCategoria cd_frmcategoria = new CD_frmCategoria();
        public string nombre_categoria { get; set; }
        public string descripcion_categoria { get; set; }
        public CN_frmCategoria()
        {
        }
        public CN_frmCategoria(string nombre_categoria, string descripcion_categoria)
        {
            this.nombre_categoria = nombre_categoria;
            this.descripcion_categoria = descripcion_categoria;
        }
        public bool SubirCategoria()
        {
            bool rpta = false;

            string[] datos_columnas = { this.nombre_categoria, this.descripcion_categoria };
            bool verificar = cd_frmcategoria.VerSiNoExisteCategoria(this.nombre_categoria);
            if (!verificar)
            {
                rpta = false;
            }
            else
            {
                rpta = cd_frmcategoria.AgregarCategoriaDB(datos_columnas);
            }
            return rpta;
        }
    }
}
