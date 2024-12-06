using System;
using System.Collections.Generic;
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

        //Metodo publico que no recive ningún parámetro
        public void Llamar()
        {
            System.Windows.Forms.MessageBox.Show("Hola, su marca de telefono es " + Marca + Tipo);
        }

        public void MandarMensaje()
        {

        }
    }
}
