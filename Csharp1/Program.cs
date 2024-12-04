using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp1
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Variables y tipos de datos
            string Nombre = "Juan Sebastián"; //texto

            int Num1 = 450; //númeero enteros
            uint Num2 = 500; //número entero pero nunca negativo, solo positivo
            float Num3 = 35.5f; //número decimal
            double Num4 = 45.50; //número decimal más grande el float
            decimal Num5 = 5020.506m; //números decimales grandes
            byte Num6 = 255; //número pequeño hasta 255

            int Num7, Num8, Num9, Num10; //declarar varias variables del mismo tipo
            Num7 = 12; Num8 = 13; Num9 = 14; Num10 = 15;

            bool Acceso = false; //booleano - verdadero o falso

            DateTime Fecha = DateTime.Today; //Fechas

            //MessageBox.Show(Nombre); //mostrar el contenido de la variables cuyo contenido es texto
            //MessageBox.Show(Num1.ToString()); //conversión de int a string
            //MessageBox.Show(Acceso.ToString()); //mostrar el contenido de la variable booleana
            MessageBox.Show(Fecha.ToShortDateString().ToString()); //mostrar la  en formato corto

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1()); //Ejecuta el formulario principal
        }
    }
}
