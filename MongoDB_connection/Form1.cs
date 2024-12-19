﻿using System;
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
        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip(); // Instancia global de ToolTip en la clase

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
            var consulta = string.IsNullOrEmpty(txtNombreConsulta.Text) && string.IsNullOrEmpty(txtPaisConsulta.Text)
                ? conexion.consulta() // Si ambos campos están vacíos
                : !string.IsNullOrEmpty(txtNombreConsulta.Text)
                    ? conexion.consultaPorNombre(txtNombreConsulta.Text) // Si el campo país tiene valor
                    : conexion.consultaPorPais(txtPaisConsulta.Text); // Si solo el campo nombre tiene valor

            if (consulta != null)
            {
                dgvConsulta.DataSource = consulta; // Asigna los resultados al DataGridView
                actualizarEstadoBotones();
                limpiarCamposFiltro();
            }
            else
            {
                MessageBox.Show("No se pudo realizar la consulta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!validarCamposLlenos()) return;
            if (!validarEdad()) return;

            conexion.registrar(txtNombrePersona.Text, int.Parse(txtEdadPersona.Text), txtPaisPersona.Text, txtNitPersona.Text);

            dgvConsulta.DataSource = conexion.consulta();
            limpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreConsulta.Text))
            {
                mostrarToolTip(txtNombreConsulta, "Por favor, ingrese un nombre.");
                return;
            }

            conexion.eliminar(txtNombreConsulta.Text);
            dgvConsulta.DataSource = conexion.consulta();
            txtNombreConsulta.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreConsulta.Text))
            {
                mostrarToolTip(txtNombreConsulta, "Por favor, ingrese un nombre.");
                return;
            }

            if (!validarCamposLlenos()) return;
            if (!validarEdad()) return;

            conexion.actualizar(txtNombreConsulta.Text, txtNombrePersona.Text, int.Parse(txtEdadPersona.Text), txtPaisPersona.Text, txtNitPersona.Text);
            dgvConsulta.DataSource = conexion.consulta();
            txtNombreConsulta.Clear();
            limpiarCampos();
        }
    }
}