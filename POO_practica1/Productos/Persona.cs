using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    internal class Persona
    {
        private string nombre;
        private string nit;
        string pais;

        //Métodos GET y SET

        public string Nombre { get => nombre; set => nombre = value; }
        //public string Nit { get => nit; set => nit = value; }
        //public string Pais { get => pais; set => pais = value; }

        public string Pais
        {
            get { return "Mi pais es: " + pais; }
            set { pais = value; }
        }

        public string Nit { get; set; }
    }
}
