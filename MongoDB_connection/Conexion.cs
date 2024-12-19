using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Librerias de Mongo
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace MongoDB_connection
{
    internal class Conexion
    {
        // Definir las credenciales y nombre de la base de datos
        static string dbUsername = "admin"; // Nombre de usuario de la base de datos
        static string dbPassword = "admin"; // Contraseña de la base de datos
        static string dbName = "personas"; // Nombre de tu base de datos

        static string port = "27017"; // Puerto por default de Mongo
        static string host = "localhost";

        // URI de conexión a MongoDB, incluye las credenciales de autenticación y el nombre del cluster
        static string uri = $"mongodb+srv://{dbUsername}:{dbPassword}@cluster0.8seip.mongodb.net/{dbName}?retryWrites=true&w=majority&appName=Cluster0";

        // URI de conexión para una instancia local de MongoDB
        static string uriLocal = $"mongodb://{host}:{port}";

        /*
         * Si has configurado la autenticación en tu instancia local, tendrás que añadir las credenciales en el URI (ejemplo: mongodb://usuario:contraseña@localhost:27017).
        */

        // Se almacenan la referencia a la base de datos y el cliente de MongoDB
        private static IMongoDatabase database;
        private static MongoClient cliente;

        private bool conectado = false; // Verificar si la conexión está activa

        // Método para establecer la conexión a la base de datos
        public void establecerConexion()
        {
            try
            {
                cliente = new MongoClient(uriLocal); // Crea un cliente de MongoDB utilizando la URI con las credenciales
                database = cliente.GetDatabase(dbName); // Conecta a la base de datos especificada por `dbName`
                var collection = database.GetCollection<BsonDocument>("personas");

                conectado = true; // Marca la conexión como activa
                MessageBox.Show($"Conexión establecida con éxito a la base de datos: {collection.CollectionNamespace.CollectionName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                conectado=false;
                MessageBox.Show("Error al conectarse a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para obtener la base de datos
        public IMongoDatabase GetDatabase()
        {
            if (conectado)
            {
                return database; // Retornar la base de datos
            }
            else
            {
                MessageBox.Show("No se pudo conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Retornar null si no se puede obtener la base de datos
            }
        }

        public void conectarDataBase()
        {
            if (!conectado)
            {
                establecerConexion();
            }
            else
            {
                MessageBox.Show("Ya está conectado a la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void desconectarDataBase()
        {
            try
            {
                // MongoDB.Driver gestiona la conexión automáticamente,
                // no hay necesidad de desconectar explícitamente.
                if (conectado)
                {
                    conectado = false;
                    cliente = null; // Opcional: liberamos el cliente manualmente
                    database = null; // Liberamos la base de datos
                    MessageBox.Show("Desconectado de la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("No está conectado a ninguna base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desconectarse de la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para verificar si la conexión está activa
        public bool estaConectado()
        {
            return conectado; // Retorna el estado de la conexión
        }
    }
}
