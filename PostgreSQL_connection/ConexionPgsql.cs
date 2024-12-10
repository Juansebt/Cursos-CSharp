using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        static string dbName = "prueba";

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

        private bool verificarConexion()
        {
            try
            {
                // Verificar si la conexión está abierta
                if (conexion.State == ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    conexion.Open(); // Intentar abrir la conexión si no está abierta
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: si hay una excepción, la conexión no es válida
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable consulta()
        {
            if (!verificarConexion()) return null;

            try
            {
                string query = "SELECT * FROM \"Personas\""; // Definir la consulta SQL
                // \"_"\ se usa para que el query pueda leer tablas o propiedades que inician en mayuscula

                using (NpgsqlCommand conector = new NpgsqlCommand(query, conexion))
                {
                    using (NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector))
                    {
                        DataTable tabla = new DataTable();
                        datos.Fill(tabla); // Llenar el DataTable con los resultados
                        return tabla; // Retornar el DataTable con los resultados
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la consulta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Devolver null en caso de error
            }
        }

        public DataTable consultaPorNombre(string nombre)
        {
            if (!verificarConexion()) return null;

            try
            {
                string query = "SELECT * FROM \"Personas\" WHERE nombre = @nombre";

                using (NpgsqlCommand conector = new NpgsqlCommand(query, conexion))
                {
                    conector.Parameters.AddWithValue("@nombre", nombre);

                    using (NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector))
                    {
                        DataTable tabla = new DataTable();
                        datos.Fill(tabla);
                        return tabla;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la consulta por el nombre: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable consultaPorPais(string pais)
        {
            if (!verificarConexion()) return null;

            try
            {
                string query = "SELECT * FROM \"Personas\" WHERE pais = @pais";

                using (NpgsqlCommand conector = new NpgsqlCommand(query, conexion))
                {
                    conector.Parameters.AddWithValue("@pais", pais);

                    using (NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector))
                    {
                        DataTable tabla = new DataTable();
                        datos.Fill(tabla);
                        return tabla;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la consulta por el pais: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void insertar(string nombre, int edad, string pais, string nit)
        {
            if (!verificarConexion()) return;

            NpgsqlTransaction transaction = null; // Declarar la transacción 

            try
            {
                string query = "INSERT INTO \"Personas\" (nombre, edad, pais, nit) VALUES (@nombre, @edad, @pais, @nit);";
                transaction = conexion.BeginTransaction();

                using (NpgsqlCommand conector = new NpgsqlCommand(query, conexion))
                {
                    conector.Parameters.AddWithValue("@nombre", nombre);
                    conector.Parameters.AddWithValue("@edad", edad);
                    conector.Parameters.AddWithValue("@pais", pais);
                    conector.Parameters.AddWithValue("@nit", nit);

                    conector.ExecuteNonQuery();
                }

                transaction.Commit(); // Si no ocurre ningún error, confirmar la transacción
                MessageBox.Show($"La persona: {nombre} se ha agregado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                consulta();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Error al insertar la persona: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public void eliminar(string nombre)
        {
            if (!verificarConexion()) return;

            NpgsqlTransaction transaction = null; // Declarar la transacción 

            try
            {
                string queryBuscar = "SELECT * FROM \"Personas\" WHERE nombre = @nombre"; // Consulta para obtener el ID de la persona según el nombre
                int idPersona = 0; // Almacenará el ID de la persona a eliminar

                using(NpgsqlCommand comandoBuscar = new NpgsqlCommand(queryBuscar, conexion))
                {
                    comandoBuscar.Parameters.AddWithValue("@nombre", nombre);

                    using(NpgsqlDataReader reader = comandoBuscar.ExecuteReader())
                    {
                        if (reader.Read()) // Verificar si se encontró un resultado
                        {
                            idPersona = reader.GetInt32(0); // Obtener el ID de la persona desde el resultado de la consulta - indice
                        }
                        else
                        {
                            MessageBox.Show($"No se encontró una persona con el nombre: {nombre}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // Confirmar la eliminación mostrando los detalles de la persona
                var confirmResult = MessageBox.Show($"¿Está seguro de que desea eliminar el registro de: {nombre}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.No)
                {
                    return; // Si el usuario cancela la eliminación, salir de la función
                }

                string query = "DELETE FROM \"Personas\" WHERE id = @id;";
                transaction = conexion.BeginTransaction(); // Inciar la transacción
                int flag = 0; // Para verificar el resultado de la consulta

                using(NpgsqlCommand conector = new NpgsqlCommand(query, conexion, transaction)) // Se añade la transacción para asegurarse de que la consulta se ejecute dentro de la transacción iniciada
                {
                    conector.Parameters.AddWithValue("@id", idPersona);
                    flag = conector.ExecuteNonQuery(); // Si es 1, la eliminación fue exitosa, si es 0, no se encontró el registro
                }

                // Verificar si se eliminó algún registro
                if (flag == 1)
                {
                    transaction.Commit(); // Confirmar la transacción
                    MessageBox.Show($"El registro de la persona: {nombre} se ha eliminado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrio algo, no se encontro el registro!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                consulta();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Error al insertar la persona: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
