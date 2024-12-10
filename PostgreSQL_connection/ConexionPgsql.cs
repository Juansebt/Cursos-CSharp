using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Npgsql; // Librería para conectarse a PostgreSQL

namespace PostgreSQL_connection
{
    internal class ConexionPgsql
    {
        // Variables de conexión
        static string host = "localhost";
        static int port = 5432;
        static string username = "postgres";
        static string password = "admin";
        static string dbName = "inventario";

        static string conexionString = $"Host={host};Port={port};Username={username};Password={password};Database={dbName};"; // Cadena de conexión para PostgreSQL
        NpgsqlConnection conexion = new NpgsqlConnection(conexionString); // Objeto de conexión para PostgreSQL

        public void conectarDataBase()
        {
            try
            {
                conexion.Open(); // Abrir la conexión
                MessageBox.Show("La conexión a la base de datos: " + conexion.Database + ", ha sido exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void desconectarDataBase()
        {
            try
            {
                conexion.Close(); // Cerrar la conexión
                MessageBox.Show("Se ha cerrado la conexión a la base de datos de forma correcta", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desconectar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
