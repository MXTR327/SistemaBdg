using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Datos
{
    public class CD_VentanaProductos
    {

        public DataTable dt;

        public SQLiteDataAdapter da;
        
        public DataTable ConseguirTabla(string consulta)
        {
            try
            {
                string consultasql = consulta;
                Conexion.Conectar();
                da = new SQLiteDataAdapter(consultasql, Conexion.con);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return dt;
        }
        public DataTable tablaProductos(string filtro)
        {
            return ConseguirTabla($"SELECT idProducto,nombre_producto,precio_compra,precio_venta,stock, nombre_categoria FROM producto p LEFT JOIN categoria c ON p.Categoria_idCategoria = c.idCategoria WHERE nombre_producto like '%{filtro}%'");
        }
        public DataTable tablaProveedor(string filtro)
        {
            return ConseguirTabla($"SELECT idProveedor,nombre_proveedor,direccion_proveedor,numero_contacto FROM proveedor WHERE nombre_proveedor like '%{filtro}%'");
        }
        public DataTable tablaCategoria(string filtro)
        {
            return ConseguirTabla($"SELECT idCategoria,nombre_categoria,descripcion FROM categoria WHERE nombre_categoria like '%{filtro}%'");
        }
        public DataTable tablaMarca(string filtro)
        {
            return ConseguirTabla($"SELECT idMarca,nombre_marca FROM marca WHERE nombre_marca like '%{filtro}%'");
        }
        public List<string> DatosFila(string numero_id)
        {
            List<string> valores = new List<string>();
            string sql = $@"SELECT p.idProducto, p.nombre_producto,p.descripcion,p.precio_compra,p.precio_venta,p.medida,p.stock,c.nombre_categoria,pr.nombre_proveedor,
                            m.nombre_marca FROM producto p LEFT JOIN categoria c ON p.Categoria_idCategoria = c.idCategoria
                            LEFT JOIN proveedor pr ON p.Proveedor_idProveedor = pr.idProveedor LEFT JOIN marca m ON p.marca_idMarca = m.idMarca WHERE p.idProducto = '{numero_id}';";

            Conexion.Conectar();
            SQLiteCommand command = new SQLiteCommand(sql, Conexion.con);
            SQLiteDataReader reader = command.ExecuteReader();
                    
            if (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valores.Add(reader[i].ToString());
                }
            }
            return valores;
        }
        public List<string> ObtenerNombresParaLista(String fila, String tabla)
        {
            List<string> nombresProveedores = new List<string>();
            string query = $"SELECT {fila} FROM {tabla}";

            Conexion.Conectar();

            SQLiteCommand cmd = new SQLiteCommand(query, Conexion.con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nombresProveedores.Add(reader[fila].ToString());
            }
            return nombresProveedores;
        }
        public List<string> NombresProveedores()
        {
            return ObtenerNombresParaLista("nombre_proveedor", "proveedor");
        }
        public List<string> NombresCategoria()
        {
            return ObtenerNombresParaLista("nombre_categoria", "categoria");
        }
        public List<string> NombresMarca()
        {
            return ObtenerNombresParaLista("nombre_marca", "marca");
        }
        public bool BorrarFilaDB(string tabla, string NombrefilaID, string id_a_borrar)
        {
            try
            {
                Conexion.Conectar();

                string sql = $"DELETE FROM {tabla} WHERE {NombrefilaID} = @id_a_borrar";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.con))
                {
                    cmd.Parameters.AddWithValue("@id_a_borrar", id_a_borrar);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool BorrarProductoDB(string id_a_borrar)
        {
            return BorrarFilaDB("producto","idProducto",id_a_borrar);
        }
        public bool BorrarProveedorDB(string id_a_borrar)
        {
            return BorrarFilaDB("proveedor", "idProveedor", id_a_borrar);
        }
        public bool BorrarCategoriaDB(string id_a_borrar)
        {
            return BorrarFilaDB("categoria", "idCategoria", id_a_borrar);
        }
        public bool BorrarMarcaDB(string id_a_borrar)
        {
            return BorrarFilaDB("marca", "idMarca", id_a_borrar);
        }

        public bool VerSiNoExisteProducto(string texto_entrada)
        {
            bool Noexiste = true;
            try
            {
                Conexion.Conectar();
                string sql = "SELECT COUNT(*) FROM producto WHERE nombre_producto = @textoEntrada";

                SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.con);

                cmd.Parameters.AddWithValue("@textoEntrada", texto_entrada.Trim());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    Noexiste = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return Noexiste;
        }
        public bool ActualizarProductoDB(string[] datos_columnas)
        {
            try
            {
                Conexion.Conectar();

                String sql = "UPDATE producto SET nombre_producto = @nombre, descripcion = @descripcion, precio_compra = @precio_compra, " +
                             "precio_venta = @precio_venta, medida = @medida, stock = @stock, Categoria_idCategoria = @Categoria_idCategoria, " +
                             "Proveedor_idProveedor = @Proveedor_idProveedor, marca_idMarca = @marca_idMarca " +
                             "WHERE idProducto = @idProducto"; // Reemplaza idProducto con el nombre de tu columna de clave primaria

                SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.con);

                cmd.Parameters.AddWithValue("@idProducto", datos_columnas[0]); // Reemplaza con el valor de la clave primaria del registro que deseas actualizar
                cmd.Parameters.AddWithValue("@nombre", datos_columnas[1]);
                cmd.Parameters.AddWithValue("@descripcion", datos_columnas[2]);
                cmd.Parameters.AddWithValue("@precio_compra", datos_columnas[3]);
                cmd.Parameters.AddWithValue("@precio_venta", datos_columnas[4]);
                cmd.Parameters.AddWithValue("@medida", datos_columnas[5]);
                cmd.Parameters.AddWithValue("@stock", datos_columnas[6]);
                cmd.Parameters.AddWithValue("@Categoria_idCategoria", datos_columnas[7]);
                cmd.Parameters.AddWithValue("@Proveedor_idProveedor", datos_columnas[8]);
                cmd.Parameters.AddWithValue("@marca_idMarca", datos_columnas[9]);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool ActualizarProveedorDB(string[] datos_columnas)
        {
            try
            {
                Conexion.Conectar();

                String sql = "UPDATE proveedor SET nombre_proveedor = @nombre, direccion_proveedor = @direccion, numero_contacto = @numero WHERE idProveedor = @idProveedor"; 

                SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.con);

                cmd.Parameters.AddWithValue("@idProveedor", datos_columnas[0]); 
                cmd.Parameters.AddWithValue("@nombre", datos_columnas[1]);
                cmd.Parameters.AddWithValue("@direccion", datos_columnas[2]);
                cmd.Parameters.AddWithValue("@numero", datos_columnas[3]);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool VerSiNoExisteProveedor(string nombre_proveedor)
        {
            bool Noexiste = true;
            try
            {
                Conexion.Conectar();
                string sql = "SELECT COUNT(*) FROM proveedor WHERE nombre_proveedor = @textoEntrada";

                SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.con);

                cmd.Parameters.AddWithValue("@textoEntrada", nombre_proveedor.Trim());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    Noexiste = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return Noexiste;
        }

        public bool VerSiNoExisteCategoria(string nombre_categoria)
        {
            bool Noexiste = true;
            try
            {
                Conexion.Conectar();
                string sql = "SELECT COUNT(*) FROM categoria WHERE nombre_categoria = @textoEntrada";

                SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.con);

                cmd.Parameters.AddWithValue("@textoEntrada", nombre_categoria.Trim());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    Noexiste = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return Noexiste;
        }

        public bool ActualizarCategoriaDB(string[] datosCategoria)
        {
            try
            {
                Conexion.Conectar();

                String sql = "UPDATE categoria SET nombre_categoria = @nombre, descripcion = @descripcion WHERE idCategoria = @idCategoria";

                SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.con);

                cmd.Parameters.AddWithValue("@idCategoria", datosCategoria[0]);
                cmd.Parameters.AddWithValue("@nombre", datosCategoria[1]);
                cmd.Parameters.AddWithValue("@descripcion", datosCategoria[2]);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool VerSiNoExisteMarca(string nombre_marca)
        {
            bool Noexiste = true;
            try
            {
                Conexion.Conectar();
                string sql = "SELECT COUNT(*) FROM marca WHERE nombre_marca = @textoEntrada";

                SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.con);

                cmd.Parameters.AddWithValue("@textoEntrada", nombre_marca.Trim());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    Noexiste = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return Noexiste;
        }

        public bool ActualizarMarcaDB(string[] datosMarca)
        {
            try
            {
                Conexion.Conectar();

                String sql = "UPDATE marca SET nombre_marca = @nombre WHERE idMarca = @idMarca";

                SQLiteCommand cmd = new SQLiteCommand(sql, Conexion.con);

                cmd.Parameters.AddWithValue("@idMarca", datosMarca[0]);
                cmd.Parameters.AddWithValue("@nombre", datosMarca[1]);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}