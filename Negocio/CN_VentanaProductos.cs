using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CN_VentanaProductos
    {
        CD_VentanaProductos cd_ventanaproductos = new CD_VentanaProductos();
        public string idProducto { get; set; }

        public string nombre_producto_original { get; set; }
        public string nombre_producto { get; set; }
        public string descripcion_producto { get; set; }
        public string categoria_producto { get; set; }
        public string proveedor_producto { get; set; }
        public string marca_producto { get; set; }
        public string precio_compra {  get; set; }
        public string precio_venta {  get; set; }
        public string medida { get; set; }
        public string stock {  get; set; }
        public string ActualizarProducto()
        {
            string[] datosColumnas = { this.idProducto, this.nombre_producto, this.descripcion_producto, this.precio_compra, this.precio_venta, this.medida, this.stock, this.categoria_producto, this.proveedor_producto, this.marca_producto };

            if (this.nombre_producto_original != this.nombre_producto && !cd_ventanaproductos.VerSiNoExisteProducto(this.nombre_producto))
            {
                return "El producto ya existe";
            }

            bool actualizacionExitosa = cd_ventanaproductos.ActualizarProductoDB(datosColumnas);
            return actualizacionExitosa ? "El producto se actualizó correctamente" : "Ocurrió un error al intentar actualizar el producto";
        }

        public string idProveedor { get; set; }
        public string nombre_proveedor_original { get; set; }
        public string nombre_proveedor { get; set; }
        public string direccion_proveedor { get; set; }
        public string numero_proveedor { get; set; }
        public string ActualizarProveedor()
        {
            string[] datosProveedor = { this.idProveedor, this.nombre_proveedor, this.direccion_proveedor,this.numero_proveedor };

            if (this.nombre_proveedor_original != this.nombre_proveedor && !cd_ventanaproductos.VerSiNoExisteProveedor(this.nombre_proveedor))
            {
                return "El proveedor ya existe";
            }
            bool actualizacionExitosa = cd_ventanaproductos.ActualizarProveedorDB(datosProveedor);
            return actualizacionExitosa ? "El proveedor se actualizó correctamente" : "Ocurrió un error al intentar actualizar el proveedor";
        }
        public string idCategoria { get; set; }
        public string nombre_categoria_original { get; set; }
        public string nombre_categoria { get; set; }
        public string descripcion_categoria { get; set; }
        public string ActualizarCategoria()
        {
            string[] datosCategoria = { this.idCategoria, this.nombre_categoria, this.descripcion_categoria };

            if (this.nombre_categoria_original != this.nombre_categoria && !cd_ventanaproductos.VerSiNoExisteCategoria(this.nombre_categoria))
            {
                return "La categoria ya existe";
            }
            bool actualizacionExitosa = cd_ventanaproductos.ActualizarCategoriaDB(datosCategoria);
            return actualizacionExitosa ? "La categoria se actualizó correctamente" : "Ocurrió un error al intentar actualizar la categoria";
        }
        public string idMarca { get; set; }
        public string nombre_marca_original { get; set; }
        public string nombre_marca { get; set; }
        public string ActualizarMarca()
        {
            string[] datosMarca = { this.idMarca, this.nombre_marca };

            if (this.nombre_marca_original != this.nombre_marca && !cd_ventanaproductos.VerSiNoExisteMarca(this.nombre_marca))
            {
                return "La marca ya existe";
            }
            bool actualizacionExitosa = cd_ventanaproductos.ActualizarMarcaDB(datosMarca);
            return actualizacionExitosa ? "La marca se actualizó correctamente" : "Ocurrió un error al intentar actualizar la marca";
        }
        public string textoBuscadorProducto { get; set; }
        public string textoBuscadorProveedores { get; set; }
        public string textoBuscadorCategoria { get; set; }
        public string textoBuscadorMarca { get; set; }
        public bool borrarProducto()
        {
            return cd_ventanaproductos.BorrarProductoDB(this.idProducto);
        }
        public bool borrarProveedor()
        {
            return cd_ventanaproductos.BorrarProveedorDB(this.idProveedor);
        }
        public bool borrarCategoria()
        {
            return cd_ventanaproductos.BorrarCategoriaDB(this.idCategoria);
        }
        public bool borrarMarca()
        {
            return cd_ventanaproductos.BorrarMarcaDB(this.idMarca);
        }
        public List<string> ObtenerDatosid()
        {
            return cd_ventanaproductos.DatosFila(this.idProducto);
        }
        //------------------------------------------------------------------------------------------------------------------------------\\
        public DataTable tblProducto(string filtro)
        {
            DataTable dt = new DataTable();
            dt = cd_ventanaproductos.tablaProductos(filtro);
            return dt;
        }
        public DataTable tblProveedor(string filtro)
        {
            DataTable dt = new DataTable();
            dt = cd_ventanaproductos.tablaProveedor(filtro);
            return dt;
        }
        public DataTable tblCategoria(string filtro)
        {
            DataTable dt = new DataTable();
            dt = cd_ventanaproductos.tablaCategoria(filtro);
            return dt;
        }
        public DataTable tblMarca(string filtro)
        {
            DataTable dt = new DataTable();
            dt = cd_ventanaproductos.tablaMarca(filtro);
            return dt;
        }
    }
}
