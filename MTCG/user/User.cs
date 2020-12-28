using System.Collections.Generic;
using MTCG.cards;

namespace MTCG.user
{
    public class User
    {
        public string Username { get; }
        public int Coins { get; }
        public int Score { get; }
        public Dictionary<int, BaseCards> Stack = new Dictionary<int, BaseCards>();
        public Dictionary<int, BaseCards> Deck = new Dictionary<int, BaseCards>();

        public User(string username)
        {
            this.Username = username;
        }



    }
}