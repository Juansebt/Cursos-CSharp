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

            nombre = txtNombres.Text; //obtener el nombre del textBox

            listaNombres.Add(nombre); //agregar un nombre a la lista

            listNombres.DataSource = null; //para refrescar el listBox 

            listNombres.DataSource = listaNombres; //llenar el listBox
        }
    }
}
