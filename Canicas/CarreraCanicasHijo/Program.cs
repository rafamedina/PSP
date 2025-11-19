using System;              // Tipos básicos y consola
using System.Diagnostics;  // Stopwatch para medir tiempos
using System.Threading;    // Thread para crear hilos

namespace CarreraCanicasHijo
{
    class Program
    {
        static void Main(string[] args)
        {
            // El padre envía tres argumentos obligatorios:
            // args[0] → id de la pista (número del proceso hijo)
            // args[1] → número de canicas (número de hilos)
            // args[2] → distancia a recorrer por cada canica
            int idPista = int.Parse(args[0]);
            int numCanicas = int.Parse(args[1]);
            int distancia = int.Parse(args[2]);

            // Cronómetro global del proceso hijo.
            // Mide el tiempo total de toda la pista.
            Stopwatch cronoPista = new Stopwatch();
            cronoPista.Start();

            // Array que guarda los hilos de cada canica.
            Thread[] hilos = new Thread[numCanicas];

            // Crear y lanzar cada canica/hilo.
            // Crear y lanzar cada canica/hilo.
            for (int i = 0; i < numCanicas; i++)
            {
                int idCanica = i; // Copia local para evitar errores de captura en la lambda.

                // Crear el hilo que simula la carrera de una sola canica.
                hilos[i] = new Thread(() =>
                {
                    // Cronómetro independiente de esta canica.
                    Stopwatch cronoCanica = new Stopwatch();
                    cronoCanica.Start();

                    // Estado de la canica en la pista.
                    int posicion = 0; // Empieza en 0
                    int avance = 0; // Aumenta en cada tick

                    // Bucle principal de la carrera:
                    // Cada iteración simula un “tick” temporal y la canica avanza.
                    while (posicion < distancia)
                    {
                        // Pausa fija para simular el paso del tiempo.
                        Thread.Sleep(10);

                        // Avance basado en contador simple.
                        // La canica acelera de forma constante:
                        // avance = 1, 2, 3, 4, ...
                        avance++;

                        // La posición se actualiza sumando el avance acumulado.
                        posicion += avance;
                    }

                    // La canica ha alcanzado la meta. Se detiene el cronómetro.
                    cronoCanica.Stop();

                    // Línea de salida para el padre.
                    // El formato se usa como protocolo de comunicación.
                    // CANICA;<idPista>;<idCanica>;<tiempoMs>
                    Console.WriteLine(
                        $"CANICA;{idPista};{idCanica};{cronoCanica.ElapsedMilliseconds}");
                });

                // Iniciar el hilo.
                hilos[i].Start();
            }

            // El proceso hijo debe esperar a que terminen todos los hilos
            // antes de imprimir el resultado global de la pista.
            for (int i = 0; i < numCanicas; i++)
            {
                hilos[i].Join(); // Bloquea hasta que el hilo finaliza.
            }

            // Fin de la pista. Se detiene el cronómetro global.
            cronoPista.Stop();

            // Enviar al padre el tiempo total de esta pista.
            // PROCESO;<idPista>;<tiempoMs>
            Console.WriteLine(
                $"PROCESO;{idPista};{cronoPista.ElapsedMilliseconds}");
        }
    }
}
