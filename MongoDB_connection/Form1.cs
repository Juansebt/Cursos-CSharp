using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;

namespace MongoDB_connection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            actualizarEstadoBotones(); // Inicialmente actualizar el estado de los botones
        }

        Conexion conexion = new Conexion(); // Instancia de la clase Conexion, que gestiona la conexión con MongoDB

        // Método para actualizar el estado de los botones en función de la conexión
        private void actualizarEstadoBotones()
        {
            if (conexion.estaConectado())
            {
                btnConectar.Enabled = false;  // Desactivar el botón de conectar si ya está conectado
                btnDesconectar.Enabled = true; // Activar el botón de desconectar
            }
            else
            {
                btnConectar.Enabled = true;   // Activar el botón de conectar si no está conectado
                btnDesconectar.Enabled = false; // Desactivar el botón de desconectar si no está conectado
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            conexion.conectarDataBase(); // Llama al método de la clase Conexion para establecer la conexión con MongoDB
            actualizarEstadoBotones(); // Actualizar el estado de los botones después de conectar
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            conexion.desconectarDataBase(); // Llama al método de la clase Conexion para desconectar de MongoDB
            actualizarEstadoBotones(); // Actualizar el estado de los botones después de desconectar
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var consulta = conexion.consulta(); // Realiza la consulta
            if (consulta != null)
            {
                dgvConsulta.DataSource = consulta; // Asigna los resultados al DataGridView
                actualizarEstadoBotones();
            }
            else
            {
                MessageBox.Show("No se pudo realizar la consulta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
