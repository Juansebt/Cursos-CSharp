using System; // Importa el espacio de nombres que contiene clases básicas como Console

namespace CSharpHelloWorld // Define un espacio de nombres para evitar conflictos de nombres entre clases
{
    class HelloWorld // Define la clase principal del programa
    {
        // Método principal que ejecuta la aplicación
        static void Main(string[] args)
        {
            // Imprime "Hola Mundo" en la consola
            Console.WriteLine("Hola Mundo");

            /*
            Este es un comentario en bloque.
            */

            // Tipos de datos primitivos
            // Define una cadena de texto (string) y luego la modifica
            string myString = "Esto es un cadena de texto";
            myString = "Modificación de la cadena de texto";
            Console.WriteLine(myString); // Imprime la cadena modificada

            // Define un entero (int) y realiza operaciones aritméticas simples
            int myInt = 1;
            myInt = myInt + 4; // Incrementa el valor de myInt por 4
            Console.WriteLine(myInt); // Imprime 5
            Console.WriteLine(myInt - 2); // Imprime 3 (5 - 2)

            // Define un número de punto flotante (float) con una precisión simple
            float myFloat = 6.5f; // El sufijo 'f' indica que es un float
            Console.WriteLine(myFloat); // Imprime 6.5

            // Define un número de punto flotante de precisión doble (double)
            double myDouble = 2.5;
            Console.WriteLine(myDouble); // Imprime 2.5

            // Suma un float y un double y los imprime
            Console.WriteLine(myDouble + myFloat); // Imprime la suma: 9.0

            // Define un valor booleano (true/false)
            bool myBoolean = true;
            myBoolean = false; // Cambia el valor del booleano a false
            Console.WriteLine(myBoolean); // Imprime false

            // Dynamic permite cambiar el tipo en tiempo de ejecución
            dynamic myDynamic = 6; // Inicialmente es un entero
            myDynamic = "Mi dato dinámico"; // Cambia a cadena
            Console.WriteLine(myDynamic + myFloat); // Concatena y muestra "Mi dato dinámico6.5"

            // var infiere automáticamente el tipo de dato en función del valor inicial
            var myVar = "Mi variable de tipo inferido";
            // myVar = 6; // Error: no se puede cambiar a un tipo diferente
            Console.WriteLine(myVar); // Imprime "Mi variable de tipo inferido"

            // Interpolación de cadenas
            // Combina variables dentro de una cadena usando el formato $"{}"
            Console.WriteLine($"El valor de mi entero es {myInt} y el valor de mi booleano es {myBoolean}");

            // Definir una constante, cuyo valor no puede cambiar
            const string MyConst = "Mi constante";
            Console.WriteLine(MyConst); // Imprime "Mi constante"

            // Estructuras de datos
            // Arrays: define un array de cadenas (string)
            var myArray = new string[] { "Juan", "Yara", "Juanse" };
            Console.WriteLine(myArray[2]); // Imprime "Juanse"

            // Modifica un valor del array
            myArray[2] = "Laguna";
            Console.WriteLine(myArray[2]); // Imprime "Laguna"

            // Diccionario: almacena pares clave-valor
            var myDictionary = new Dictionary<string, int>
            {
                {"juanse", 21},
                {"sebass", 20},
                {"jonass", 19}
            };
            Console.WriteLine(myDictionary["juanse"]); // Imprime 21

            // HashSet: una colección de valores únicos
            var mySet = new HashSet<string> { "sebastián", "juan", "jonass" };
            foreach (var item in mySet) // Itera sobre el conjunto e imprime cada valor
            {
                Console.WriteLine(item);
            }

            // Tupla: permite almacenar múltiples valores agrupados
            var myTuple = ("sebastián", "juan", "jonass");
            Console.WriteLine(myTuple); // Imprime el contenido de la tupla

            // Bucles
            // Bucle for que itera desde 0 hasta 9
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i); // Imprime los números del 0 al 9
            }

            // Bucle foreach que itera sobre un array
            foreach (var item in myArray)
            {
                Console.WriteLine(item); // Imprime cada valor del array
            }

            // Bucle foreach que itera sobre un diccionario
            foreach (var item in myDictionary)
            {
                Console.WriteLine(item); // Imprime cada par clave-valor del diccionario
            }

            // Condicionales
            // Evalúa si una condición es verdadera
            myInt = 12;
            if (myInt == 11 && myBoolean == false) // Ambas condiciones deben ser verdaderas
            {
                Console.WriteLine("el valor es 11");
            }
            else if (myInt == 12 || myBoolean == true) // Solo una condición debe ser verdadera
            {
                Console.WriteLine("el valor es 12"); // Se imprime ya que myInt es 12
            }
            else
            {
                Console.WriteLine("el valor no es 11 ni 12");
            }

            // Llamadas a funciones
            MyFunction(); // Llama a la función sin retorno
            Console.WriteLine(MyFunctionWhitReturn(5)); // Llama a la función con retorno e imprime el valor 15 (10 + 5)

            // Uso de clases
            var myClass = new MyClass("Sebitas"); // Crea una instancia de la clase MyClass con un valor inicial
            myClass.myName = "Juansebt"; // Cambia el valor del campo myName
            Console.WriteLine(myClass.myName); // Imprime el nuevo valor "Juansebt"
        }

        // Definición de una función estática sin retorno
        static void MyFunction()
        {
            Console.WriteLine("Mi función"); // Imprime un mensaje
        }

        // Definición de una función estática con retorno
        // Recibe un parámetro entero, suma 10 y devuelve el resultado
        static int MyFunctionWhitReturn(int param)
        {
            return 10 + param; // Devuelve 15 si se pasa 5 como parámetro
        }

        // Definición de una clase interna
        class MyClass
        {
            // Propiedad que almacena un nombre
            public string myName { get; set; }

            // Constructor de la clase que inicializa la propiedad myName
            public MyClass(string myName)
            {
                this.myName = myName; // Asigna el valor pasado al constructor a la propiedad
            }
        }
    }
}
