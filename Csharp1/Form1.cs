using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); //cerrar la ventana
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string textoDelTexBox = txtNombre.Text.Trim(); //traer lo que tiene el textBox

            if (string.IsNullOrEmpty(textoDelTexBox))
            {
                // Si el campo está vacío, muestra un mensaje de advertencia
                lblTexto.Text = "Por favor ingrese su nombre.";
                lblTexto.ForeColor = Color.Red;
            }
            else
            {
                // Si hay texto, muestra el mensaje con el nombre
                lblTexto.Text = "Bienvenido a mi primer formulario " + textoDelTexBox;
                lblTexto.ForeColor = Color.Green;
            }

            /*
            try
            {
                byte textoDelTexBox = Convert.ToByte(txtNombre.Text);
                lblTexto.Text = textoDelTexBox.ToString();
            }
            catch (OverflowException x)
            {

                MessageBox.Show("Error en el tamaño del número: " + x);
            }
            catch (FormatException y)
            {

                MessageBox.Show("Error en el formato: " + y);
            }
            */
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  // Bloquea la entrada del número
            }
        }
    }
}
