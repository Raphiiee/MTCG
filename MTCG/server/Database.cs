using System;
using Npgsql;
using System.Threading.Tasks;
using MTCG.cards.enums;


namespace MTCG.server
{
    public class Database
    {
        string _connString = "Host=localhost;Username=postgres;Password=123;Database=mtcg";
        private NpgsqlConnection _conn;

        public void Connection()
        {
            try
            {
                _conn = new NpgsqlConnection(_connString);
                _conn.Open();
                Console.WriteLine("DB Connection established!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void InsertError()
        {
            // Insert
            string abc = "ICh bin eine Biene2!";
            var cmd = new NpgsqlCommand("INSERT INTO atable_test (column_test) VALUES (@p)", _conn);
            cmd.Parameters.AddWithValue("p", abc);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            
        }

       public void GetError()
        {
            // Retrieve all rows
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM atable_test", _conn);
            cmd.Prepare();
            NpgsqlDataReader reader = cmd.ExecuteReader();
                while ( reader.Read())
                    Console.WriteLine(reader.GetString(0));
        }

        public bool Login(string username, string passwort)
        {
            
            try
            {
                string searchUser = "SELECT pwd FROM \"user\" WHERE username=@p LIMIT 1;";
                string setUserOnline = "UPDATE \"user\" SET online='true' WHERE username=@p ;";

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

                        return true;
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return false;

        }

        public void Logout(string username)
        {
            string setUserOffline = "UPDATE \"user\" SET online='false' WHERE username=@p ;";
            NpgsqlCommand cmds = new NpgsqlCommand(setUserOffline, _conn);
            cmds.Parameters.AddWithValue("p", username);
            cmds.Prepare();
            cmds.ExecuteNonQuery();
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
                else if (cp == CardProperty.Org)
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