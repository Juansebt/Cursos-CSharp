using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PostgreSQL_connection
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip(); // Instancia global de ToolTip en la clase

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

        private void mostrarToolTip(Control control, string mensaje)
        {
            toolTip.ToolTipTitle = "Campo requerido";
            toolTip.Show(mensaje, control, 0, -20, 3000); // Mostrar el tooltip durante 3 segundos
            control.Focus(); // Enfocar el control vacío
        }

        public void limpiarCamposFiltro()
        {
            txtNombreConsulta.Clear();
            txtPaisConsulta.Clear();
        }

        public void limpiarCampos()
        {
            txtNombrePersona.Clear();
            txtEdadPersona.Clear();
            txtPaisPersona.Clear();
            txtNitPersona.Clear();
        }

        public bool validarCamposLlenos()
        {
            // Validar que todos los campos estén llenos antes de ejecutar la consulta
            if (string.IsNullOrWhiteSpace(txtNombrePersona.Text) ||
                string.IsNullOrWhiteSpace(txtEdadPersona.Text) ||
                string.IsNullOrWhiteSpace(txtPaisPersona.Text) ||
                string.IsNullOrWhiteSpace(txtNitPersona.Text))
            {
                MessageBox.Show("Todos los campos del formulario deben estar llenos.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool validarEdad()
        {
            if (string.IsNullOrWhiteSpace(txtEdadPersona.Text))
            {
                return true; // Si no hay edad ingresada, no validamos
            }

            if (!int.TryParse(txtEdadPersona.Text, out _))
            {
                MessageBox.Show("La edad debe ser un número entero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEdadPersona.Focus();
                return false;
            }

            return true;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var consulta = string.IsNullOrEmpty(txtPaisConsulta.Text) && string.IsNullOrEmpty(txtNombreConsulta.Text)
                ? conexionDB.consulta() // Si ambos campos están vacíos
                : !string.IsNullOrEmpty(txtNombreConsulta.Text)
                    ? conexionDB.consultaPorNombre(txtNombreConsulta.Text) // Si el campo país tiene valor
                    : conexionDB.consultaPorPais(txtPaisConsulta.Text); // Si solo el campo nombre tiene valor

            // Asignar la consulta al DataGridView
            dgvConsulta.DataSource = consulta;
            limpiarCamposFiltro();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!validarCamposLlenos()) return;
            if (!validarEdad()) return;

            conexionDB.insertar(txtNombrePersona.Text, int.Parse(txtEdadPersona.Text), txtPaisPersona.Text, txtNitPersona.Text);
            dgvConsulta.DataSource = conexionDB.consulta();
            limpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si el campo de nombre está vacío antes de proceder
            if (string.IsNullOrEmpty(txtNombreConsulta.Text))
            {
                mostrarToolTip(txtNombreConsulta, "Por favor, ingrese un nombre.");
                return;
            }

            conexionDB.eliminar(txtNombreConsulta.Text);
            dgvConsulta.DataSource = conexionDB.consulta();
            txtNombreConsulta.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Verificar si el campo de nombre está vacío antes de proceder
            if (string.IsNullOrEmpty(txtNombreConsulta.Text))
            {
                mostrarToolTip(txtNombreConsulta, "Por favor, ingrese un nombre.");
                return;
            }

            if (!validarCamposLlenos()) return;
            if (!validarEdad()) return;

            conexionDB.actualizar(txtNombreConsulta.Text, txtNombrePersona.Text, int.Parse(txtEdadPersona.Text), txtPaisPersona.Text, txtNitPersona.Text);
            dgvConsulta.DataSource = conexionDB.consulta();
            txtNombreConsulta.Clear();
        }
    }
}
