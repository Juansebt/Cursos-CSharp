using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Productos; //referencia al namespace de productos

namespace POO_practica1
{
    public partial class Form1 : Form
    {
        //Telefono Movistar = new Telefono(); //se instancia un objeto de la clase Telefono
        //Productos.Telefono Movistar = new Productos.Telefono();
        //Telefono Claro = new Telefono("Samsung", "Negro", "S22");

        Persona persona = new Persona();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLlamar_Click(object sender, EventArgs e)
        {
            //Movistar.Llamar();

            //MessageBox.Show(Movistar.MandarMensaje("Eduardo", "Hola a todos!"));

            //MessageBox.Show(Operaciones.Suma(5, 10).ToString());

            //Claro.Llamar();

            //Movistar.Marca = "Samsung";
            //Movistar.Llamar();

            persona.Pais = "Colombia";
            persona.Nit = "123456789";
            MessageBox.Show(persona.Nit);
        }
    }
}
