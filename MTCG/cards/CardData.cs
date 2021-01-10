using System;
using System.Collections.Generic;
using MTCG.cards.enums;
using MTCG.database;
using MTCG.server;

namespace MTCG.cards
{
    public class CardData
    {
        public int MaxCardIds { get; }
        public Dictionary<int, Card> CData = new Dictionary<int, Card>();
        private CardDatabase _cdb = new CardDatabase();

        public CardData()
        {
            _cdb.LoadAllCards(CData);
        }
         
        public void PrintAllCards()
        {
            foreach (KeyValuePair<int, Card> kvp in CData)
            {
                Console.WriteLine("Key = {0}, Card = {1} {2} {3} {4} {5}", kvp.Key, kvp.Value.CardType, kvp.Value.Element, kvp.Value.CardDamage, kvp.Value.CardName, kvp.Value.CardProperty);
            }
        }

        public int UserDeckCards(string user, Dictionary<int, Card> deck)
        {
            deck.Clear();
            int[] deckCardsArray = new int[5];
            Card temp;
            int cardCount = _cdb.LoadUserDeckCards(user, deckCardsArray);

            for (int i = 0; (i < 4) && (i < deckCardsArray.Length); i++)
            {
                // Get Value  
                if (deckCardsArray[i] == 0)
                {
                    break;
                }
                CData.TryGetValue(deckCardsArray[i], out temp);
                deck.Add(i, temp);
            }

            return cardCount;
        }

        public void UserStackCards(string user, Dictionary<int, Card> stack)
        {
            stack.Clear();
            int[] stackCardsArray = new int[2000];
            Card temp;
            _cdb.LoadUserStackCards(user,stackCardsArray);

            for (int i = 0; i < stackCardsArray.Length; i++)
            {
                // Get Value 
                if (stackCardsArray[i] == 0)
                {
                    break;
                }
                CData.TryGetValue(stackCardsArray[i], out temp);
                stack.Add(i, temp);
            }
        }

        public void UserCards(string user, Dictionary<int, Card> stack, Dictionary<int, Card> deck)
        {
            UserStackCards(user, stack);
            UserDeckCards(user, deck);
        }

        public string ShowShop()
        {
            return _cdb.ShowShop(CData);
        }

        public int BuyCard(string user, int coins, int packId, int[] cardArray)
        {
            return _cdb.BuyCard(user, coins, packId, cardArray);
        }

        public string ShowTrades()
        {
            return _cdb.ShowTrades(CData);
        }

        public int InsertInTradeList(string user, int giveCardId, int wantCardId)
        {
            return _cdb.InsertInTradeList(user, giveCardId, wantCardId);
        }

        public int TradeCard(string user, string dealUser, int wantCardId)
        {
            return _cdb.TradeCard(user, dealUser, wantCardId);
        }

        public int DeleteTradeDeal(string user, int wantCardId)
        {
            return _cdb.DeleteTradeDeal(user, wantCardId);
        }

    }
}