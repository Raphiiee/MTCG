using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using MTCG.cards;
using MTCG.cards.enums;
using MTCG.database;
using MTCG.user.enums;

namespace MTCG.battle
{
    class BattleHandler
    {
        public string Log { get; private set; }
        private int _playerOneDamage;
        private int _playerTwoDamage;
        private int _playerOneWinCounter;
        private int _playerTwoWinCounter;
        private int _randomValueOne;
        private int _randomValueTwo;
        private readonly Dictionary<int, Card> _playerDeckOne = new Dictionary<int, Card>();
        private readonly Dictionary<int, Card> _playerDeckTwo = new Dictionary<int, Card>();
        private readonly CardData _cData = new CardData();
        private readonly Database _db = new Database();
        private readonly Random _random = new Random();

        public void StartBattle(string userPo, string userPt)
        {
            int i = 1;
            LoadUserDecks(userPo, userPt);

            for (; i < 101; i++)
            {
                if (_playerDeckOne.Count <= 0 || _playerDeckTwo.Count <= 0)
                {
                    break;
                }

                Card playerOneCard;
                Card playerTwoCard;

                Log += $"\n\n-------------Runde {i}-------------";
                Log += $"\n\t{userPo} has won {_playerOneWinCounter} Runden and has {_playerDeckOne.Count} Cards";
                Log += $"\n\t{userPt} has won {_playerTwoWinCounter} Runden and has {_playerDeckTwo.Count} Cards\n";

                _randomValueOne = _random.Next(0, _playerDeckOne.Count - 1);
                _randomValueTwo = _random.Next(0, _playerDeckTwo.Count - 1);

                
                _playerDeckOne.TryGetValue(_randomValueOne, out playerOneCard);
                _playerDeckTwo.TryGetValue(_randomValueTwo, out playerTwoCard);

                _playerOneDamage = playerOneCard.CardDamage;
                _playerTwoDamage = playerTwoCard.CardDamage;

                LogInfoCard(userPo, playerOneCard, _playerOneDamage);
                Effectiveness(playerOneCard, playerTwoCard, _playerOneDamage);
                DodgeAttack(playerOneCard, playerTwoCard, _playerOneDamage);

                LogInfoCard(userPt, playerTwoCard, _playerTwoDamage);
                Effectiveness(playerTwoCard, playerOneCard, _playerTwoDamage);
                DodgeAttack(playerTwoCard,playerOneCard,_playerTwoDamage);

                Log += "_______________________________________";

                if (_playerOneDamage > _playerTwoDamage)
                {
                    _playerOneWinCounter++;
                    TakeCardOver(_playerDeckOne,_playerDeckTwo, playerTwoCard);
                    Log += $"\n{userPo} has won this Round with {_playerOneDamage}";
                }
                else if (_playerTwoDamage > _playerOneDamage)
                {
                    _playerTwoWinCounter++;
                    TakeCardOver(_playerDeckTwo, _playerDeckOne, playerOneCard);
                    Log += $"\n{userPt} has won this Round with {_playerTwoDamage}";
                }
                else
                {
                    Log += $"\n{userPo} and {userPt} has the same Damage points [TIE]";
                }
            }

            Log += "\n##################################";
            if (i >= 100)
            {
                // TIE
                Log += "\nKein Teilnehmer hat eindeutig Gewonnen => TIE";
                _db.ScoreHandler(userPo, ScoreProperty.Tie);
                _db.ScoreHandler(userPt, ScoreProperty.Tie);
            }
            if (_playerOneWinCounter > _playerTwoWinCounter)
            {
                // PLayer One Wins
                Log += $"\n{userPo} hat Gewonnen!\n{userPt} hat verloren :0";
                _db.ScoreHandler(userPo, ScoreProperty.Win);
                _db.ScoreHandler(userPt, ScoreProperty.Lose);
            } 
            if (_playerTwoWinCounter > _playerOneWinCounter)
            {
                // Player Two Wins
                Log += $"\n{userPt} hat Gewonnen!\n{userPo} hat verloren :0";
                _db.ScoreHandler(userPt, ScoreProperty.Win);
                _db.ScoreHandler(userPo, ScoreProperty.Lose);
            }

            PrintLog();

        }

        public void LoadUserDecks(string userPo, string userPt)
        {
            _cData.UserDeckCards(userPo, _playerDeckOne);
            _cData.UserDeckCards(userPt, _playerDeckTwo);
        }

        public void Effectiveness(Card attackCard, Card defenderCard, int attackCardDamage)
        {
            if (attackCard.CardType == CardType.Spell)
            {
                if (defenderCard.CardProperty == CardProperty.Kraken)
                {
                    Log += "\n\tKraken immune against spells => NO EFFECT ";
                    return;
                }
                if ((defenderCard.CardProperty == CardProperty.Knight) && attackCard.Element == ElementType.Water)
                {
                    Log += "\n\tKnight Drawned in Water Spell => Dead";
                    attackCardDamage = Int32.MaxValue;
                    return;
                }
                if ((attackCard.Element == ElementType.Water) && (defenderCard.Element == ElementType.Fire))
                {
                    attackCardDamage = attackCardDamage * 2;
                    Log += $"\n\tWater -> Fire => EFFECT Damage*2={attackCardDamage}";
                    return;
                }
                if ((attackCard.Element == ElementType.Fire) && (defenderCard.Element == ElementType.Normal))
                {
                    attackCardDamage = attackCardDamage * 2;
                    Log += $"\n\tFire -> Normal => EFFECT Damage*2={attackCardDamage}";
                    return;
                }
                if ((attackCard.Element == ElementType.Normal) && (defenderCard.Element == ElementType.Water))
                {
                    attackCardDamage = attackCardDamage * 2;
                    Log += $"\n\tNormal -> Water => EFFECT Damage*2={attackCardDamage}";
                    return;
                }
            }
            Log += "\n\tNo Effects";
        }

        public void DodgeAttack(Card attackCard, Card defenderCard, int attackCardDamage)
        {
            if ((attackCard.CardProperty == CardProperty.Goblin) && (defenderCard.CardProperty == CardProperty.Dragon))
            {
                Log += "\n\tGoblin hat zu viel Angst vor dem Drachen und greift nicht an";
                attackCardDamage = 0;
                return;
            }
            if ((attackCard.CardProperty == CardProperty.Ork) && (defenderCard.CardProperty == CardProperty.Wizard))
            {
                Log += "\n\tOrk kann den Wizard nicht greifen, weil der Wizard ihn kontrolliert";
                attackCardDamage = 0;
                return;
            }
            if ((attackCard.CardProperty == CardProperty.Dragon) && (defenderCard.CardProperty == CardProperty.FireElve))
            {
                Log += "\n\tDragon kann nicht angreifen, weil die FireElve ausweicht";
                attackCardDamage = 0;
                return;
            }

            Log += "\n\tNo Dodge!\n";
        }

        public void TakeCardOver(Dictionary<int, Card> winner, Dictionary<int, Card> loser, Card takenCard)
        {
            winner.Add(winner.Count, takenCard);

            Card tempCard;
            Dictionary<int, Card> tempDictionary = new Dictionary<int, Card>();
            int i = 0;
            for (; i < loser.Count; i++)
            {
                loser.TryGetValue(i, out tempCard);
                if (tempCard == takenCard)
                {
                    break;
                }
            }
            loser.Remove(i);

            for (int j = 0; j < loser.Count; j++)
            {
                if (loser.TryGetValue(j, out tempCard))
                {
                    tempDictionary.Add(j, tempCard);
                }
                else
                {
                    loser.TryGetValue(j + 1, out tempCard);
                    tempDictionary.Add(j, tempCard);
                }

            }

            loser.Clear();
            for (int k = 0; k < tempDictionary.Count; k++)
            {
                tempDictionary.TryGetValue(k, out tempCard);
                loser.Add(k, tempCard);
            }
            
        }

        public void LogInfoCard(string user, Card card, int cardDamage)
        {
            Log += $"\n{user} spielt: \n";
            if (card.Element == ElementType.Fire)
            {
                Log += "\teinen Feuer ";
            }
            else if (card.Element == ElementType.Water)
            {
                Log += "\teinen Wasser ";
            }
            else if (card.Element == ElementType.Normal)
            {
                Log += "\teinen Normalen ";
            }

            if (card.CardProperty == CardProperty.Dragon)
            {
                Log += "Drachen";
            }
            else if (card.CardProperty == CardProperty.Knight)
            {
                Log += "Knight";
            }
            else if (card.CardProperty == CardProperty.Ork)
            {
                Log += "Ork";
            }
            else if (card.CardProperty == CardProperty.Wizard)
            {
                Log += "Wizard";
            }
            else if (card.CardProperty == CardProperty.Goblin)
            {
                Log += "Goblin";
            }
            else if (card.CardProperty == CardProperty.Kraken)
            {
                Log += "Kraken";
            }
            else if (card.CardProperty == CardProperty.FireElve)
            {
                Log += "FireElve";
            }
            else if (card.CardType == CardType.Spell)
            {
                Log += "Zauber";
            }

            Log += $" mit {card.CardDamage} Base Damage Punkten ";

        }

        public void PrintLog()
        {
            Console.WriteLine(Log);
        }


    }
}
