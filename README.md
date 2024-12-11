# CSharp Hello World Project

Este proyecto es un programa simple en C# que muestra cómo usar diferentes tipos de datos, estructuras de control, bucles, funciones y clases. El objetivo es proporcionar un ejemplo básico y funcional de las capacidades de C# y su sintaxis.

## Características

- **Hola Mundo**: Imprime un simple "Hola Mundo" como introducción al programa.
- **Tipos de datos**: Incluye ejemplos de uso de `int`, `float`, `double`, `bool`, `string`, y `dynamic`.
- **Estructuras de datos**: Uso de arrays, diccionarios (`Dictionary`), conjuntos (`HashSet`), y tuplas.
- **Bucles y Condicionales**: Ejemplos de bucles `for` y `foreach`, así como estructuras condicionales `if-else`.
- **Funciones**: Ejemplos de funciones con y sin parámetros, y con retorno de valores.
- **Clases**: Ejemplo básico de definición y uso de una clase con propiedades y un constructor.

## Temas del curso intensivo de C#

- **Sintaxis básica de C#**: Introducción a la estructura básica del lenguaje, tipos de datos y operadores.
- **Estructuras de control**: Uso de condicionales (`if`, `else`, `switch`) y bucles (`for`, `foreach`, `while`).
- **Tipos de datos**: Diferencias entre tipos por valor y tipos por referencia, incluyendo `structs` y `enums`.
- **Colecciones**: Trabajo con arrays, listas (`List`), diccionarios (`Dictionary`), y conjuntos (`HashSet`).
- **Métodos y funciones**: Definición y uso de métodos, sobrecarga de métodos, parámetros opcionales y retorno de valores.
- **Clases y Objetos**: Definición de clases, propiedades, métodos, constructores y sobrecarga de constructores.
  - **Objetos**: Instancias de clases con propiedades y comportamientos definidos.
  - **Clases**: Plantillas que definen las propiedades y comportamientos de los objetos.
  - **Namespace**: Espacios con nombre que agrupan clases y objetos para evitar conflictos de nombres.
  - **Variables públicas**: Accesibles y modificables desde cualquier parte del código.
  - **Variables privadas**: Acceso controlado mediante métodos como `get` y `set`.
  - **Método constructor**: Inicializa atributos del objeto al momento de crear una instancia.
  - **Métodos que retornan valores**: Métodos con tipo de retorno para devolver un valor.
  - **Métodos y variables estáticos**: Asociados a la clase y accesibles sin necesidad de crear un objeto.
  - **Métodos GET y SET**: Controlan el acceso a las propiedades privadas, permitiendo la lectura y escritura de valores.
- **Interfaces y clases abstractas**: Diferencias y uso de interfaces y clases abstractas en la arquitectura de software.
- **Manejo de excepciones**: Uso de `try`, `catch`, `finally`, y creación de excepciones personalizadas.
- **Delegados y eventos**: Implementación de delegados, eventos y su aplicación en el manejo de eventos de formularios.
- **Aplicaciones Windows Forms**: Introducción al desarrollo de interfaces gráficas usando Windows Forms y manejo de eventos en formularios.
- **Programación orientada a objetos (POO)**: Paradigma basado en objetos que interactúan entre sí.
  - **Encapsulamiento**: Uso de propiedades y métodos privados y públicos para proteger los datos.
- **Manejo de archivos en C#**: 
  - **Leer archivos**: Usar clases como `StreamReader` y `File.ReadAllText()` para leer el contenido de archivos.
  - **Escribir en archivos**: Uso de `StreamWriter`, `File.WriteAllText()` y `File.AppendText()` para crear y modificar archivos de texto.
  - **Abrir y guardar archivos**: Uso de `OpenFileDialog` y `SaveFileDialog` para seleccionar y guardar archivos, asegurando que se manejen correctamente las rutas y extensiones de archivo.
- **Conexión a bases de datos**: El proyecto incluye una cadena de conexión de ejemplo y métodos para abrir y cerrar conexiones a una base de datos MySQL. También cuenta con sus respectivos ejemplos de Insert, Delete, Update y consultas SQL.
  - **MySQL**: Para conectarse a una base de datos MySQL, se utiliza la librería `MySql.Data.MySqlClient`. 
  - **PostgreSQL**: Para conectarse a una base de datos PostgreSQL, se utiliza la librería `Npgsql`. 
  - **SQL Server**: Para conectarse a una base de datos SQL Server, se utiliza la librería `System.Data.SqlClient`. 
  - **MongoDB**: Para conectarse a una base de datos no relacional - MongoDB, se utiliza la librería `MongoDB.Driver - MongoDB.Bson`. 

## Requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) versión 6.0 o superior.
- [Visual Studio Code](https://code.visualstudio.com/) (opcional, para facilitar la edición y ejecución del código).
- Cualquier editor de texto que soporte C#.

## Ejecución
- `dotnet build`
- `dotnet run`

## Creación
- `dotnet new console -n HelloWorld`
