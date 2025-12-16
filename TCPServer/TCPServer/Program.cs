using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TCPServer
{
    internal class Program
    {
        TcpListener miserverguapo;
        List<TcpClient> clientes = new List<TcpClient>();
        int contador = 0;

        static void Main(string[] args)
        {
            new Program().inicio();
        }

        public void inicio()
        {
            miserverguapo = new TcpListener(IPAddress.Any, 5000);
            miserverguapo.Start();
            Console.WriteLine("Esperando a que se conecte mi pana...");
            Thread tConsola = new Thread(LeerConsola);
            tConsola.IsBackground = true;
            tConsola.Start();
            int contador = 1;
            while (true)
            {
                TcpClient cliente = miserverguapo.AcceptTcpClient();
                clientes.Add(cliente);

                Console.WriteLine($"Adepto numero {contador++}");

               // Thread t = new Thread(ElClientardo);
              //  t.Start(cliente);
            }
        }

        //public void ElClientardo(object clientin)
        //{
        //    TcpClient cliente = (TcpClient)clientin;
        //    NetworkStream flujo = cliente.GetStream();

        //    byte[] b = new byte[1024];

        //    while (true)
        //    {
        //        int lectura = flujo.Read(b, 0, b.Length);
        //        if (lectura <= 0) break;

        //        string mensaje = Encoding.UTF8.GetString(b, 0, lectura);
        //        Console.WriteLine(mensaje);

        //        byte[] d = Encoding.UTF8.GetBytes(mensaje);

        //        // broadcast a todos
        //        for (int i = 0; i < clientes.Count; i++)
        //        {
        //            NetworkStream stream = clientes[i].GetStream();
        //            stream.Write(d, 0, d.Length);
        //        }
        //    }

        //    cliente.Close();
        //    clientes.Remove(cliente);
        //}

        public void LeerConsola()
        {
            while (true)
            {
                string mensaje = Console.ReadLine();
                if (string.IsNullOrEmpty(mensaje)) continue;

                byte[] d = Encoding.UTF8.GetBytes("[EL SERVER GOTY] " + mensaje + "\n");

                for (int i = 0; i < clientes.Count; i++)
                {
                    NetworkStream stream = clientes[i].GetStream();
                    stream.Write(d, 0, d.Length);
                }
            }
        }

    }

}
