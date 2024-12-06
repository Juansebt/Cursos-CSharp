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
        public string Marca;
        public string Color;
        public string Tipo; 

        //Metodo publico que no recive ningún parámetro
        public void Llamar()
        {
            System.Windows.Forms.MessageBox.Show("Hola a todos...");
        }

        public void MandarMensaje()
        {

        }
    }
}
