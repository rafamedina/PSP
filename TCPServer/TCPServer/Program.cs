using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // servidor que escucha en cualquier IP Local 
            TcpListener miserverguapo = new TcpListener(IPAddress.Any, 5000);
            //Abrir el servidor
            miserverguapo.Start();
            Console.WriteLine("Esperando a que se conecte mi pana...");
            


            //es bloqueante se espera a que un cliente se conecte sin seguir con el codigo
            TcpClient cliente = miserverguapo.AcceptTcpClient();
            Console.WriteLine("Cliente Conectado");

            //Obtener el flujo de datos asociado al socket del cliente en especifico
            //Todo lo que haga aqui se lo haces a cliente 

            //byte[] purodatachorizo = Encoding.UTF8.GetBytes("Soy el server, klk manin...");
            //flujodatos.Write(purodatachorizo,0, purodatachorizo.Length);

            //cierra conexion con cliente y stop del servidor


            NetworkStream flujodatos;
            string mensaje;
            byte[] puro;
            do
            {
                mensaje = Console.ReadLine();
                flujodatos = cliente.GetStream();
                puro = Encoding.UTF8.GetBytes(mensaje);
                flujodatos.Write(puro, 0, puro.Length);


            } while (mensaje != null);

            cliente.Close();
            miserverguapo.Stop();

        }
    }
}
