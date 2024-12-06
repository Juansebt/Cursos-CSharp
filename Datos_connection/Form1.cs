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

            StreamWriter Agregar = File.AppendText("Test.txt"); //agregar una nueva linea en el archivo

            Agregar.WriteLine("Yo soy Juanse..."); //contenido de la nueva linea

            Agregar.Close();

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

            /*
            string archivo = "Test.txt";

            using (StreamWriter Escribe = new StreamWriter(archivo))
            {
                Escribe.WriteLine("Hola mundo!");
            }

            using (StreamWriter Agregar = File.AppendText(archivo))
            { 
                Agregar.WriteLine("Yo soy Juanse...");
            }
            */
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            TextReader Leer = new StreamReader("Test.txt"); //creamos un objeto y especificamos la ruta del archivo

            //MessageBox.Show(Leer.ReadLine()); //leer el contenido del archivo - una sola linea

            MessageBox.Show(Leer.ReadToEnd()); //lee todos los caracteres

            Leer.Close();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Buscar archvio de texto";

                // Limitar a solo archivos .txt
                openFileDialog1.Filter = "Archivos de texto (*.txt)|*.txt";

                openFileDialog1.ShowDialog();

                string Texto = openFileDialog1.FileName;

                //verificar si el archivo existe
                if (File.Exists(openFileDialog1.FileName))
                {
                    //leer el archivo
                    TextReader Leer = new StreamReader(Texto);

                    rtxtContenido.Text = Leer.ReadToEnd(); //mostrar en el richTextBox

                    Leer.Close();
                }

                txtRuta.Text = Texto; //mostra la ruta en el TextBox
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}
