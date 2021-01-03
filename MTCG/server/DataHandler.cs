using System;
using System.Collections.Generic;
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
        private User user = new User();

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

        public void WrongPath()
        {
            _response.Status = "403 Forbbiden\n";
            _response.Message = "wrong path";
            _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";
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
            _response.Charset = "Charset: utf-8\n\n";

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

                if (firstSplit[1].Contains("USERS"))
                {
                    _request.Path = AllowedPaths.Users;
                }
                else if (firstSplit[1].Contains("TRANSACTIONS/PACKAGES"))
                {
                    _request.Path = AllowedPaths.TransactionsPackages;
                }
                else if (firstSplit[1].Contains("Cards"))
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
                else if (firstSplit[1].Contains("BATTLES"))
                {
                    _request.Path = AllowedPaths.Battles;
                }
                else if (firstSplit[1].Contains("TRADINGS"))
                {
                    _request.Path = AllowedPaths.Tradings;
                }
                else if (firstSplit[1].Contains("LOGOUT"))
                {
                    _request.Path = AllowedPaths.Logout;
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
            user = JsonConvert.DeserializeObject<User>(_request.Message);
            int statusCode = user.LoginOrCreate();

            if (statusCode == 200)
            {
                _response.Status = "200 OK\n";
                _response.Message = $"Login Erfolgreich\ntoken:{user.Token}";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";
            }
            else if (statusCode == 201)
            {
                _response.Status = "201 Created\n";
                _response.Message = $"User wurde angelegt\nBitte einloggen\ntoken:{user.Token}";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";
            }
            else if (statusCode == 406 || statusCode == 0)
            {
                _response.Status = "406 Not Acceptable\n";
                _response.Message = "password or user wrong";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";
            }
        }

        public void Logout()
        {
            user.Logout();

            _response.Status = "200 OK\n";
            _response.Message = $"User {user.Username} Logged Out";
            _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";
        }


        public bool AuthorizeClient()
        {
            int token = 0;
            string sTocken = "";
            if (_request.Authorization == "")
            {
                _response.Status = "406 Not Acceptable\n";
                _response.Message = "Token Not Acceptable";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";
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

            bool isTokenAcceptable = user.AuthorizeClient(token);

            if (isTokenAcceptable)
            {
                _response.Status = "200 OK\n";
                _response.Message = "Login Erfolgreich";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";
            }
            else
            {
                _response.Status = "406 Not Acceptable\n";
                _response.Message = "Token Not Acceptable";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";
            }

            return isTokenAcceptable;
        }

        public void AppendMessage(List<string> messageQue)
        {
            messageQue.Add(_request.Message.Trim());

            _response.Status = "201 Created\n";
            _response.Message = "Anfrage wurde Erfolgreich bearbeitet";
            _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

        }


        public void GetAllMessages(List<string> messageQue)
        {
            string allMessages = "";

            if (messageQue.Count <= 0)
            {
                _response.Status = "404 Not Found\n";
                _response.Message = "Es sind keine Nachrichten vorhanden!";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

                Console.WriteLine("Es sind keine Nachrichten vorhanden!");
                return;
            }

            foreach (var message in messageQue)
            {
                allMessages += message + "\n";
            }

            _response.Status = "200 OK\n";
            _response.Message = allMessages;
            _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

        }


        /*public void GetMessage(List<string> messageQue)
        {
            string[] pathArray = _request.Path.Split("/");

            if (pathArray[2].Length == 0)
            {
                _response.Status = "406 Not Acceptable\n";
                _response.Message = "Kein Index";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

                Console.WriteLine("Kein Index");
                return;
            }

            int messageNumber = int.Parse(pathArray[2]) - 1;

            if (messageQue.Count <= 0)
            {
                _response.Status = "404 Not Found\n";
                _response.Message = "Es sind keine Nachrichten vorhanden!";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

                Console.WriteLine("Es sind keine Nachrichten vorhanden!");
                return;
            }
            if (messageQue.Count <= messageNumber)
            {
                _response.Status = "404 Not Found\n";
                _response.Message = "Es gibt noch nicht so viele Messages";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

                Console.WriteLine("Es gibt noch nicht so viele Messages");
                return;
            }
            if (messageNumber < 0)
            {
                _response.Status = "404 Not Found\n";
                _response.Message = "Index nicht vorhanden";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

                Console.WriteLine("Index nicht vorhanden");
                return;
            }

            _response.Status = "200 OK\n";
            _response.Message = messageQue[messageNumber];
            _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

            Console.WriteLine("GET erfolgreich gegettet");
        }


        public void UpdateMessage(List<string> messageQue)
        {
            string[] pathArray = _request.Path.Split("/");

            if (pathArray[2].Length == 0)
            {
                _response.Status = "406 Not Acceptable\n";
                _response.Message = "Kein Index";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

                Console.WriteLine("Kein Index");
                return;
            }

            int messageNumber = int.Parse(pathArray[2]) - 1;

            if (messageQue.Count <= 0)
            {
                _response.Status = "404 Not Found\n";
                _response.Message = "Es sind keine Nachrichten vorhanden!";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

                Console.WriteLine("Es sind keine Nachrichten vorhanden!");
                return;
            }

            if (messageQue.Count <= messageNumber)
            {
                _response.Status = "404 Not Found\n";
                _response.Message = "Es gibt noch nicht so viele Messages";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

                Console.WriteLine("Es gibt noch nicht so viele Messages");
                return;
            }
            if (messageNumber < 0)
            {
                _response.Status = "404 Not Found\n";
                _response.Message = "Index nicht vorhanden";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

                Console.WriteLine("Index Null nicht vorhanden");
                return;
            }

            messageQue[messageNumber] = _request.Message.Trim();

            _response.Status = "200 OK\n";
            _response.Message = "Message erfolgreich Aktualisiert";
            _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

        }


        public void DeleteMessage(List<string> messageQue)
        {
            string[] pathArray = _request.Path.Split("/");

            if (pathArray[2].Length == 0)
            {
                _response.Status = "406 Not Acceptable\n";
                _response.Message = "Kein Index";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

                Console.WriteLine("Kein Index");
                return;
            }

            int messageNumber = int.Parse(pathArray[2]) - 1;

            if (messageQue.Count <= 0)
            {
                _response.Status = "404 Not Found\n";
                _response.Message = "Es sind keine Nachrichten vorhanden!";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

                Console.WriteLine("Es sind keine Nachrichten vorhanden!");
                return;
            }

            if (messageQue.Count <= messageNumber)
            {
                _response.Status = "404 Not Found\n";
                _response.Message = "Es gibt noch nicht so viele Messages";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

                Console.WriteLine("Es gibt noch nicht so viele Messages");
                return;
            }
            if (messageNumber < 0)
            {
                _response.Status = "404 Not Found\n";
                _response.Message = "Index nicht vorhanden";
                _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

                Console.WriteLine("Index Null nicht vorhanden");
                return;
            }

            messageQue.RemoveAt(messageNumber);

            _response.Status = "200 OK\n";
            _response.Message = "Erfolgreich gelöscht";
            _response.ContentLength = $"Content-Length: {_response.Message.Length}\n";

        }*/


        public void MakeHeader()
        {
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