using System;                     // Tipos básicos y consola
using System.Collections.Generic; // List<T>
using System.Diagnostics;         // Process para lanzar procesos hijo
using System.IO;                  // File y Path
using System.Linq;                // OrderBy para ordenar resultados

namespace CarreraCanicasPadre
{
    // Estructura mínima para guardar cada canica terminada.
    class ResultadoCanica
    {
        public int Pista;   // Número de pista a la que pertenece
        public int Canica;  // Número de canica dentro de esa pista
        public long Tiempo; // Tiempo total de la canica
    }

    // Estructura mínima para guardar el resultado general de cada pista.
    class ResultadoPista
    {
        public int Pista;   // Id del proceso hijo
        public long Tiempo; // Tiempo total de toda la pista
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Configuración de la simulación:
            int numPistas = 3;   // Número de procesos hijo que se lanzarán simultáneamente
            int numCanicas = 3;   // Número de hilos por proceso hijo
            int distancia = 200; // Distancia que cada canica debe recorrer

            // Ruta exacta al hijo (compilado previamente).
            string rutaHijo =
@"C:\Repositorio\PSP\Canicas\CarreraCanicasHijo\bin\Debug\net8.0\CarreraCanicasHijo.exe";

            // Cancelar si el hijo no existe físicamente.
            if (!File.Exists(rutaHijo))
            {
                Console.WriteLine("ERROR: no se encuentra el ejecutable del hijo en: " + rutaHijo);
                return;
            }

            // Listas para almacenar resultados globales.
            List<ResultadoCanica> listaCanicas = new List<ResultadoCanica>();
            List<ResultadoPista> listaPistas = new List<ResultadoPista>();

            // Lista en la que guardamos los procesos hijo que se lanzan.
            List<Process> procesosHijo = new List<Process>();

            // ====================================================
            // FASE 1: Crear y lanzar TODOS los procesos hijo.
            // Esto permite que se ejecuten en paralelo.
            // ====================================================
            for (int pista = 0; pista < numPistas; pista++)
            {
                // Argumentos que recibirá el hijo:
                // <idPista> <numCanicas> <distancia>
                string argumentos = $"{pista} {numCanicas} {distancia}";

                // Configuración del proceso hijo.
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = rutaHijo;           // Ejecutable del hijo
                info.Arguments = argumentos;        // Parámetros
                info.UseShellExecute = false;       // Necesario para redirigir salida
                info.RedirectStandardOutput = true; // Leeremos la salida del hijo
                info.CreateNoWindow = true;         // No abrir ventana de consola

                // Crear el proceso hijo
                Process hijo = new Process();
                hijo.StartInfo = info;

                // Lanzarlo inmediatamente.
                hijo.Start();

                // Guardarlo para tratar su salida después.
                procesosHijo.Add(hijo);
            }

            // En este punto, todas las pistas están corriendo en paralelo.
            // Cada una con sus propios hilos.

            // ====================================================
            // FASE 2: Leer la salida de cada proceso hijo.
            // Esto no bloquea la ejecución paralela porque los
            // procesos ya están en marcha desde el bucle anterior.
            // ====================================================
            foreach (Process hijo in procesosHijo)
            {
                // Leer todo lo que escribió ese proceso.
                string salida = hijo.StandardOutput.ReadToEnd();

                // Esperar a que termine completamente.
                hijo.WaitForExit();

                // Separar la salida en líneas limpias.
                string[] lineas = salida
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                // Interpretar cada línea según el formato del hijo.
                foreach (string linea in lineas)
                {
                    if (linea.StartsWith("CANICA"))
                    {
                        // Línea con formato:
                        // CANICA;<pista>;<canica>;<tiempo>
                        string[] t = linea.Split(';');

                        listaCanicas.Add(new ResultadoCanica
                        {
                            Pista = int.Parse(t[1]),
                            Canica = int.Parse(t[2]),
                            Tiempo = long.Parse(t[3])
                        });
                    }
                    else if (linea.StartsWith("PROCESO"))
                    {
                        // Línea con formato:
                        // PROCESO;<pista>;<tiempoTotal>
                        string[] t = linea.Split(';');

                        listaPistas.Add(new ResultadoPista
                        {
                            Pista = int.Parse(t[1]),
                            Tiempo = long.Parse(t[2])
                        });
                    }
                }
            }

            // ====================================================
            // FASE 3: Clasificación de canicas (global).
            // ====================================================

            var canicasOrdenadas =
                listaCanicas.OrderBy(c => c.Tiempo).ToList();

            Console.WriteLine("CLASIFICACIÓN CANICAS:");
            int pos = 1;

            foreach (var c in canicasOrdenadas)
            {
                // Muestra: posición, pista, id canica, tiempo
                Console.WriteLine($"{pos}. Pista {c.Pista}  Canica {c.Canica}  {c.Tiempo} ms");
                pos++;
            }

            Console.WriteLine();

            // ====================================================
            // FASE 4: Clasificación por pistas (procesos hijo).
            // ====================================================

            var pistasOrdenadas =
                listaPistas.OrderBy(p => p.Tiempo).ToList();

            Console.WriteLine("TIEMPOS PISTAS:");
            foreach (var p in pistasOrdenadas)
            {
                // Muestra: pista y tiempo total de esa pista
                Console.WriteLine($"Pista {p.Pista}  {p.Tiempo} ms");
            }
        }
    }
}
