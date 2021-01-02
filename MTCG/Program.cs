using System;
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
            Database connectHandler = new Database();
            //connectHandler.Connection();
            //User user = new User(connectHandler);

            /*if ( connectHandler.Login("Raphie", "Raphie"))
            {
                Console.WriteLine("YOOOOOOO");
            }

            connectHandler.Logout("Raphie");*/

            //connectHandler.ScoreHandler("banane", ScoreProperty.Load, 0);


            //Console.WriteLine(connectHandler.ScoreHandler("banane", ScoreProperty.Lose, 100));

            //Console.WriteLine(connectHandler.UsernameTaken("Fenkind"));
            //Console.WriteLine(connectHandler.CoinHandler("banane", CoinProperty.Decrease, 1));
            /*User user = new User("test", "test");
            user.LoginOrCreate();
            user.LoadCards();
            user.PrintStackCards();
            user.PrintDeckCards();
            user.SwapCard(144);
            user.PrintStackCards();
            user.PrintDeckCards();
            user.Logout();*/

            User user = new User("test", "test");
            user.LoadCards();
            user.ShowLeaderBoard();
            /*user.TradeCard("fest", 222);
            user.ShowTrades();
            /*user.PrintStackCards();
            user.PrintDeckCards();
            user.ShowShop();
            user.BuyCard(2);*/

            /*CardData data = new CardData();
            data.PrintAllCards();*/

            //connectHandler.InsertRandomCards("test");

            /*BattleHandler battle = new BattleHandler();

            battle.StartBattle("test", "fest");*/

        }
    }
}
