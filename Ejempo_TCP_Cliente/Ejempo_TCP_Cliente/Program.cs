using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace Ejempo_TCP_Cliente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient  clientardo = new TcpClient();

            //intento conectar al server que este en la ip
            //se bloquea hasta que se conecte
            clientardo.Connect("127.0.0.1", 5000);

            //NetworkStream flujillo = clientardo.GetStream();

            //byte[] yoquierobuffer = new byte[2048]; 

            //int cosas_leidas= flujillo.Read(yoquierobuffer,0,yoquierobuffer.Length);

            //string mensajardo;

            //mensajardo = Encoding.UTF8.GetString(yoquierobuffer, 0, cosas_leidas);

            //Console.WriteLine($"El server te dice esto macho {mensajardo}");



            while (true)
            {
                NetworkStream flujillo = clientardo.GetStream();

                byte[] yoquierobuffer = new byte[2048];

                int cosas_leidas = flujillo.Read(yoquierobuffer, 0, yoquierobuffer.Length);

                string mensajardo;

                mensajardo = Encoding.UTF8.GetString(yoquierobuffer, 0, cosas_leidas);

                Console.WriteLine($"El server te dice esto macho {mensajardo}");
                
            }
            


        }
    }
}
