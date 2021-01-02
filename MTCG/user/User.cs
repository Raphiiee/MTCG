﻿using System;
using System.Collections.Generic;
using MTCG.cards;
using MTCG.user.enums;
using MTCG.database;

namespace MTCG.user
{
    public class User
    {
        public string Username { get; }
        private string _password;
        public int Coins { get; private set; }
        public int Score { get; private set; }
        public Dictionary<int, Card> Stack = new Dictionary<int, Card>();
        public Dictionary<int, Card> Deck  = new Dictionary<int, Card>();
        private int _token;
        private Random _r = new Random();
        private Database _db = new Database();

        public User(string username, string pwd)
        {
            _password = pwd;
            Username = username;
        }

        public void LoginOrCreate()
        {

            if (_db.UsernameTaken(Username))
            {
                if (_db.Login(Username, _password))
                {
                    _token = _r.Next(100000000, 999999999);
                    Console.WriteLine($"User Logged in {Username}");

                    Coins = _db.CoinHandler(Username, CoinProperty.Load, 0);
                    Score = _db.ScoreHandler(Username, ScoreProperty.Load);

                    Console.WriteLine(Coins);
                    Console.WriteLine(Score);
                    Console.WriteLine(_token);
                }
                else
                {
                    Console.WriteLine("PWD or User Wrong");
                }
            }
            else
            {
                _db.RegisterUser(Username, _password);
                Console.WriteLine("User Registered\n Please Login");
            }
        }

        public void LoadCards()
        {
            CardData cData = new CardData();
            cData.UserCards(Username, Stack, Deck);
        }

        public void PrintStackCards()
        {
            foreach (KeyValuePair<int, Card> kvp in Stack)
            {
                Console.WriteLine("Key = {0}, Card = {1} {2} {3} {4} {5} {6}", kvp.Key, kvp.Value.CardType, kvp.Value.Element, kvp.Value.CardDamage, kvp.Value.CardName, kvp.Value.CardProperty, kvp.Value.CardId);
            }

            Console.WriteLine($"Cards: {Stack.Count}");
            Console.WriteLine("Stack Cards Printed");
        }

        public void PrintDeckCards()
        {
            foreach (KeyValuePair<int, Card> kvp in Deck)
            {
                Console.WriteLine("Key = {0}, Card = {1} {2} {3} {4} {5} {6}", kvp.Key, kvp.Value.CardType, kvp.Value.Element, kvp.Value.CardDamage, kvp.Value.CardName, kvp.Value.CardProperty, kvp.Value.CardId);
            }

            Console.WriteLine($"Cards: {Deck.Count}");
            Console.WriteLine("Deck Cards Printed");
        }

        public bool SwapCard(int stackCardId)
        {
            Card tempCard;
            int cardsInDeck = Deck.Count;
            for (int i = 0; i < Stack.Count; i++)
            {
                if (Stack.TryGetValue(i, out tempCard) && cardsInDeck <= 3)
                {
                    _db.SwapCard(Username, stackCardId);
                    LoadCards();
                    return true;
                }

                if (Stack.TryGetValue(i, out tempCard) && cardsInDeck >= 4)
                {
                    Deck.TryGetValue(Deck.Count - 1, out tempCard);
                    int lastCardIdInDeck = tempCard.CardId;

                    _db.SwapCard(Username, stackCardId, lastCardIdInDeck);
                    LoadCards();
                    return true;
                }
            }
            

            return false;
        }

        public void Logout()
        {
            _db.Logout(Username);
        }


    }
}