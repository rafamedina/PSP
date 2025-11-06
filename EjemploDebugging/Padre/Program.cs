using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padre
{ //  coger franja del subproceso y sacar os primos de esa franja y devolver cuantos numeros primos ha habido
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Suma multiproceso ===");

            int[,] rangos = new int[4, 2] { { 1, 1000 }, { 1001, 2000 }, { 2001, 3000 }, { 3001, 4000 } };
            long sumaTotal = 0;
            bool primerparcial = false;
            for (int i = 0; i < rangos.GetLength(0); i++)
            {
                int inicio = rangos[i, 0];
                int fin = rangos[i, 1];

                Process proceso = new Process();
                //"C:\Users\CAMPUSFP\source\repos\EjemploDebugging\EjemploDebugging\bin\Debug\EjemploDebugging.exe"
                
                //C:\Users\CAMPUSFP\source\repos\EjemploDebugging\EjemploDebugging\bin\Debug\EjemploDebugging.exe
                proceso.StartInfo.FileName = @"C:\Repositorio\PSP\EjemploDebugging\EjemploDebugging\bin\Debug\EjemploDebugging.exe";
                proceso.StartInfo.Arguments = inicio + " " + fin;
                proceso.StartInfo.RedirectStandardOutput = true;
                proceso.StartInfo.UseShellExecute = false;
                proceso.Start();

                string salida = proceso.StandardOutput.ReadToEnd();
                proceso.WaitForExit();
               
                long parcial = long.Parse(salida);
                Console.WriteLine("Rango " + inicio + "-" + fin + " = " + parcial);

               
                    sumaTotal += parcial;
                
            }

            Console.WriteLine("\nSuma total = " + sumaTotal);
        }
    }
}
