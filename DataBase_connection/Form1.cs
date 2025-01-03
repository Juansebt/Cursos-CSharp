﻿using System;
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

        //usando el gestor de base de datos de laragon - MySQL
        static string conexion_string = "server=localhost;database=prueba;user=root;password=;";
        MySqlConnection conexion = new MySqlConnection(conexion_string);

        private ToolTip toolTip = new ToolTip(); // Instancia global de ToolTip en la clase

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que maneja el botón para conectar a la base de datos.
        /// </summary>
        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open(); // Abrir la conexión
                MessageBox.Show("La conexión a la base de datos: " + conexion.Database + ", ha sido exitosa");
            }
            catch (Exception ex)
            {
                    MessageBox.Show("Error al conectarse a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que maneja el botón para desconectar la base de datos.
        /// </summary>
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
                MessageBox.Show("Error al desconectar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Función para mostrar ToolTip en el campo vacío
        /// </summary>
        private void mostrarToolTip(Control control, string mensaje)
        {
            toolTip.ToolTipTitle = "Campo requerido";
            toolTip.Show(mensaje, control, 0, -20, 3000); // Mostrar el tooltip durante 3 segundos
            control.Focus(); // Enfocar el control vacío
        }

        /// <summary>
        /// Limpia los campos de entrada de texto en el formulario.
        /// </summary>
        public void limpiarCampos()
        {
            txtNombrePersona.Clear();
            txtEdadPersona.Clear();
            txtPaisPersona.Clear();
            txtNitPersona.Clear();
        }

        /// <summary>
        /// Valida que todos los campos del formulario estén llenos.
        /// </summary>
        public bool validarCamposLlenos()
        {
            // Validar que todos los campos estén llenos antes de ejecutar la consulta
            if (string.IsNullOrWhiteSpace(txtNombrePersona.Text) ||
                string.IsNullOrWhiteSpace(txtEdadPersona.Text) ||
                string.IsNullOrWhiteSpace(txtPaisPersona.Text) ||
                string.IsNullOrWhiteSpace(txtNitPersona.Text))
            {
                MessageBox.Show("Todos los campos del formulario deben estar llenos.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }

        /// <summary>
        /// Función para validad la edad
        /// </summary>
        private bool validarEdad()
        {
            if (string.IsNullOrWhiteSpace(txtEdadPersona.Text))
            {
                return true; // Si no hay edad ingresada, no validamos
            }

            if (!int.TryParse(txtEdadPersona.Text, out _))
            {
                MessageBox.Show("La edad debe ser un número entero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEdadPersona.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Ejecuta una consulta SQL para obtener todos los registros de la tabla 'personas' y los muestra en el DataGridView.
        /// </summary>
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

        /// <summary>
        /// Ejecuta una consulta para obtener los registros de la tabla 'personas' filtrados por país.
        /// </summary>
        public void consultarPorPais()
        {
            try
            {
                //string query = "select * from personas where pais = '" + txtPais.Text + "'";
                string query = "SELECT * FROM personas WHERE pais = @pais"; // Usar parámetros para evitar inyecciones SQL

                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@pais", txtPais.Text); // Agregar el valor del parámetro '@pais' de manera segura usando el texto de 'txtPais'

                    using (MySqlDataAdapter data = new MySqlDataAdapter(comando)) // Adaptador de datos que llenará el DataTable con los resultados filtrados
                    {
                        DataTable tabla = new DataTable();
                        data.Fill(tabla);
                        dgvConsulta.DataSource = tabla;
                    }
                }

                txtPais.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la consulta: " + ex.Message);
            }
        }

        /// <summary>
        /// Ejecuta una consulta para obtener los registros de la tabla 'personas' filtrados por nombre.
        /// </summary>
        public void consultarPorNombre()
        {
            try
            {
                string query = "SELECT * FROM personas WHERE nombre = @nombre";

                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", txtNombre.Text);

                    using (MySqlDataAdapter data = new MySqlDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();
                        data.Fill(tabla);
                        dgvConsulta.DataSource = tabla;
                    }
                }

                txtNombre.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la consulta: " + ex.Message);
            }
        }

        /// <summary>
        /// Maneja el evento para consultar registros según los filtros aplicados (nombre y/o país).
        /// </summary>
        private void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si la conexión está abierta, si no, abrirla
                if (conexion.State != ConnectionState.Open)
                    conexion.Open(); // Abrir la conexión

                // Si el campo de texto está vacío, consulta todos los registros
                if (string.IsNullOrEmpty(txtPais.Text) && string.IsNullOrEmpty(txtNombre.Text))
                {
                    consulta(); // Consulta sin filtros
                }
                else if (!string.IsNullOrEmpty(txtPais.Text))
                {
                    consultarPorPais(); // Consulta solo por país
                }
                else if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    consultarPorNombre(); // Consulta solo por nombre
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

        /// <summary>
        /// Evento para agregar un nuevo registro a la base de datos.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MySqlTransaction transaction = null; // Declarar la transacción dentro de la función

            try
            {
                // Validar que todos los campos estén llenos
                if (!validarCamposLlenos()) return;

                // Validar que la edad sea un número entero
                if (!validarEdad()) return;

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
                    comando.Parameters.AddWithValue("@edad", int.Parse(txtEdadPersona.Text));
                    comando.Parameters.AddWithValue("@pais", txtPaisPersona.Text);
                    comando.Parameters.AddWithValue("@nit", txtNitPersona.Text);

                    comando.ExecuteNonQuery(); // Ejecuta la consulta
                }

                transaction.Commit(); // Si no ocurre ningún error, confirmar la transacción
                MessageBox.Show("La persona: " + txtNombrePersona.Text + " se ha agregado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarCampos(); // Limpiar las cajas de texto
                consulta(); // Llamar al método de consulta para actualizar la vista
            }
            catch (Exception ex)
            {
                transaction?.Rollback(); // Si ocurre un error, revertir la transacción
                MessageBox.Show("Error al insertar la persona: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// Evento para manejar la eliminación de un registro de la base de datos según el nombre.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MySqlTransaction transaction = null;

            try
            {
                // Verificar si el campo de nombre está vacío antes de proceder
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    //MessageBox.Show("Por favor, ingrese un nombre en el filtro de busqueda para eliminar.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mostrarToolTip(txtNombre, "Por favor, ingrese un nombre.");
                    return;
                }

                // Consulta para obtener el ID de la persona según el nombre
                string queryBuscar = "SELECT * FROM personas WHERE nombre = @nombre;";

                // Verificar si la conexión está cerrada, si es así, abrirla
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                int idPersona = 0; // Almacenará el ID de la persona a eliminar

                // Ejecutar la consulta para buscar a la persona por nombre
                using (MySqlCommand comandoBuscar =  new MySqlCommand(queryBuscar, conexion))
                {
                    comandoBuscar.Parameters.AddWithValue("@nombre", txtNombre.Text); // Asingnar el valor al parámetro

                    // Ejecutar la consulta y usar un lector para obtener los resultados
                    using (MySqlDataReader reader = comandoBuscar.ExecuteReader())
                    {
                        if (reader.Read()) // Verificar si se encontró un resultado
                        {
                            idPersona = reader.GetInt32("id"); // Obtener el ID de la persona desde el resultado de la consulta
                        }
                        else
                        {
                            MessageBox.Show("No se encontró una persona con el nombre: " + txtNombre.Text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // Confirmar la eliminación mostrando los detalles de la persona
                var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar el registro de: " + txtNombre.Text + "?","Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.No)
                {
                    return; // Si el usuario cancela la eliminación, salir de la función
                }

                transaction = conexion.BeginTransaction(); // Iniciar la transacción
                string query = "DELETE FROM personas WHERE id = @id;"; // Script para eliminar
                int flag = 0; // Para verificar el resultado de la consulta

                using (MySqlCommand comando = new MySqlCommand(query, conexion, transaction)) // Se añade la transacción para asegurarse de que la consulta se ejecute dentro de la transacción iniciada
                {
                    // Asignar los valores a los parámetros de manera segura
                    comando.Parameters.AddWithValue("@id", idPersona);
                    flag = comando.ExecuteNonQuery(); // // Si es 1, la eliminación fue exitosa, si es 0, no se encontró el registro
                }

                // Verificar si se eliminó algún registro
                if (flag == 1)
                {
                    transaction.Commit(); // Confirmar la transacción
                    MessageBox.Show("El registro de la persona: " + txtNombre.Text + " se ha eliminado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrio algo, no se encontro el registro!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                txtNombre.Clear();
                consulta(); // ACtualizar los datos en la interfaz
            }
            catch (Exception ex)
            {
                transaction?.Rollback(); // Si ocurre un error, revertir la transacción
                MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        /// <summary>
        /// Evento para actualizar un registro en la base de datos según el nombre.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MySqlTransaction transaction = null; // Declarar la transacción dentro de la función

            try
            {
                // Verificar si el campo de nombre está vacío antes de proceder
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    //MessageBox.Show("Por favor, ingrese un nombre en el filtro de busqueda para actualizar.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mostrarToolTip(txtNombre, "Por favor, ingrese un nombre.");
                    return;
                }

                if (!validarCamposLlenos()) return;

                if (!validarEdad()) return;

                // Consulta para obtener el ID de la persona según el nombre
                string queryBuscar = "SELECT id FROM personas WHERE nombre = @nombre;";

                // Verificar si la conexión está abierta, si no, abrirla
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                int idPersona = 0; // Almacenar el ID de la persona a actualizar

                // Ejecutar la consulta para buscar a la persona por nombre
                using (MySqlCommand comandoBuscar = new MySqlCommand(queryBuscar, conexion))
                {
                    comandoBuscar.Parameters.AddWithValue("@nombre", txtNombre.Text); // Asingnar el valor al parámetro

                    // Ejecutar la consulta y usar un lector para obtener los resultados
                    using (MySqlDataReader reader = comandoBuscar.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idPersona = reader.GetInt32("id"); // Obtener el ID de la persona
                        }
                        else
                        {
                            MessageBox.Show("No se encontró una persona con el nombre: " + txtNombre.Text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // Confirmar la actualización mostrando los detalles de la persona
                var confirmResult = MessageBox.Show("¿Está seguro de que desea actualizar el registro de: "+ txtNombre.Text + "?","Confirmar actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.No)
                {
                    return; // Si el usuario cancela la actualización, salir de la función
                }

                transaction = conexion.BeginTransaction(); // Iniciar la transacción
                string query = "UPDATE personas SET nombre = @nombre, edad = @edad, pais = @pais, nit = @nit WHERE id = @id;";
                int flag = 0; // Para verificar el resultado de la consulta

                using (MySqlCommand comandoActualizar = new MySqlCommand(query, conexion, transaction))
                {
                    // Asignar los valores a los parámetros de manera segura
                    comandoActualizar.Parameters.AddWithValue("@id", idPersona);
                    comandoActualizar.Parameters.AddWithValue("@nombre", txtNombrePersona.Text);
                    comandoActualizar.Parameters.AddWithValue("@edad", int.Parse(txtEdadPersona.Text));
                    comandoActualizar.Parameters.AddWithValue("@pais", txtPaisPersona.Text);
                    comandoActualizar.Parameters.AddWithValue("@nit", txtNitPersona.Text);

                    // Ejecutar la consulta de actualización
                    flag = comandoActualizar.ExecuteNonQuery();
                }

                // Verificar si se actualizó algún registro
                if (flag == 1)
                {
                    transaction.Commit(); // Confirmar la transacción
                    MessageBox.Show("El registro de la persona: " + txtNombre.Text + " se ha actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el registro.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                txtNombre.Clear();
                limpiarCampos();
                consulta();
            }
            catch (Exception ex)
            {
                transaction?.Rollback(); // Si ocurre un error, revertir la transacción
                MessageBox.Show("Error al actualizar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
    }
}
