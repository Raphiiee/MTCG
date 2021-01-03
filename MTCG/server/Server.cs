using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using MTCG.server.enums;
using MTCG.user;
using Newtonsoft.Json;

namespace MTCG.server
{
    public class Server
    {
        TcpListener server = null;
        public Server(string ip, int port)
        {
            IPAddress localAddr = IPAddress.Parse(ip);
            server = new TcpListener(localAddr, port);
            server.Start();
            StartListener();
        }
        public void StartListener()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    Thread t = new Thread(new ParameterizedThreadStart(HandleDeivce));
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                server.Stop();
            }
        }
        public void HandleDeivce(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            var stream = client.GetStream();
            string imei = String.Empty;
            string data = null;
            Byte[] bytes = new Byte[300000];
            int i;
            List<string> messageQue = new List<string>();
            DataHandler tcp = new DataHandler();

            try
            {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    data = data.ToUpper();
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: *******Received*******");
                    //Console.WriteLine("Received: {0}", data);

                    // Process the data sent by the client.


                    tcp.GetData(data);

                    if (tcp.GetPath() == AllowedPaths.Users)
                    {
                        tcp.Login();
                    }
                    else if (tcp.AuthorizationHeader())
                    {
                        if (tcp.AuthorizeClient())
                        {
                            if (tcp.GetPath() == AllowedPaths.Logout)
                            {
                                tcp.Logout();
                            }
                        }
                    }
                    else
                    {
                        tcp.WrongPath();
                        Console.WriteLine("Falscher Pfad");
                    }

                    tcp.MakeHeader();

                    Byte[] reply = Encoding.ASCII.GetBytes(tcp.GetHeader());
                    stream.Write(reply, 0, reply.Length);
                    //writer.Write("\r\n");
                    stream.Flush();
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: *******Received*******");
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: -------  SENT  -------");
                    Console.WriteLine("Sent: {0}", tcp.GetHeader());
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: -------  SENT  -------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                client.Close();
            }
        }
    }
}