using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si la conexión está abierta, si no, abrirla
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                // Si el campo de texto está vacío, consulta todos los registros
                if (txtPais.Text == "")
                {
                    string query = "select * from personas"; //script de consulta

                    MySqlCommand comando = new MySqlCommand(query, conexion); //ejecutar la consulta

                    MySqlDataAdapter data = new MySqlDataAdapter(comando); //comunica la base de datos con el datatable

                    DataTable tabla = new DataTable(); //crear un dataTable

                    data.Fill(tabla); //llenar la tabla con los resultados

                    dgvConsulta.DataSource = tabla; //asignar la tabla al DataGridView
                }
                else
                {
                    //string query = "select * from personas where pais = '" + txtPais.Text + "'";
                    string query = "select * from personas where pais = @pais"; // Usar parámetros para evitar inyecciones SQL

                    MySqlCommand comando = new MySqlCommand(query, conexion);

                    comando.Parameters.AddWithValue("@pais", txtPais.Text); // Agregar el parámetro de manera segura

                    MySqlDataAdapter data = new MySqlDataAdapter(comando);

                    DataTable tabla = new DataTable();

                    data.Fill(tabla);

                    dgvConsulta.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la consulta: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                // Asegurarse de que la conexión se cierre siempre, aunque ocurra un error
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
        }
    }
}
