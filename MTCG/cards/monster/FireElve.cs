﻿using MTCG.cards.enums;

namespace MTCG.cards.monster
{
    public class FireElve : BaseCards
    {
        public FireElve(CardType cardType, ElementType element, int cardDamage, string cardName, CardProperty cardProperty, int cardId)
            : base(cardType, element, cardDamage, cardName, cardProperty, cardId)
        {

        }

        public int GetCardDamagePoints(BaseCards opponent)
        {
            return this.CardDamage;
        }
    }
}