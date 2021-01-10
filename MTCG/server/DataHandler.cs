using System;
using System.Collections.Generic;
using MTCG.battle;
using MTCG.DB.structs;
using MTCG.server.enums;
using MTCG.user;
using Newtonsoft.Json;

namespace MTCG.server
{
    public class DataHandler
    {
        private ResponseContext _response;
        private RequestContext _request;
        private User _user = new User();

        public AllowedPaths GetPath()
        {
            return _request.Path;
        }

        public AllowedMethods GetMethod()
        {
            return _request.Method;
        }

        public string GetHeader()
        {
            return _response.Header;
        }

        public bool AuthorizationHeader()
        {
            if (_request.Authorization == "")
            {
                return false;
            }

            return true;
        }

        public void FalseCredentials()
        {
            _response.Status = "403 Forbbiden\n";
            _response.Message = "False Credentials";
        }

        public void WrongPath()
        {
            _response.Status = "403 Forbbiden\n";
            _response.Message = "Wrong Path, Rome is not that way!";
        }

        public void GetData(string data)
        {
            Console.WriteLine(data);
            _response = default(ResponseContext);
            _request = default(RequestContext);
            _request.Authorization = "";

            _response.Version = "HTTP/1.1 ";
            _response.Status = "200 OK\n";
            _response.Server = "Server: MTCG\n";
            _response.Message = "Something went wrong";
            _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";
            _response.ContentLanguage = "Content-Language: de\n";
            _response.ContentType = "Content-Type: text/plain\n";
            _response.Connection = "Connection: close\nKeep-Alive: timeout=50, max=0\n";
            _response.Charset = "Charset: utf-16\n\n";

            if (data.Contains("POST") || data.Contains("GET") || data.Contains("PUT") || data.Contains("DELETE"))
            {
                string[] dataStrings = data.Split("\n");
                string[] firstSplit = dataStrings[0].Split(" ");

                if (firstSplit[0].Contains("PUT"))
                {
                    _request.Method = AllowedMethods.PUT;
                }
                else if (firstSplit[0].Contains("GET"))
                {
                    _request.Method = AllowedMethods.GET;
                }
                else if (firstSplit[0].Contains("POST"))
                {
                    _request.Method = AllowedMethods.POST;
                }
                else if (firstSplit[0].Contains("DELETE"))
                {
                    _request.Method = AllowedMethods.DELETE;
                }

                if (firstSplit[1].Contains("USERS"))
                {
                    _request.Path = AllowedPaths.Users;
                }
                else if (firstSplit[1].Contains("TRANSACTIONS/PACKAGES"))
                {
                    _request.Path = AllowedPaths.TransactionsPackages;
                }
                else if (firstSplit[1].Contains("CARDS"))
                {
                    _request.Path = AllowedPaths.Cards;
                }
                else if (firstSplit[1].Contains("DECK"))
                {
                    _request.Path = AllowedPaths.Deck;
                }
                else if (firstSplit[1].Contains("STATS"))
                {
                    _request.Path = AllowedPaths.Stats;
                }
                else if (firstSplit[1].Contains("SCORE"))
                {
                    _request.Path = AllowedPaths.Score;
                }
                else if (firstSplit[1].Contains("BATTLE"))
                {
                    _request.Path = AllowedPaths.Battle;
                }
                else if (firstSplit[1].Contains("LOG"))
                {
                    _request.Path = AllowedPaths.BattleLog;
                }
                else if (firstSplit[1].Contains("TRADINGS"))
                {
                    _request.Path = AllowedPaths.Tradings;
                }
                else if (firstSplit[1].Contains("LOGOUT"))
                {
                    _request.Path = AllowedPaths.Logout;
                }
                else if (firstSplit[1].Contains("WATCHADS"))
                {
                    _request.Path = AllowedPaths.WatchAds;
                }

                _request.Version = firstSplit[2];

                bool limitHeader = false;

                for (int i = 1; i < dataStrings.Length; i++)
                {
                    if (!limitHeader)
                    {
                        if (dataStrings[i].Contains("AUTHORIZATION"))
                        {
                            _request.Authorization = dataStrings[i];
                        }
                        else if (dataStrings[i].Contains("CONTENT-LENGTH"))
                        {
                            limitHeader = true;
                        }
                        _request.Header += dataStrings[i];
                        _request.Header += "\n";
                    }
                    else
                    {
                        _request.Message += dataStrings[i];
                        _request.Message += "\n";
                    }
                }

                return;
            }
            else
            {
                _request.Path = AllowedPaths.ErrorNotSet;
                return;
            }
        }

        public void Login()
        {
            _user = JsonConvert.DeserializeObject<User>(_request.Message);
            int statusCode = _user.LoginOrCreate();

            if (statusCode == 200)
            {
                _response.Status = "200 OK\n";
                _response.Message = $"Login Erfolgreich\ntoken:{_user.Token}";
            }
            else if (statusCode == 201)
            {
                _response.Status = "201 Created\n";
                _response.Message = $"User wurde angelegt\nBitte einloggen\ntoken:{_user.Token}";
            }
            else if (statusCode == 406 || statusCode == 0)
            {
                _response.Status = "406 Not Acceptable\n";
                _response.Message = "password or user wrong";
            }
        }

        public void Logout()
        {
            _user.Logout();

            _response.Status = "200 OK\n";
            _response.Message = $"User {_user.Username} Logged Out";
        }


        public bool AuthorizeClient()
        {
            int token = 0;
            string sTocken = "";
            if (_request.Authorization == "")
            {
                _response.Status = "406 Not Acceptable\n";
                _response.Message = "Token Not Acceptable";
                return false;
            }

            for (int i = 0; i < _request.Authorization.Length; i++)
            {
                if (char.IsDigit(_request.Authorization[i]))
                {
                    sTocken += _request.Authorization[i];
                }
            }


            token = Int32.Parse(sTocken);

            bool isTokenAcceptable = _user.AuthorizeClient(token);

            if (isTokenAcceptable)
            {
                _response.Status = "200 OK\n";
                _response.Message = "Login Erfolgreich";
            }
            else
            {
                _response.Status = "406 Not Acceptable\n";
                _response.Message = "Token Not Acceptable";
            }

            return isTokenAcceptable;
        }

        public void ShowStats()
        {
            string userStats = _user.ShowUserStats();

            _response.Status = "200 OK\n";
            _response.Message = userStats;
        }

        public void ShowLeaderBoard()
        {
            string leaderBoard = _user.ShowLeaderBoard();

            _response.Status = "200 OK\n";
            _response.Message = leaderBoard;
        }

        public void ShowShop()
        {
            string shop = _user.ShowShop();

            _response.Status = "200 OK\n";
            _response.Message = shop;
        }

        public void BuyCardPack()
        {
            _user.LoadCards();
            int packId = 0;
            int msgCode = 404;
            if (_request.Message.Length > 10)
            {
                var definitionPack = new {PackID = ""};
                var sPackId = JsonConvert.DeserializeAnonymousType(_request.Message, definitionPack);

                //packId = Int32.Parse(definitionPack.PackID);
                packId = Int32.Parse(sPackId.PackID);

                msgCode = _user.BuyCard(packId);
            }
            

            if (msgCode == 200)
            {
                _response.Status = "200 OK\n";
                _response.Message = "Karten wurden hinzugefügt";
            }
            else if (msgCode == 406)
            {
                _response.Status = "406 Not Acceptable\n";
                _response.Message = "Zu wenig Coins";

            }
            else if (msgCode == 409)
            {
                _response.Status = "409 Conflict\n";
                _response.Message = "Alle Karten von diesem Pack schon vorhanden";
            }
            else if (msgCode == 404)
            {
                _response.Status = "404 Not Found\n";
                _response.Message = "Pack nicht vorhanden";
            }

        }

        public void ShowTrades()
        {
            string trades = _user.ShowTrades();

            _response.Status = "200 OK\n";
            _response.Message = trades;
        }

        public void ShowAllCards()
        {
            _user.LoadCards();
            string stackCards = _user.PrintStackCards();
            string deckCards = _user.PrintDeckCards();
            stackCards += "\n_____________Karten im Deck_____________\n";
            stackCards += deckCards;

            _response.Status = "200 OK\n";
            _response.Message = stackCards;
        }

        public void ShowDeckCards()
        {
            _user.LoadCards();
            string deckCards = "\n_____________Karten im Deck_____________\n";
            deckCards += _user.PrintDeckCards();

            _response.Status = "200 OK\n";
            _response.Message = deckCards;
        }

        public void ChangeDeckCards()
        {
            _user.LoadCards();
            int msgCode = 0;
            int[] deckCardIds = new int[4];
            var definitionDeckJson = new [] {new { DeckCard = ""}};
            var sDeckCardIds = JsonConvert.DeserializeAnonymousType(_request.Message, definitionDeckJson);

            for (int i = 0; i < sDeckCardIds.Length; i++)
            {
                deckCardIds[i] = Int32.Parse(sDeckCardIds[i].DeckCard);
                if (deckCardIds[i] < 0 || sDeckCardIds.Length <= 3)
                {
                    msgCode = 406; 
                }
            }

            if (_user.CardsInStack(deckCardIds) && msgCode == 0)
            {
                msgCode = _user.SwapCard(deckCardIds);
            }
            else if (msgCode == 0)
            {
                msgCode = 403; 
            }

            if (msgCode == 200)
            {
                _response.Status = "200 OK\n";
                _response.Message = "Karten wurden hinzugefügt";
            }
            else if (msgCode == 406)
            {
                _response.Status = "406 Not Acceptable\n";
                _response.Message = "Es wurden zu wenige Karten ausgewählt";

            }
            else if (msgCode == 403)
            {
                _response.Status = "403 Forbidden\n";
                _response.Message = "Nicht alle CardIds sind im Besitz";
            }

        }

        public void DeleteTradeDeal()
        {
            int msgCode = 0;
            int cardId = 0;
            var definitionDelDeal = new { WANTEDID = "" };
            var sCardId = JsonConvert.DeserializeAnonymousType(_request.Message, definitionDelDeal);

            cardId = Int32.Parse(sCardId.WANTEDID);

            msgCode = _user.DeleteTradeDeal(cardId);

            if (msgCode == 200)
            {
                _response.Status = "200 OK\n";
                _response.Message = "Trade Deal deleted";
            }

        }

        public void TradeOrInsert()
        {
            _user.LoadCards();
            int msgCode = 0;
            TradingDeserializeJson trade = JsonConvert.DeserializeObject<TradingDeserializeJson>(_request.Message.ToLower());

            if (trade.insert)
            {
                msgCode = _user.InsertInTradeList(trade.giveid,trade.wantid);
            }
            else
            {
                msgCode = _user.TradeCard(trade.usertradewith, trade.wantid);
            }

            if (msgCode == 200)
            {
                _response.Status = "200 OK\n";
                _response.Message = "Karten wurden hinzugefügt";
            }
            else if (msgCode == 201)
            {
                _response.Status = "201 Created\n";
                _response.Message = "Trade Listen Eintrag wurde erstellt";

            }
            else if (msgCode == 404)
            {
                _response.Status = "404 Not Found\n";
                _response.Message = "Karte nicht in Besitz oder Karte nicht vorhanden";
            }
            else if (msgCode == 406)
            {
                _response.Status = "406 Not Acceptable\n";
                _response.Message = "WantId == GiveId";
            }
            else if (msgCode == 418)
            {
                _response.Status = "406 Not Acceptable\n";
                _response.Message = "WantId == GiveId";
            }

        }

        public void Battle(BattleLobby lobby)
        {
            int battleId = _user.Battle(lobby);

            _response.Status = "200 OK\n";
            _response.Message = $"Your BattleId is:{battleId}\nPlease Watch the Log, when the Battle is finished";
        }

        public void BattleLog(BattleLobby lobby)
        {
            var definitionDelDeal = new { BATTLEID = "" };
            var sCardId = JsonConvert.DeserializeAnonymousType(_request.Message, definitionDelDeal);
            int battleId = Int32.Parse(sCardId.BATTLEID);
            string battleLog = _user.BattleLog(lobby, battleId);

            if (battleLog.Length <= 50)
            {
                _response.Status = "102 Processing\n";
                _response.Message = "Daten werden verarbeitet";
            }
            else
            {
                _response.Status = "200 OK\n";
                _response.Message = $"{battleLog}";
            }
        }

        public void WatchAds()
        {
            _user.WatchAds();

            _response.Status = "200 OK\n";
            _response.Message = "Hier könnte Ihre Werbung stehen\n" +
                                "Gesponserte Beitraege:\nIch baue meine Welt sowie sie mir gefaellt, meine Wunderwelt mein Haus von Elk\n" +
                                "Unsere Werbung ist so natürlich wie unser Apfelsaft gespritzt\n" +
                                "Ganz Ehrlich Granny's Apfelsaft gespritzt\n";
        }

        public void MakeHeader()
        {
            _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";
            _response.Header = _response.Version
                               + _response.Status
                               + _response.Server
                               + _response.ContentLength
                               + _response.ContentLanguage
                               + _response.ContentType
                               + _response.Connection
                               + _response.Charset
                               + _response.Message;
        }

    }
}