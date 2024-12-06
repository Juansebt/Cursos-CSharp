using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //libreria para trabajar con archivos

namespace Datos_connection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEscribir_Click(object sender, EventArgs e)
        {
            TextWriter Escribe = new StreamWriter("Test.txt"); //creamos un objeto de tipo TextWriter y le asignamos un nombre, este lo guarda en la carpeta raiz

            Escribe.WriteLine("Hola mundo!"); //contenido del archivo

            Escribe.Close(); //cerrar recursos - objeto

            MessageBox.Show("Archvio creado con exito");

            /*
            string rutaArchivo = @"C:\MiCarpeta\Test.txt";

            // Usar 'using' para asegurar que los recursos se liberen correctamente
            using (TextWriter Escribe = new StreamWriter(rutaArchivo))
            {
                Escribe.WriteLine("Hola mundo!");
            }

            MessageBox.Show("Archivo creado y contenido escrito en: " + rutaArchivo);
            */
        }
    }
}
