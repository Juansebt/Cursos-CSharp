using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp2
{
    public partial class Form1 : Form
    {
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
            string user = txtUser.Text;
            string password = txtPassword.Text;

            try
            {
                if (user.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "admin") //comparación insensible a mayúsculas y minúsculas
                {
                    MessageBox.Show("¡Usuario correcto! Puedes pasar.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("¡Usuario incorrecto! Intenta de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //operadores logicos
                //if (user != "admin" || Convert.ToInt32(password) < 100) //diferente de admin o nérmo menor de 100
                //{
                //    return;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}
