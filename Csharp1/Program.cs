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

            MessageBox.Show(Nombre); //mostrar el contenido de la variable

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1()); //Ejecuta el formulario principal
        }
    }
}
