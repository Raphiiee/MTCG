﻿using MTCG.cards.enums;

namespace MTCG.cards.monster
{
    public class Dragon : BaseCards
    {
        public Dragon(CardType cardType, ElementType element, int cardDamage, string cardName, CardProperty cardProperty, int cardId)
            : base(cardType, element, cardDamage, cardName, cardProperty, cardId)
        {

        }

        public int GetCardDamagePoints(BaseCards opponent)
        {
            if (opponent.CardProperty == CardProperty.FireElve)
            {
                return 0;
            }

            return this.CardDamage;
        }

    }
}