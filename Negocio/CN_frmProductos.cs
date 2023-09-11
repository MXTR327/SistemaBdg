using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class CN_frmProductos
    {
        CD_frmProductos cd_frmproductos = new CD_frmProductos();
        public string nombre_producto { get; set; }
        public string descripcion { get; set; }
        public string precio_compra { get; set; }
        public string precio_venta { get; set; }
        public string medida { get; set; }
        public string stock { get; set; }
        public string nombre_Categoria { get; set; }
        public string nombre_Proveedor { get; set; }
        public string nombre_Marca { get; set; }
        public CN_frmProductos()
        {
        }
        public CN_frmProductos(string nombre_producto, string descripcion, string precio_compra, string precio_venta, string medida, string stock, string nombre_Categoria, string nombre_Proveedor, string nombre_Marca)
        {
            this.nombre_producto = nombre_producto;
            this.descripcion = descripcion;
            this.precio_compra = precio_compra;
            this.precio_venta = precio_venta;
            this.medida = medida;
            this.stock = stock;
            this.nombre_Categoria = nombre_Categoria;
            this.nombre_Proveedor = nombre_Proveedor;
            this.nombre_Marca = nombre_Marca;
        }
        public bool SubirProducto()
        {
            bool rpta = false;
            try
            {
                string[] datos_columnas = { this.nombre_producto, this.descripcion, this.precio_compra, this.precio_venta, this.medida, this.stock, this.nombre_Categoria, this.nombre_Proveedor, this.nombre_Marca};
                bool verificar = cd_frmproductos.VerSiNoExisteProducto(this.nombre_producto);
                if (!verificar)
                {
                    rpta = false;
                }
                else
                {
                    rpta = cd_frmproductos.SubirProductoDB(datos_columnas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return rpta;
        }
    }
}
