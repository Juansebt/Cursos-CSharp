using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    public class Telefono
    {
        //Atributos o propieades de la clase
        //son atributos publicos, se pueden usar fuera de la clase
        private string Marca;
        private string Color;
        private string Tipo;

        //Metodo contructor
        public Telefono()
        {
            Marca = "Iphone";
            Color = "Blanco";
            Tipo = "16 Pro Max";
        }

        public Telefono(string M)
        {
            Marca = M;
        }

        public Telefono(string Marca, string Color, string Tipo)
        {
            this.Marca = Marca;
            this.Color = Color;
            this.Tipo = Tipo;
        }

        //Metodo publico que no recive ningún parámetro
        public void Llamar()
        {
            System.Windows.Forms.MessageBox.Show("Hola, su marca de telefono es " + Marca + " " + Tipo + " de color " + Color);
        }

        public void MandarMensaje()
        {

        }
    }
}
