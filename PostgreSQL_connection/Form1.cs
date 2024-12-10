using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSQL_connection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ConexionPgsql conexionDB = new ConexionPgsql(); // Se crea una instancia de la clase conexión

        private void btnConectar_Click(object sender, EventArgs e)
        {
            conexionDB.conectarDataBase(); // Llamamos a la función para conectar a la base de datos
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            conexionDB.desconectarDataBase(); // Llamamos a la función para desconectar la base de datos
        }
    }
}
