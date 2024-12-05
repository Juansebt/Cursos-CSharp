﻿using System;
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
            // Matrices

            int[,] matriz = new int[5,5];

            //rellenar la matriz
            for (int filas = 0; filas < matriz.GetLength(0); filas++)
            {
                for (int columnas = 0; columnas < matriz.GetLength(1); columnas++)
                {
                    matriz[filas,columnas] = 300 * (filas + 3) * (columnas + 4);
                }
            }

            //leer la matriz
            for (int filas = 0; filas < matriz.GetLength(0); filas++)
            {
                for (int columnas = 0; columnas < matriz.GetLength(1); columnas++)
                {
                    MessageBox.Show("La posición es: " + filas + " - " + columnas + " = " + matriz[filas,columnas].ToString());
                }
            }

            //int[,] numeros = new int[3, 5];

            //numeros[0, 0] = 1;
            //numeros[0, 1] = 2;
            //numeros[0, 2] = 3;
            //numeros[0, 3] = 4;
            //numeros[0, 4] = 5;

            //for (int i = 0; i < 5; i++)
            //{
            //    MessageBox.Show(numeros[0,i].ToString());
            //}




            // Vectores - Arreglos

            /*
            int[] numeros = new int[5];

            numeros[0] = 1;
            numeros[1] = 2;
            numeros[2] = 3;
            numeros[3] = 4;
            numeros[4] = 5;

            //MessageBox.Show("tamaño del arreglo: " + numeros.Length.ToString());

            for (int i = 0; i < numeros.Length; i++) //recorrer un arreglo
            {
                //MessageBox.Show(numeros[i].ToString());
            }
            
            string[] posicion = new string[5];

            for (int i = 0; i < posicion.Length; i++) //llenar un arreglo
            {
                posicion[i] = "mi posicion es: " + i.ToString();
                MessageBox.Show(posicion[i].ToString());
            }
            */


            //blucles

            /*
             * ciclo do while
            string var = "";
            int x = 0;

            do
            {
                var += x.ToString() + " - ";
                x++;
            }
            while (x > 10);

            MessageBox.Show(var);
            */

            /*
             * ciclo while
            while (x < 10)
            {
                var += x.ToString() + " - ";
                x++;
            }

            MessageBox.Show(var);
            */

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
