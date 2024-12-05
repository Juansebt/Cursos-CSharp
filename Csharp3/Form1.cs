using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp3
{
    public partial class Form1 : Form
    {
        List<string> listaNombres = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string nombre;

            nombre = txtNombres.Text.Trim(); //obtener el nombre del textBox

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor ingrese un nombre.");
                return;
            }

            listaNombres.Add(nombre); //agregar un nombre a la lista

            ActualizarListBox();

            txtNombres.Clear(); //limpiar el campo de texto
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string nombre = txtNombres.Text.Trim(); // Obtener el nombre a eliminar

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor ingrese el nombre a eliminar.");
                return;
            }

            if (listaNombres.Contains(nombre))
            {
                listaNombres.Remove(nombre); //eliminar el item

                ActualizarListBox();
                txtNombres.Clear(); // Limpiar el campo de texto
            }
            else
            {
                MessageBox.Show("El nombre no se encuentra en la lista.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string nombreOriginal = txtNombreCambiar.Text.Trim();

            string nuevoNombre = txtNombres.Text.Trim();

            if (string.IsNullOrEmpty(nombreOriginal) || string.IsNullOrEmpty(nuevoNombre))
            {
                MessageBox.Show("Por favor ingrese el nombre a cambiar y el nuevo nombre.");
                return;
            }

            var indice = listaNombres.IndexOf(nombreOriginal); // buscar el nombre a cambiar

            if (indice >= 0)
            {
                listaNombres[indice] = nuevoNombre; // Cambiar el nombre
                ActualizarListBox();
                txtNombreCambiar.Clear(); // Limpiar el campo de texto
                txtNombres.Clear(); // Limpiar el campo de texto
            }
            else
            {
                MessageBox.Show("El nombre original no se encuentra en la lista.");
            }

            //listaNombres.RemoveAt(indice); //remover el item en cierta posición

            //listaNombres.Insert(indice, txtNombres.Text); //cambiar el nombre

        }

        private void ActualizarListBox()
        {
            listNombres.DataSource = null; // Para refrescar el ListBox
            listNombres.DataSource = listaNombres; // Llenar el ListBox
        }
    }
}
