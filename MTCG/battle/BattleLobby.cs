using System.Threading;
using MTCG.database;

namespace MTCG.battle
{
    public class BattleLobby
    {
        private readonly BattleHandler _battle = new BattleHandler();
        private BattleDatabase _bdb = new BattleDatabase();

        public int AddPlayer(string user)
        {
            Mutex mutex = new Mutex();
            mutex.WaitOne();
            return _bdb.InsertPlayerInQue(user);
            mutex.Close();
        }

        public string AvailablePlayers(ref int battleId)
        {
            return _bdb.GetPlayers(ref battleId);
        }

        public string ReadLog(int battleId)
        {
            string userLog = _bdb.ReadBattleLog(battleId);

            return userLog;
        }

        public void Start()
        {
            Thread.Sleep(1000);
            Mutex mutex = new Mutex();
            mutex.WaitOne();

            int battleId = 0;
            string[] players = AvailablePlayers(ref battleId).Split("\n");

            if (battleId > 0)
            {
                string battleLog = _battle.StartBattle(players[0], players[1]);
                _bdb.FinishedBattle(battleId, battleLog);
                //_battle.ClearBattle();
            }
            mutex.Close();
        }

    }
}