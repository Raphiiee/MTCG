using System;
using Enums;

namespace Cards
{
    public class BaseCards
    {
        protected elementType Element;
        protected cardProperty CardProperty;
        protected cardType CardType;

        protected int CardDamage;
        protected string CardName;

        public int GetCardDamage()
        {
            return CardDamage;
        }

        public elementType GetElementType()
        {
            return Element;
        }
        public cardProperty GetCardProperty()
        {
            return CardProperty;
        }
    }

}
