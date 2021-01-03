using System;
using System.Globalization;
using Npgsql;
using MTCG.cards.enums;
using MTCG.user.enums;


namespace MTCG.database
{
    public class Database
    {
        readonly string _connString = "Host=localhost;Username=postgres;Password=123;Database=mtcg";
        private readonly NpgsqlConnection _conn;
        private readonly Random _r = new Random();

        public Database()
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
        
        public int GetMaxCards()
        { 
            string sql = "SELECT COUNT(card_id) FROM cards";
            int maxCards = 0;
            _conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, _conn);
            cmd.Prepare();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
                maxCards = reader.GetInt32(0);

            _conn.Close();
            return maxCards;
        }

        public void InsertRandomCards(string user)
        { 
            int maxCards;
            int randomCard;
            maxCards = GetMaxCards();
            string sql = "INSERT INTO stack (username, card_id) VALUES (@u,@rc)"; 
             
            try
            { 
                _conn.Open();
                for (int i = 0; i < 4; i++)
                { 
                    randomCard = _r.Next(2, maxCards);
                    Console.WriteLine(randomCard);
                    var register = new NpgsqlCommand(sql, _conn);
                    register.Parameters.AddWithValue("u", user);
                    register.Parameters.AddWithValue("rc", randomCard);
                    register.Prepare();
                    register.ExecuteNonQuery();
                } 
                _conn.Close();
            }
            catch (Exception e) 
            { 
                Console.WriteLine(e);
                throw;
            }
        }

        public int ScoreHandler(string user, ScoreProperty property)
        { 
            int score = 0;
            string sqlElo;
            string sqlRatio = "";
            try
            { 
                if (property == ScoreProperty.Load)
                {
                    sqlElo = "SELECT score FROM \"user\" WHERE username=@u LIMIT 1";
                }
                else if (property == ScoreProperty.Lose)
                {
                    sqlElo = "UPDATE \"user\" SET score=score-5 WHERE username=@u";
                    sqlRatio = "UPDATE \"user\" SET lose=lose+1 WHERE username=@u";
                }
                else if (property == ScoreProperty.Tie)
                {
                    // sqlElo = "UPDATE \"user\" SET score=score WHERE username=@u";
                    return 1;
                }
                else if (property == ScoreProperty.Win)
                {
                    sqlElo = "UPDATE \"user\" SET score=score+3 WHERE username=@u";
                    sqlRatio = "UPDATE \"user\" SET wins=wins+1 WHERE username=@u";
                }
                else
                { 
                    return -1;
                }

                _conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sqlElo, _conn);
                cmd.Parameters.AddWithValue("u", user); 
                cmd.Prepare();

                if (property == ScoreProperty.Load)
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) 
                        score = Int32.Parse(reader[0].ToString()!);
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    cmd = new NpgsqlCommand(sqlRatio, _conn);
                    cmd.Parameters.AddWithValue("u", user);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            { 
                Console.WriteLine(e);
                throw;
            }
             
            _conn.Close();
            return score;

        }

        public int SwapCard(string user, int[] deckCardIds)
        {
            string sqlSetDeckCardTrue = "UPDATE stack SET isindeck=true WHERE username=@u AND card_id=@ci";
            string sqlSetAllCardsFalse = "UPDATE stack SET isindeck=false WHERE username=@u";

            try
            {
                _conn.Open();

                var register = new NpgsqlCommand(sqlSetAllCardsFalse, _conn);
                register.Parameters.AddWithValue("u", user);
                register.Prepare();
                register.ExecuteNonQuery();
                _conn.Close();

                for (int i = 0; i < deckCardIds.Length; i++)
                {
                    _conn.Open();
                    register = new NpgsqlCommand(sqlSetDeckCardTrue, _conn);
                    register.Parameters.AddWithValue("u", user);
                    register.Parameters.AddWithValue("ci", deckCardIds[i]);
                    register.Prepare();
                    register.ExecuteNonQuery();
                    _conn.Close();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return 200;
        }

        public int CoinHandler(string user, CoinProperty property, int coinValue = 0)
        {
            try
            {
                string sql;
                string sqls = "";
                if (property == CoinProperty.Load)
                {
                    sql = "SELECT coins FROM \"user\" WHERE username=@u LIMIT 1";
                }
                else if (property == CoinProperty.Increase)
                {
                   sql = "UPDATE \"user\" SET coins=coins+@c WHERE username=@u";
                   sqls = "UPDATE \"user\" SET gainedcoins=gainedcoins+@c WHERE username=@u";
                }
                else if (property == CoinProperty.Decrease)
                {
                   sql = "UPDATE \"user\" SET coins=coins-@c WHERE username=@u";
                   sqls = "UPDATE \"user\" SET spendcoins=spendcoins+@c WHERE username=@u";
                }
                else
                {
                    return coinValue;
                }

                _conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("u", user);
                
                if (property != CoinProperty.Load)
                {
                   cmd.Parameters.AddWithValue("c", coinValue);
                   cmd.Prepare();
                   cmd.ExecuteNonQuery();
                   _conn.Close();

                   _conn.Open();
                   cmd = new NpgsqlCommand(sqls, _conn);
                   cmd.Parameters.AddWithValue("u", user); 
                   cmd.Parameters.AddWithValue("c", coinValue);
                   cmd.Prepare();
                   cmd.ExecuteNonQuery();
                   _conn.Close();
                    return 0;
                }

                cmd.Prepare();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    coinValue = Int32.Parse(reader[0].ToString());
                 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
             
            _conn.Close();
            return coinValue;
        }

        public string ShowLeaderBoard()
        {
            string sqlLeaderBoard = "SELECT username, wins, lose, score, ROUND(wins / lose::numeric, 3) AS winratio FROM \"user\" WHERE lose <> 0 ORDER BY score DESC, winratio DESC";
            string leaderBoard = "";
            int i = 1;

            _conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlLeaderBoard, _conn);
            cmd.Prepare();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                leaderBoard += $"\n{i++}. {reader.GetString(0)}: Wins:{reader.GetInt32(1)} Lose:{reader.GetInt32(2)} Score:{reader.GetInt32(3)} WinRatio:{reader.GetValue(4)}";
            }

            _conn.Close();


            return leaderBoard;
        }

        public string ShowUserStats(string user)
        {
            string sqlLeaderBoard = "SELECT username, wins, lose, score, coins, spendcoins, gainedcoins FROM \"user\" WHERE username=@u ORDER BY score DESC";
            string userStats = "";

            _conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlLeaderBoard, _conn);
            cmd.Parameters.AddWithValue("u", user);
            cmd.Prepare();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userStats += $"\nYour Stats:\n\tWins:{reader.GetInt32(1)} Lose:{reader.GetInt32(2)} Score:{reader.GetInt32(3)} \n\tCoins:{reader.GetValue(4)} SpendCoins:{reader.GetValue(5)} GainedCoins:{reader.GetValue(6)}";
            }

            _conn.Close();

            return userStats;
        }

        public bool UsernameTaken(string user)
        {
            int counter = 0;
            string sql = "SELECT COUNT(username) FROM \"user\" WHERE username=@u";
            
            _conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, _conn);
            cmd.Parameters.AddWithValue("u", user);
            cmd.Prepare();

            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
                counter = Int32.Parse(reader[0].ToString());

            _conn.Close();

            if (counter > 0)
            {
                return true;
            }

            return false;
            
        }

        public void RegisterUser(string user, string pwd, int token)
        {
            try
            {
               _conn.Open();
                string sql = "INSERT INTO \"user\" (username, pwd, token) VALUES (@u,@p,@t)";
                var register = new NpgsqlCommand(sql, _conn);
                register.Parameters.AddWithValue("u", user);
                register.Parameters.AddWithValue("p", pwd);
                register.Parameters.AddWithValue("t", token);
                register.Prepare();
                register.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            _conn.Close();
             
            InsertRandomCards(user);
        }

        public bool Login(string username, string passwort)
        {
            
             try
             {
                 string searchUser = "SELECT pwd FROM \"user\" WHERE username=@p LIMIT 1;";
                 string setUserOnline = "UPDATE \"user\" SET online='true' WHERE username=@p ;";
                
                 _conn.Open();
                 NpgsqlCommand cmd = new NpgsqlCommand(searchUser, _conn);
                 cmd.Parameters.AddWithValue("p", username);
                 cmd.Prepare();
                 NpgsqlDataReader reader = cmd.ExecuteReader();

                 while (reader.Read())
                 { 
                    
                     if (passwort == reader.GetString(0))
                     {
                         reader.Close();
                         NpgsqlCommand cmds = new NpgsqlCommand(setUserOnline, _conn);
                         cmds.Parameters.AddWithValue("p", username);
                         cmds.Prepare();
                         cmds.ExecuteNonQuery();
                         _conn.Close();

                         return true;
                     }
                 }
                
             }
             catch (Exception e)
             {
                 Console.WriteLine(e);
                 throw;
             }
             _conn.Close();
             return false;
        }

        public int GetToken(string username)
        {
            int token = 0;
            try
            {
                string sqlToken = "SELECT token FROM \"user\" WHERE username=@u LIMIT 1;";


                _conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sqlToken, _conn);
                cmd.Parameters.AddWithValue("u", username);
                cmd.Prepare();
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    token = reader.GetInt32(0);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            _conn.Close();
            return token;
        }

        // dotnet_code_quality_unused_parameters = non_public
        public bool AuthorizeClient(int token)
        {
            string user = "";
            try
            {
                string sqlToken = "SELECT username FROM \"user\" WHERE \"token\"=@t LIMIT 1;";
                

                _conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sqlToken, _conn);
                cmd.Parameters.AddWithValue("t", token);
                cmd.Prepare();
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = reader.GetString(0);
                }

                

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            _conn.Close();

            if (user != "")
            {
                return true;
            }
            return false;
        }

        public string GetUserNameFromToken(int token)
        {
            string user = "sample";
            try
            {
                string sqlToken = "SELECT username FROM \"user\" WHERE \"token\"=@t LIMIT 1;";

                _conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sqlToken, _conn);
                cmd.Parameters.AddWithValue("t", token);
                cmd.Prepare();
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = reader.GetString(0);
                }

                _conn.Close();
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            _conn.Close();
            return user;

        }

        public void Logout(string username)
        {
            string setUserOffline = "UPDATE \"user\" SET online='false' WHERE username=@p ;";
            
            _conn.Open();
            NpgsqlCommand cmds = new NpgsqlCommand(setUserOffline, _conn);
            cmds.Parameters.AddWithValue("p", username);
            cmds.Prepare();
            cmds.ExecuteNonQuery();
            _conn.Close();
        }

        public void CreateCardsForTable()
        {
            string cn = "";
            CardProperty cp = CardProperty.Dragon;
            CardType ct = CardType.Monster;
            ElementType et = ElementType.Fire;
            int cd = 100;

            for (int i = 0; i < 7; i++)
            {
                if (cp == CardProperty.Dragon)
                {
                    cn = "Drache oder so";
                }
                else if (cp == CardProperty.Knight)
                {
                    cn = "Knight in the Night, just Right";
                }
                else if (cp == CardProperty.Ork)
                {
                    cn = "Ich bin Orrg und du?";
                }
                else if (cp == CardProperty.Wizard)
                {
                    cn = "Ich bin ein Witz art";
                }
                else if (cp == CardProperty.Goblin)
                {
                    cn = "Gobster the Robster";
                }
                else if (cp == CardProperty.Kraken)
                {
                    cn = "Krakie dakie do whatcha gonna do";
                }
                else if (cp == CardProperty.FireElve)
                {
                    cn = "I am Fry the FireFly";
                }

                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {

                        var cmd = new NpgsqlCommand("INSERT INTO cards (cardtype, elementtype, carddamage, cardname, cardproperty) VALUES (@ct, @et, @cd, @cn, @cp)", _conn);
                        cmd.Parameters.AddWithValue("ct", Convert.ToInt32(ct));
                        cmd.Parameters.AddWithValue("et", Convert.ToInt32(et));
                        cmd.Parameters.AddWithValue("cd", cd);
                        cmd.Parameters.AddWithValue("cn", cn);
                        cmd.Parameters.AddWithValue("cp", Convert.ToInt32(cp));
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();

                        cd += 10;
                    }

                    cd = 100;
                    et++;
                }

                cp++;
            }

            et = ElementType.Fire;
            ct = CardType.Spell;
            for (int i = 0; i < 3; i++)
            {
                if (et == ElementType.Fire)
                {
                    cn = "Fire Spell";
                }
                else if (et == ElementType.Normal)
                {
                    cn = "Normal Spell";
                }
                else if (et == ElementType.Water)
                {
                    cn = "Water Spell";
                }

                for (int j = 0; j < 10; j++)
                {
                    var cmd = new NpgsqlCommand("INSERT INTO cards (cardtype, elementtype, carddamage, cardname) VALUES (@ct, @et, @cd, @cn)", _conn);
                    cmd.Parameters.AddWithValue("ct", Convert.ToInt32(ct));
                    cmd.Parameters.AddWithValue("et", Convert.ToInt32(et));
                    cmd.Parameters.AddWithValue("cd", cd);
                    cmd.Parameters.AddWithValue("cn", cn);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    cd += 10;
                }

                cd = 100;
                et++;
            }

            
        }

    }
}