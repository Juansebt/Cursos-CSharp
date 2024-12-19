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
        static string dbName = "prueba"; // Nombre de tu base de datos

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

        // Verifica si la conexión a la base de datos está activa. Si no lo está, intenta conectarse.
        private bool verificarConexion()
        {
            try
            {
                if (!conectado) // Verifica si ya está conectado
                {
                    cliente = new MongoClient(uriLocal);
                    database = cliente.GetDatabase(dbName);

                    conectado = true; // Marca la conexión como activa
                    return true;
                }
                return true; // Si ya estaba conectado, retorna true
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Devuelve el estado actual de la conexión a la base de datos.
        public bool estaConectado()
        {
            return conectado; // Retorna el estado de la conexión
        }

        // Convierte una lista de documentos de MongoDB en un DataTable.
        private DataTable convertirDocumentosADataTable(List<BsonDocument> documentos)
        {
            DataTable tabla = new DataTable();

            // Definir las columnas del DataTable
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Edad", typeof(int));
            tabla.Columns.Add("Pais", typeof(string));
            tabla.Columns.Add("Nit", typeof(string));

            // Recorre los documentos obtenidos y los agrega al DataTable
            foreach (var documento in documentos)
            {
                DataRow fila = tabla.NewRow();

                // Verifica si cada campo existe en el documento antes de asignarlo
                fila["Nombre"] = documento.Contains("nombre") ? documento["nombre"].AsString : string.Empty;
                fila["Edad"] = documento.Contains("edad") ? documento["edad"].AsInt32 : 0;
                fila["Pais"] = documento.Contains("pais") ? documento["pais"].AsString : string.Empty;
                fila["Nit"] = documento.Contains("nit") ? documento["nit"].AsString : string.Empty;

                tabla.Rows.Add(fila); // Añadir fila al DataTable
            }

            return tabla; // Retorna el DataTable con los resultados
        }

        // Realiza una consulta a la colección 'personas' en la base de datos de MongoDB y devuelve los resultados en un DataTable.
        public DataTable consulta()
        {
            if (!verificarConexion()) return null; // Verifica si la conexión está activa antes de ejecutar la consulta

            try
            {
                var collection = database.GetCollection<BsonDocument>("personas"); // Obtiene la colección 'personas'
                var documentos = collection.Find(new BsonDocument()).ToList(); // Recupera todos los documentos de la colección

                return convertirDocumentosADataTable(documentos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la consulta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Consulta documentos por nombre en la colección 'personas'
        public DataTable consultaPorNombre(string nombre)
        {
            if (!verificarConexion()) return null; // Verificar si está conectado

            try
            {
                var collection = database.GetCollection<BsonDocument>("personas");
                var filtro = Builders<BsonDocument>.Filter.Eq("nombre", nombre); // Filtro por nombre
                var documentos = collection.Find(filtro).ToList(); // Obtener los documentos que coincidan

                return convertirDocumentosADataTable(documentos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la consulta por nombre: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Consulta documentos por país en la colección 'personas'
        public DataTable consultaPorPais(string pais)
        {
            if (!verificarConexion()) return null; // Verificar si está conectado

            try
            {
                var collection = database.GetCollection<BsonDocument>("personas");
                var filtro = Builders<BsonDocument>.Filter.Eq("pais", pais); // Filtro por país
                var documentos = collection.Find(filtro).ToList(); // Obtener los documentos que coincidan

                return convertirDocumentosADataTable(documentos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la consulta por país: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void registrar(string nombre, int edad, string pais, string nit)
        {
            if (!verificarConexion()) return;

            try
            {
                var collection = database.GetCollection<BsonDocument>("personas");

                // Crear el documento (registro) que vamos a insertar
                var nuevoDocumento = new BsonDocument
                {
                    { "nombre", nombre },
                    { "edad", edad },
                    { "pais", pais },
                    { "nit", nit }
                };
                // Insertar el documento en la colección
                collection.InsertOne(nuevoDocumento);

                MessageBox.Show("Registro insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void eliminar(string nombre)
        {
            if (!verificarConexion()) return;

            try
            {
                var collection = database.GetCollection<BsonDocument>("personas");

                // Buscar el documento por nombre y obtener el _id
                var filtroNombre = Builders<BsonDocument>.Filter.Eq("nombre", nombre);
                var persona = collection.Find(filtroNombre).FirstOrDefault();

                if (persona != null)
                {
                    // Confirmar la eliminación mostrando los detalles de la persona
                    var confirmResult = MessageBox.Show($"¿Está seguro de que desea eliminar el registro de: {nombre}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.No)
                    {
                        return; // Si el usuario cancela la eliminación, salir de la función
                    }
                    var idPersona = persona["_id"].AsObjectId; // Si la persona existe, obtiene su _id
                    var filtroEliminar = Builders<BsonDocument>.Filter.Eq("_id", idPersona); // Crear el filtro para eliminar el documento por su _id
                    var resultado = collection.DeleteOne(filtroEliminar); // Ejecutar la eliminación

                    // Verificar si el documento fue eliminado
                    MessageBox.Show(resultado.DeletedCount > 0 ? "Registro eliminado correctamente." : "No se pudo eliminar el registro.", resultado.DeletedCount > 0 ? "Éxito" : "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna persona con ese nombre.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
