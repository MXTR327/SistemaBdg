using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class CN_frmProveedor
    {
        CD_frmProveedor cd_frmproveedor= new CD_frmProveedor();
        public string nombre_proveedor { get; set; }
        public string direccion_proveedor { get; set; }
        public string numero_contacto { get; set; }
        public CN_frmProveedor()
        {
        }
        public CN_frmProveedor(string nombre_proveedor, string direccion_proveedor, string numero_contacto)
        {
            this.nombre_proveedor = nombre_proveedor;
            this.direccion_proveedor = direccion_proveedor;
            this.numero_contacto = numero_contacto;
        }
        public bool SubirProveedor()
        {
            bool rpta = false;
            string[] datos_columnas = { this.nombre_proveedor, this.direccion_proveedor, this.numero_contacto };

            bool verificar = cd_frmproveedor.VerSiNoExisteProveedor(this.nombre_proveedor);
            if (!verificar)
            {
                rpta = false;
            }
            else
            {
                rpta = cd_frmproveedor.AgregarProveedorDB(datos_columnas);
            }
            return rpta;
        }
    }
}
