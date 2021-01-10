using System;
using System.Threading;
using MTCG.battle;
using MTCG.cards;
using MTCG.database;
using MTCG.server;
using MTCG.user;
using MTCG.user.enums;

namespace MTCG
{
    class Program
    {
        static void Main(string[] args)
        {
           

            BattleLobby lobby = new BattleLobby();

            Thread t = new Thread(delegate ()
            {
                // replace the IP with your system IP Address...
                Server myserver = new Server("127.0.0.1", 10001);
            });
            t.Start();

            Console.WriteLine("Server Started...!");

            while (true)
            {
                lobby.Start();
                //Thread.Sleep(250);
            }

        }
    }
}
