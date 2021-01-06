using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using MTCG.battle;
using MTCG.server.enums;

namespace MTCG.server
{

    public class Server
    {
        TcpListener _server = null;
        BattleLobby _lobby = new BattleLobby();
        public Server(string ip, int port)
        {
            IPAddress localAddr = IPAddress.Parse(ip);
            _server = new TcpListener(localAddr, port);
            _server.Start();
            StartListener();
        }
        public void StartListener()
        {
            try
            {
                while (true)
                {
                    

                    Console.WriteLine("Waiting for a connection...");
                    TcpClient client = _server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    Thread t = new Thread(new ParameterizedThreadStart(HandleDevice));
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                _server.Stop();
            }
        }
        public void HandleDevice(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            var stream = client.GetStream();
            string data = null;
            Byte[] bytes = new Byte[300000];
            int i;
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

                    if (tcp.GetPath() == AllowedPaths.Users && tcp.GetMethod() == AllowedMethods.POST)
                    {
                        tcp.Login();
                    }
                    else if (tcp.AuthorizationHeader())
                    {
                        if (tcp.AuthorizeClient())
                        {
                            if (tcp.GetPath() == AllowedPaths.Logout && tcp.GetMethod() == AllowedMethods.POST)
                            {
                                tcp.Logout();
                            }
                            else if (tcp.GetPath() == AllowedPaths.Stats && tcp.GetMethod() == AllowedMethods.GET)
                            {
                                tcp.ShowStats();
                            }
                            else if (tcp.GetPath() == AllowedPaths.Score && tcp.GetMethod() == AllowedMethods.GET)
                            {
                                tcp.ShowLeaderBoard();
                            }
                            else if (tcp.GetPath() == AllowedPaths.TransactionsPackages && tcp.GetMethod() == AllowedMethods.GET)
                            {
                                tcp.ShowShop();
                            }
                            else if (tcp.GetPath() == AllowedPaths.TransactionsPackages && tcp.GetMethod() == AllowedMethods.POST)
                            {
                                tcp.BuyCardPack();
                            }
                            else if (tcp.GetPath() == AllowedPaths.Cards && tcp.GetMethod() == AllowedMethods.GET)
                            {
                                tcp.ShowAllCards();
                            }
                            else if (tcp.GetPath() == AllowedPaths.Deck && tcp.GetMethod() == AllowedMethods.GET)
                            {
                                tcp.ShowDeckCards();
                            }
                            else if (tcp.GetPath() == AllowedPaths.Deck && tcp.GetMethod() == AllowedMethods.PUT)
                            {
                                tcp.ChangeDeckCards();
                            }
                            else if (tcp.GetPath() == AllowedPaths.Battle && tcp.GetMethod() == AllowedMethods.GET)
                            {
                                tcp.Battle(_lobby);
                            }
                            else if (tcp.GetPath() == AllowedPaths.BattleLog && tcp.GetMethod() == AllowedMethods.GET)
                            {
                                tcp.BattleLog(_lobby);
                            }
                            else if (tcp.GetPath() == AllowedPaths.Tradings && tcp.GetMethod() == AllowedMethods.GET)
                            {
                                tcp.ShowTrades();
                            }
                            else if (tcp.GetPath() == AllowedPaths.Tradings && tcp.GetMethod() == AllowedMethods.POST)
                            {
                                tcp.TradeOrInsert();
                            }
                            else if (tcp.GetPath() == AllowedPaths.Tradings && tcp.GetMethod() == AllowedMethods.DELETE)
                            {
                                tcp.DeleteTradeDeal();
                            }
                            else if (tcp.GetPath() == AllowedPaths.WatchAds && tcp.GetMethod() == AllowedMethods.GET)
                            {
                                tcp.WatchAds();
                            }
                            else
                            {
                                tcp.WrongPath();
                            }

                        }
                    }
                    else
                    {
                        tcp.FalseCredentials();
                        Console.WriteLine("Falsche Login Sachen");
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