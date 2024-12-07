using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient; // Libreria para conectarnos a base de datos - SQL Server
using MySql.Data.MySqlClient; // Librería para conectarse a MySQL
using Npgsql; // Librería para conectarse a PostgreSQL

namespace DataBase_connection
{
    public partial class Form1 : Form
    {
        /*
         * Conexión con SQL Server
        static string conexion_string_sqlserver = "server = localhost; database = pokemon88 ; integrated security = true"; // Cadena de conexión

        SqlConnection conexion = new SqlConnection(conexion_string_sqlserver); // Objeto de conexión SQL Server
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
                conexion.Open(); // Abrir la conexión
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

        public void limpiarCampos()
        {
            txtNombrePersona.Text = "";

            txtEdadPersona.Text = "";

            txtPaisPersona.Text = "";

            txtNitPersona.Text = "";
        }

        public void validarCamposLlenos()
        {
            // Validar que todos los campos estén llenos antes de ejecutar la consulta
            if (string.IsNullOrWhiteSpace(txtNombrePersona.Text) ||
                string.IsNullOrWhiteSpace(txtEdadPersona.Text) ||
                string.IsNullOrWhiteSpace(txtPaisPersona.Text) ||
                string.IsNullOrWhiteSpace(txtNitPersona.Text))
            {
                MessageBox.Show("Todos los campos deben estar llenos.");
                return;
            }

        }

        public void consulta()
        {
            try
            {
                string query = "SELECT * FROM personas"; // Definir la consulta SQL

                // Usar 'using' para asegurar el manejo adecuado de recursos
                using (MySqlCommand comando = new MySqlCommand(query, conexion)) // Ejecutar la consulta

                using (MySqlDataAdapter data = new MySqlDataAdapter(comando)) // Crear un adaptador de datos que permitirá rellenar un DataTable con los resultados
                {
                    DataTable tabla = new DataTable(); // Crear un DataTable que contendrá los resultados de la consulta

                    data.Fill(tabla); // Llenar el DataTable con los resultados de la consulta

                    dgvConsulta.DataSource = tabla; // Asignar el DataTable al DataGridView para mostrar los resultados en la interfaz
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la consulta: " + ex.Message);
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si la conexión está abierta, si no, abrirla
                if (conexion.State != ConnectionState.Open)
                    conexion.Open(); // Abrir la conexión

                // Si el campo de texto está vacío, consulta todos los registros
                if (txtPais.Text == "")
                {
                    consulta();
                }
                else
                {
                    //string query = "select * from personas where pais = '" + txtPais.Text + "'";
                    string query = "SELECT * FROM personas WHERE pais = @pais"; // Usar parámetros para evitar inyecciones SQL

                    MySqlCommand comando = new MySqlCommand(query, conexion);

                    comando.Parameters.AddWithValue("@pais", txtPais.Text); // Agregar el valor del parámetro '@pais' de manera segura usando el texto de 'txtPais'

                    MySqlDataAdapter data = new MySqlDataAdapter(comando); // Adaptador de datos que llenará el DataTable con los resultados filtrados

                    DataTable tabla = new DataTable();

                    data.Fill(tabla);

                    dgvConsulta.DataSource = tabla;

                    txtPais.Text = "";
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MySqlTransaction transaction = null; // Declarar la transacción dentro de la función

            try
            {
                validarCamposLlenos();

                // Validar que el campo edad sea un número entero
                if (!int.TryParse(txtEdadPersona.Text, out int edad))
                {
                    MessageBox.Show("La edad debe ser un número entero.");
                    return;
                }

                //string query = "INSERT INTO personas (nombre, edad, pais, nit) VALUES ('"+txtNombrePersona.Text+"', '"+txtEdadPersona.Text+"', '"+txtPaisPersona.Text+"', '"+txtNitPersona.Text+"');";

                string query = "INSERT INTO personas (nombre, edad, pais, nit) VALUES (@nombre, @edad, @pais, @nit);"; // Usar una consulta con parámetros para evitar inyecciones SQL

                // Verificar si la conexión está abierta, si no, abrirla
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                transaction = conexion.BeginTransaction(); // Iniciar la transacción

                // Usar un bloque using para liberar correctamente los recursos del comando
                using (MySqlCommand comando = new MySqlCommand(query, conexion, transaction)) // Se añade la transacción para asegurarse de que la consulta se ejecute dentro de la transacción iniciada
                {
                    // Asignar los valores a los parámetros de manera segura
                    comando.Parameters.AddWithValue("@nombre", txtNombrePersona.Text);
                    comando.Parameters.AddWithValue("@edad", edad); // Usar el valor entero para la edad
                    comando.Parameters.AddWithValue("@pais", txtPaisPersona.Text);
                    comando.Parameters.AddWithValue("@nit", txtNitPersona.Text);

                    comando.ExecuteNonQuery(); // Ejecuta la consulta
                }

                transaction.Commit(); // Si no ocurre ningún error, confirmar la transacción

                MessageBox.Show("La persona: " + txtNombrePersona.Text + " se ha agregado correctamente!");

                limpiarCampos(); // Limpiar las cajas de texto

                consulta(); // Llamar al método de consulta para actualizar la vista
            }
            catch (Exception ex)
            {
                transaction?.Rollback(); // Si ocurre un error, revertir la transacción

                MessageBox.Show("Error al insertar la persona: " + ex.Message);
            }
            finally
            {
                // Asegurarse de que la conexión se cierre después de ejecutar la consulta
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
    }
}
