using System;
using System.Collections.Generic;
using MTCG.cards;
using MTCG.cards.enums;
using MTCG.cards.monster;
using Npgsql;

namespace MTCG.database
{
    public class CardDatabase
    {
        public string _connString = "Host=localhost;Username=postgres;Password=123;Database=mtcg";
        public NpgsqlConnection _conn { get; }

        public CardDatabase()
        {
            try
            {
                _conn = new NpgsqlConnection(_connString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void LoadAllCards(Dictionary<int, Card> cardData)
        {
            string sql = "SELECT * FROM cards";

            _conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, _conn);
            cmd.Prepare();

            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Card temp = new Card((CardType)reader.GetInt32(1), // cardType
                                     (ElementType)reader.GetInt32(2), // Elementype
                                     reader.GetInt32(3), // cardDamage
                                     reader.GetString(4), // cardName
                                     (CardProperty)reader.GetInt32(5),
                                     reader.GetInt32(0)); // cardProperty

                cardData.Add(reader.GetInt32(0), temp);
            }

            _conn.Close();
        }

        public void LoadUserDeckCards(string user, int[] deckCardsCardsArray)
        {
            int i = 0;
            string sqlGetDeckCardIds = "SELECT card_id FROM stack Where username=@u AND islocked = false AND isindeck = true LIMIT 4";

            _conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlGetDeckCardIds, _conn);
            cmd.Parameters.AddWithValue("u", user);
            cmd.Prepare();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                deckCardsCardsArray[i] = reader.GetInt32(0);
                i++;
            }
            _conn.Close();

        }

        public void LoadUserStackCards(string user, int[] stackCardsArray)
        {
            int i = 0;
            string sqlGetStackCardIds = "SELECT card_id FROM stack Where username=@u AND islocked = false AND isindeck = false";

            _conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlGetStackCardIds, _conn);
            cmd.Parameters.AddWithValue("u", user);
            cmd.Prepare();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                stackCardsArray[i] = reader.GetInt32(0);
                i++;
            }
            i = 0;
            _conn.Close();

        }

        public void LoadUserCardIds(string user, int[] stackCardsArray, int[] deckCardsCardsArray)
        {
            LoadUserStackCards(user, stackCardsArray);
            LoadUserDeckCards(user, deckCardsCardsArray);
        }






    }
}