using System;
using MTCG.cards.enums;

namespace Cards
{
    public abstract class BaseCards
    {
        public ElementType Element {  get; private set; }
        public CardProperty CardProperty { get; private set; }
        public CardType CardType { get; private set; }

        public int CardDamage { get; private set; }
        public string CardName {  get; private set; }

        protected BaseCards(CardType cardType, ElementType element, CardProperty cardProperty, int cardDamage, string cardName)
        {
            this.CardType = cardType;
            this.Element = element;
            this.CardProperty = cardProperty;
            this.CardDamage = cardDamage;
            this.CardName = cardName;
        }

    }

}
