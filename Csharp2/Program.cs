using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp2
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //blucles

            string var = "";
            int x = 0;

            while (x < 10)
            {
                var += x.ToString() + " - ";
                x++;
            }

            MessageBox.Show(var);

            /*
             * ciclo foreach
            List<string> frutas = new List<string> { "Manzana", "Banana", "Cereza", "Mango" };

            foreach (string fruta in frutas)
            {
                MessageBox.Show(fruta);
            }
            */

            /*
             * ciclo for
            for (int i = 0; i < 10; i++)
            {
                var += i.ToString();

                if (i == 5)
                {
                    //break;
                    continue;
                }

                var += " - ";
            }

            MessageBox.Show(var);
            */

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
