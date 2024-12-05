﻿using System;
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
                switch (user)
                {
                    case "admin":
                        //MessageBox.Show("Escribiste admin, puedes pasar", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        switch (password)
                        {
                            case "admin":
                                MessageBox.Show("Usuario administrador, puedes pasar", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;

                            default:
                                MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }

                        break;

                    case "juan":
                        MessageBox.Show("Escribiste juan, puedes ingresar", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    default:
                        MessageBox.Show("Usuario incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                /*
                if (user.Equals("admin", StringComparison.OrdinalIgnoreCase)) //comparación insensible a mayúsculas y minúsculas
                {
                    if (password == "admin")
                    {
                        MessageBox.Show("¡Credenciales correcta! Puedes pasar.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("¡Contraseña incorrecta! Intenta de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (user == "juan" && password == "123")
                {
                    MessageBox.Show("¡Credenciales correcta! Puedes pasar.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("¡Usuario incorrecto! Intenta de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                */

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
