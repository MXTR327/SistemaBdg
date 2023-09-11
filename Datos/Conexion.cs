using System;
using System.Data;
using System.Data.SQLite;


namespace Datos
{
    public class Conexion
    {
        // Ruta de la base de datos SQLite
        public static SQLiteConnection con = new SQLiteConnection("Data Source=BD_bodegaangelo.db;Version=3;");

        public static void Conectar()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public static void Desconectar()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
