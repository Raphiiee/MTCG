using System;
using Npgsql;

namespace MTCG.database
{
    public class BattleDatabase
    {
        public string _connString = "Host=localhost;Username=postgres;Password=123;Database=mtcg";
        public NpgsqlConnection _conn { get; }

        public BattleDatabase()
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

        public int InsertPlayerInQue(string user)
        {
            int playerOneId = 0;
            int playerTwoId = 0;
            int battleId = 0;
            string sqlGetBattleAsPlayerOne = "SELECT battle_id FROM battlelog WHERE playerone is null AND isbattlefinished=false ORDER BY battle_id LIMIT 1";
            string sqlGetBattleAsPlayerTwo = "SELECT battle_id FROM battlelog WHERE playertwo is null AND isbattlefinished=false ORDER BY battle_id LIMIT 1";
            string sqlInsertPlayerOne = "UPDATE battlelog SET playerone=@u WHERE battle_id=@bi";
            string sqlInsertPlayerTwo = "UPDATE battlelog SET playertwo=@u WHERE battle_id=@bi";
            string sqlInsertPlayer = "INSERT INTO battlelog (playerone) VALUES (@u)";
            string sqlGetBattleId = "SELECT battle_id FROM battlelog WHERE playerone=@u AND playertwo=@u AND isbattlefinished=false ORDER BY battle_id DESC LIMIT 1";

            _conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlGetBattleAsPlayerOne, _conn);
            cmd.Prepare();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetInt32(0) > 0)
                {
                    playerOneId = reader.GetInt32(0);
                }
                
            }
            _conn.Close();

            _conn.Open();
            cmd = new NpgsqlCommand(sqlGetBattleAsPlayerTwo, _conn);
            cmd.Prepare();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                playerTwoId = reader.GetInt32(0);
            }
            _conn.Close();

            if (playerOneId == playerTwoId)
            {
                _conn.Open();
                cmd = new NpgsqlCommand(sqlInsertPlayer, _conn);
                cmd.Parameters.AddWithValue("u", user);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                _conn.Close();


                _conn.Open();
                cmd = new NpgsqlCommand(sqlGetBattleId, _conn);
                cmd.Parameters.AddWithValue("u", user);
                cmd.Prepare();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    battleId = reader.GetInt32(0);
                }
                _conn.Close();

            }
            else if (playerOneId > playerTwoId)
            {
                _conn.Open();
                cmd = new NpgsqlCommand(sqlInsertPlayerOne, _conn);
                cmd.Parameters.AddWithValue("u", user);
                cmd.Parameters.AddWithValue("bi", playerOneId);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                _conn.Close();

                battleId = playerOneId;
            }
            else if (playerTwoId > playerOneId)
            {
                _conn.Open();
                cmd = new NpgsqlCommand(sqlInsertPlayerTwo, _conn);
                cmd.Parameters.AddWithValue("u", user);
                cmd.Parameters.AddWithValue("bi", playerTwoId);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                _conn.Close();

                battleId = playerTwoId;
            }


            return battleId;
        }

        public string ReadBattleLog(int battleId)
        {
            string sqlGetBattleLog = "SELECT \"log\" FROM battlelog WHERE battle_id=@bi";
            string battleLog = "n";

            _conn.Open();
            var cmd = new NpgsqlCommand(sqlGetBattleLog, _conn);
            cmd.Parameters.AddWithValue("bi", battleId);
            cmd.Prepare();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0).Length > 0)
                {
                    battleLog = reader.GetString(0);
                }
                
            }
            _conn.Close();

            return battleLog;
        }

        public string GetPlayers(ref int battleId)
        {
            string sqlGetPlayers = "SELECT battle_id, playerone, playertwo FROM battlelog WHERE playerone is not null AND playertwo is not null AND isbattlefinished=false ORDER BY battle_id LIMIT 1";
            string playerOne = "";
            string playerTwo = "";
            string players = "";

            _conn.Open();
            var cmd = new NpgsqlCommand(sqlGetPlayers, _conn);
            cmd.Parameters.AddWithValue("bi", battleId);
            cmd.Prepare();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(1).Length > 0 && reader.GetString(2).Length > 0)
                {
                    battleId = reader.GetInt32(0);
                    playerOne = reader.GetString(1);
                    playerTwo = reader.GetString(2);

                    players += playerOne;
                    players += "\n";
                    players += playerTwo;
                }

            }
            _conn.Close();

            return players;
        }

        public void FinishedBattle(int battleId, string battleLog)
        {
            string sqlInsertBattleLog = "UPDATE battlelog SET \"log\"=@l WHERE battle_id=@bi";
            string sqlSetBattleFinish = "UPDATE battlelog SET isbattlefinished=true WHERE battle_id=@bi";

            _conn.Open();
            var cmd = new NpgsqlCommand(sqlInsertBattleLog, _conn);
            cmd.Parameters.AddWithValue("l", battleLog);
            cmd.Parameters.AddWithValue("bi", battleId);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            _conn.Close();

            _conn.Open();
            cmd = new NpgsqlCommand(sqlSetBattleFinish, _conn);
            cmd.Parameters.AddWithValue("bi", battleId);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            _conn.Close();
        }
    }
}