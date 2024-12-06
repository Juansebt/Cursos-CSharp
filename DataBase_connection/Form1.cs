using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient; //Libreria para conectarnos a base de datos - SQL Server
using MySql.Data.MySqlClient; //Librería para conectarse a MySQL
using Npgsql; // Librería para conectarse a PostgreSQL

namespace DataBase_connection
{
    public partial class Form1 : Form
    {
        /*
         * Conexión con SQL Server
        static string conexion_string_sqlserver = "server = localhost; database = pokemon88 ; integrated security = true"; //cadena de conexión

        SqlConnection conexion = new SqlConnection(conexion_string_sqlserver); //objeto de conexión SQL Server
        */

        /*
         * Conexión con MySQL
        static string conexion_string_mysql = "server=localhost;database=pokemon88;user=root;password=;"; // Cadena de conexión para MySQL
        
        MySqlConnection conexion = new MySqlConnection(conexion_string_mysql); // Objeto de conexión de MySQL
        */

        /*
         * Conexión con PostgreSQL
        static string conexion_string = "Host=localhost;Port=5432;Username=postgres;Password=admin;Database=inventario;"; // Cadena de conexión para PostgreSQL

        NpgsqlConnection conexion = new NpgsqlConnection(conexion_string); // Objeto de conexión para PostgreSQL
        */

        //usando el gestor de base de datos de laragon
        static string conexion_string = "server=localhost;database=prueba;user=root;password=;";

        MySqlConnection conexion = new MySqlConnection(conexion_string);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open(); //abrir la conexión
                MessageBox.Show("La conexión a la base de datos: " + conexion.Database + ", ha sido exitosa");
            }
            catch (Exception ex)
            {
                    MessageBox.Show("Error al conectarse a la base de datos: " + ex.Message);
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Close(); // Cerrar la conexión
                MessageBox.Show("Se ha cerrado la conexión a la base de datos de forma correcta");
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desconectar: " + ex.Message);
            }
        }
    }
}
