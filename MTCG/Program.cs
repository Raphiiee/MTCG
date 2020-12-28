using System;
using System.Threading.Tasks;
using MTCG.cards.enums;
using MTCG.cards.monster;
using MTCG.server;
using MTCG.user;

namespace MTCG
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Database connectHandler = new Database();
            connectHandler.Connection();

            if ( connectHandler.Login("Raphie", "Raphie"))
            {
                Console.WriteLine("YOOOOOOO");
            }

            connectHandler.Logout("Raphie");*/

            User user = new User("abc");

            Console.WriteLine(user.Coins);


        }
    }
}
