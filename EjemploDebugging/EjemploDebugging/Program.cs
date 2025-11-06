using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploDebugging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProcesosGuapardos p = new ProcesosGuapardos();
            // p.ejemplosGuapardos();
            int contador = 0;
            if (args.Length < 2)
            {
                Console.WriteLine("Uso: Subproceso_SumaParcial <inicio> <fin>");
                return;
            }

            int inicio = int.Parse(args[0]);
            int fin = int.Parse(args[1]);
            long suma = 0;

            for (int i = inicio; i <= fin; i++)
            {
                if(p.esPrimo(i))
                {
                    contador ++;
                }
            
            }

            Console.WriteLine(contador);

        }
    }
    class ProcesosGuapardos
    {
        public bool esPrimo(int n)
        {
            if (n <= 1) return false;        // 0 y 1 no son primos

            for (int i = 2; i * i <= n; i++)
            {   // Basta llegar hasta raíz cuadrada
                if (n % i == 0)
                {
                    return false;             // Tiene divisor → NO es primo
                }
            }
            return true;                      // No tuvo divisores → SI es primo
        }
        public void ejemplosGuapardos()
        {
            Console.WriteLine("\nHola, que programa quieres abrir?");
            //Process paint = Process.Start("mspaint.exe");
            bool input = false;
            while (!input)
            {
                Console.WriteLine("\n1. Calculadora, \n2. Explorador carpetas \n3. Paint \n Enter para salir");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                {
                    Console.WriteLine("\nAbriendo Calculadora...");
                    Process paint = Process.Start("calc.exe");
                    paint.WaitForExit();
                    while (Console.KeyAvailable) //Limpiar el Buffer
                    {
                        Console.ReadKey(true);
                    }
                    Console.WriteLine("\nCerrando Calculadora");
                }
                else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine("\nAbriendo Explorador...");
                    Process paint = Process.Start("calc.exe");
                    paint.WaitForExit();
                    while (Console.KeyAvailable) //Limpiar el Buffer
                    {
                        Console.ReadKey(true);
                    }
                    Console.WriteLine("\nCerrando Explorador");
                }
                else if (key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.NumPad3)
                {
                    Console.WriteLine("\nAbriendo Paint...");
                    Process paint = Process.Start("mspaint.exe");
                    paint.WaitForExit();
                    while (Console.KeyAvailable) //Limpiar el Buffer
                    {
                        Console.ReadKey(true);
                    }
                    Console.WriteLine("\nCerrando Paint");

                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    input = true; break;
                }
                else { Console.WriteLine("No valido"); }
            }

            
        }
    }
}
