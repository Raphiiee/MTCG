using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
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
            string sql = "SELECT * FROM cards ORDER BY card_id";

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
            string sqlGetDeckCardIds = "SELECT card_id FROM stack Where username=@u AND islocked = false AND isindeck = true ORDER BY card_id LIMIT 4";

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
            string sqlGetStackCardIds = "SELECT card_id FROM stack Where username=@u AND islocked = false AND isindeck = false ORDER BY card_id";

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

        public string ShowShop(Dictionary<int, Card> cardData)
        {
            string sqlShowShop = "SELECT pack_id, card_id, \"cost\" FROM shop ORDER BY pack_id, card_id";
            string shop = "";
            int i = 0;

            _conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlShowShop, _conn);
            cmd.Prepare();

            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Card temp;
                if (i % 5 == 0)
                {
                    shop += $"\nPack {reader.GetInt32(0)} [COSTS {reader.GetInt32(2)} COINs]";
                    i = 0;
                }
                if (cardData.TryGetValue(reader.GetInt32(1), out temp))
                {
                    shop += $"\n\t{i+1}.Karte: {temp.CardId} Type: {temp.CardType} Property: {temp.CardProperty} Element: {temp.Element} Type: {temp.CardDamage} Name: {temp.CardName}";
                }

                i++;
            }

            _conn.Close();

            return shop;
        }

        public bool BuyCard(string user, int coins, int packId, int[] cards)
        {
            string sqlShowShop = "SELECT card_id, \"cost\" FROM shop WHERE pack_id=@pi ORDER BY card_id";
            string sqlBuyCard = "INSERT INTO stack (username, card_id) VALUES (@u,@ci)";
            string sqlSubtractCoins = "UPDATE \"user\" SET COINS=COINS-@cv WHERE username=@u";
            string sqlSpendCoins = "UPDATE \"user\" SET spendcoins=spendcoins+@cv WHERE username=@u";
            int coinValue = 0;
            int[] cardPackCardIds = new int[6];
            int i = 0;

            _conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlShowShop, _conn);
            cmd.Parameters.AddWithValue("pi", packId);
            cmd.Prepare();

            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                coinValue = reader.GetInt32(1);
                if (!cards.Contains(reader.GetInt32(0)))
                {
                    cardPackCardIds[i] = reader.GetInt32(0);
                    i++;
                }

                if (coins - reader.GetInt32(1) < 0)
                { 
                    return false;
                }
                
            }
            _conn.Close();

            for (int j = 0; j < 5; j++)
            {
                int k = 0;
                if (cardPackCardIds[j] != 0)
                {
                    _conn.Open();
                    cmd = new NpgsqlCommand(sqlBuyCard, _conn);
                    cmd.Parameters.AddWithValue("u", user);
                    cmd.Parameters.AddWithValue("ci", cardPackCardIds[j]);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    _conn.Close();
                }
                k++;

                if (k >= 5)
                {
                    return false;
                }
            }

            _conn.Open();
            cmd = new NpgsqlCommand(sqlSubtractCoins, _conn);
            cmd.Parameters.AddWithValue("u", user);
            cmd.Parameters.AddWithValue("cv", coinValue);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            _conn.Close();

            _conn.Open();
            cmd = new NpgsqlCommand(sqlSpendCoins, _conn);
            cmd.Parameters.AddWithValue("u", user);
            cmd.Parameters.AddWithValue("cv", coinValue);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            _conn.Close();


            return true;
        }

        public string ShowTrades(Dictionary<int, Card> cardData)
        {
            string trades = "";
            string sqlShowTrades = "SELECT username, wanted_id, give_id FROM trade";
            int i = 1;

            _conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlShowTrades, _conn);
            cmd.Prepare();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Card wantTemp;
                Card giveTemp;

                cardData.TryGetValue(reader.GetInt32(1), out wantTemp);
                cardData.TryGetValue(reader.GetInt32(2), out giveTemp);

                trades += $"\nUser: {reader.GetString(0)}";
                trades += $"\n\tGives: CardId: {giveTemp.CardId} CardType: {giveTemp.CardType} CardDamage: {giveTemp.CardDamage} Element: {giveTemp.Element}";
                trades += $"\n\tWants: CardId: {wantTemp.CardId} CardType: {wantTemp.CardType} CardDamage: {wantTemp.CardDamage} Element: {wantTemp.Element}\n\n";
            }
            _conn.Close();

            return trades;
        }

        public bool InsertInTradeList(string user, int giveCardId, int wantCardId)
        {
            string sqlSearchCard = "SELECT card_id FROM stack WHERE username=@u";
            string sqlLockCard = "UPDATE stack SET isindeck=false, islocked=true WHERE username=@u AND card_id=@ci";
            string sqlInsertInTradeList = "INSERT INTO trade (username, wanted_id, give_id) VALUES (@u,@wi,@gi)";
            bool cardIsInStack = false;

            _conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlSearchCard, _conn);
            cmd.Parameters.AddWithValue("u", user);
            cmd.Prepare();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (giveCardId == reader.GetInt32(0))
                {
                    cardIsInStack = true;
                }
            }
            _conn.Close();

            if (cardIsInStack)
            {
                _conn.Open();
                cmd = new NpgsqlCommand(sqlLockCard, _conn);
                cmd.Parameters.AddWithValue("u", user);
                cmd.Parameters.AddWithValue("ci", giveCardId);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                _conn.Close();

                _conn.Open();
                cmd = new NpgsqlCommand(sqlInsertInTradeList, _conn);
                cmd.Parameters.AddWithValue("u", user);
                cmd.Parameters.AddWithValue("wi", wantCardId);
                cmd.Parameters.AddWithValue("gi", giveCardId);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                _conn.Close();

            }

            return false;
        }

        public bool TradeCard(string user, string dealUser, int wantCardId)
        {
            string sqlGetTradeInfo = "SELECT give_id FROM trade WHERE username=@u AND wanted_id=@wi";
            string sqlDeleteCardFromStack = "DELETE FROM stack WHERE username=@u AND card_id=@ci";
            string sqlInsertCardIntoStack = "INSERT INTO stack (username, card_id) VALUES (@u,@ci)";
            string sqlDeleteTrade = "DELETE FROM trade WHERE username=@u AND wanted_id=@wi";
            int giveCardId = 0;

            _conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlGetTradeInfo, _conn);
            cmd.Parameters.AddWithValue("u", dealUser);
            cmd.Parameters.AddWithValue("wi", wantCardId);
            cmd.Prepare();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                giveCardId = reader.GetInt32(0);
            }
            _conn.Close();

            _conn.Open();
            cmd = new NpgsqlCommand(sqlDeleteCardFromStack, _conn);
            cmd.Parameters.AddWithValue("u", dealUser);
            cmd.Parameters.AddWithValue("ci", giveCardId);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            _conn.Close();

            _conn.Open();
            cmd = new NpgsqlCommand(sqlDeleteCardFromStack, _conn);
            cmd.Parameters.AddWithValue("u", user);
            cmd.Parameters.AddWithValue("ci", wantCardId);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            _conn.Close();

            _conn.Open();
            cmd = new NpgsqlCommand(sqlInsertCardIntoStack, _conn);
            cmd.Parameters.AddWithValue("u", dealUser);
            cmd.Parameters.AddWithValue("ci", wantCardId);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            _conn.Close();

            _conn.Open();
            cmd = new NpgsqlCommand(sqlInsertCardIntoStack, _conn);
            cmd.Parameters.AddWithValue("u", user);
            cmd.Parameters.AddWithValue("ci", giveCardId);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            _conn.Close();

            _conn.Open();
            cmd = new NpgsqlCommand(sqlDeleteTrade, _conn);
            cmd.Parameters.AddWithValue("u", dealUser);
            cmd.Parameters.AddWithValue("wi", wantCardId);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            _conn.Close();

            return true;
        }


    }
}