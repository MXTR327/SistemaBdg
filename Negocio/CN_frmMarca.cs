using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CN_frmMarca
    {
        CD_frmMarca cd_frmmarca = new CD_frmMarca();

        public string nombre_marca { get; set; }
        public CN_frmMarca()
        {

        }
        public CN_frmMarca(string nombre_marca)
        {
            this.nombre_marca = nombre_marca;
        }

        
        public bool SubirMarca()
        {
            bool rpta = false;

            string[] datos_columnas = { this.nombre_marca };
            bool verificar = cd_frmmarca.VerSiNoExisteMarca(this.nombre_marca);
            if (!verificar)
            {
                rpta = false;
            }
            else
            {
                rpta = cd_frmmarca.AgregarMarcaDB(datos_columnas);
            }
            return rpta;
        }
    }
}
