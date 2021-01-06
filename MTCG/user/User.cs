using System;
using System.Collections.Generic;
using System.Linq;
using MTCG.battle;
using MTCG.cards;
using MTCG.user.enums;
using MTCG.database;

namespace MTCG.user
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Coins { get; private set; }
        public int Score { get; private set; }
        public bool IsLoggedIn { get; private set; }
        public Dictionary<int, Card> Stack = new Dictionary<int, Card>();
        public Dictionary<int, Card> Deck  = new Dictionary<int, Card>();
        public int Token;
        private Random _r = new Random();
        private Database _db = new Database();
        CardData _cData = new CardData();

        public User()
        {
            
        }

        public int LoginOrCreate()
        {
            Username = Username.ToLower();

            if (_db.UsernameTaken(Username))
            {
                if (_db.Login(Username, Password))
                {
                    
                    Console.WriteLine($"User Logged in {Username}");

                    LoadStats();
                    IsLoggedIn = true;
                    return 200;
                }
                else
                {
                    Console.WriteLine("PWD or User Wrong");
                    return 406;
                }
            }
            else
            {
                Token = _r.Next(100000, 999999);
                _db.RegisterUser(Username, Password, Token);
                Console.WriteLine("User Registered\n Please Login");
                return 201;
            }
        }

        public void LoadStats()
        {
            Coins = _db.CoinHandler(Username, CoinProperty.Load, 0);
            Score = _db.ScoreHandler(Username, ScoreProperty.Load);
            Token = _db.GetToken(Username);

            Console.WriteLine(Coins);
            Console.WriteLine(Score);
            Console.WriteLine(Token);
        }

        public bool AuthorizeClient(int token)
        {
            if (_db.AuthorizeClient(token))
            {
                Username = _db.GetUserNameFromToken(token);
                IsLoggedIn = true;
                Console.WriteLine(Username);
                LoadStats();
                return true;
            }

            return false;
        }

        public void LoadCards()
        {
            _cData.UserCards(Username, Stack, Deck);
        }

        public bool CardsInStack(int[] cardIds)
        {
            int i = 0;
            foreach (KeyValuePair<int, Card> kvp in Stack)
            {
                if(cardIds.Contains(kvp.Value.CardId))
                {
                    i++;
                }
            }

            foreach (KeyValuePair<int, Card> kvp in Deck)
            {
                if (cardIds.Contains(kvp.Value.CardId))
                {
                    i++;
                }
            }

            if (i == 4)
            {
                return true;
            }

            return false;
        }

        public string PrintStackCards()
        {
            string stackCards = "";
            foreach (KeyValuePair<int, Card> kvp in Stack)
            {
                stackCards += $"CardID {kvp.Value.CardId} |Card = {kvp.Value.CardType} {kvp.Value.Element} {kvp.Value.CardDamage} {kvp.Value.CardName} {kvp.Value.CardProperty}\n";
            }

            return stackCards;
        }

        public string PrintDeckCards()
        {
            string deckCards = "";
            foreach (KeyValuePair<int, Card> kvp in Deck)
            {
                deckCards += $"CardID {kvp.Value.CardId} |Card = {kvp.Value.CardType} {kvp.Value.Element} {kvp.Value.CardDamage} {kvp.Value.CardName} {kvp.Value.CardProperty}\n";
            }

            return deckCards;
        }

        public int SwapCard(int[] deckCardIds)
        {
            return _db.SwapCard(Username, deckCardIds);
        }

        public string ShowShop()
        {
            return _cData.ShowShop();
        }

        public int BuyCard(int packId)
        {
            int[] cardArray = new int[20000];
            Array.Fill(cardArray, -1);
            int i = 0;
            foreach (KeyValuePair<int, Card> kvp in Stack)
            {
                cardArray[i] = kvp.Value.CardId;
                i++;
            }
            foreach (KeyValuePair<int, Card> kvp in Deck)
            {
                cardArray[i] = kvp.Value.CardId;
                i++;
            }

            return _cData.BuyCard(Username, _db.CoinHandler(Username, CoinProperty.Load), packId, cardArray);
        }

        public string ShowTrades()
        {
            return _cData.ShowTrades();
        }

        public int InsertInTradeList(int giveCardId, int wantCardId)
        {
            if (giveCardId == wantCardId)
            {
                return 406;
            }

            return _cData.InsertInTradeList(Username, giveCardId, wantCardId);
        }

        public int TradeCard(string dealUser, int wantCardId)
        {
            int[] cardArray = new int[20000];
            int i = 0;

            if (dealUser == Username)
            {
                return 418;
            }

            foreach (KeyValuePair<int, Card> kvp in Stack)
            {
                cardArray[i] = kvp.Value.CardId;
                i++;
            }
            foreach (KeyValuePair<int, Card> kvp in Deck)
            {
                cardArray[i] = kvp.Value.CardId;
                i++;
            }

            if (cardArray.Contains(wantCardId))
            {
                return _cData.TradeCard(Username, dealUser, wantCardId);
            }

            return 404;
        }

        public int DeleteTradeDeal(int wantCardId)
        {
            return _cData.DeleteTradeDeal(Username,wantCardId);
        }

        public string ShowLeaderBoard()
        {
            return _db.ShowLeaderBoard();
        }

        public string ShowUserStats()
        {
            return _db.ShowUserStats(Username);
        }

        public int Battle(BattleLobby lobby)
        {
            int battleId = lobby.AddPlayer(Username);

            return battleId;
        }

        public string BattleLog(BattleLobby lobby, int battleId)
        {
            return lobby.ReadLog(battleId);
        }

        public void WatchAds()
        {
            _db.CoinHandler(Username, CoinProperty.Increase, 50);

        }

        public void Logout()
        {
            _db.Logout(Username);
        }


    }
}