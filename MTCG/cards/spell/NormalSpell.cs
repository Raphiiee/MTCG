﻿using Cards;
using MTCG.cards.enums;

namespace MTCG.cards.spell
{
    public class NormalSpell : BaseCards
    {
        public NormalSpell(CardType cardType, ElementType element, int cardDamage, string cardName, CardProperty cardProperty = 0, int cardHealth = 0)
            : base(cardType, element, cardDamage, cardName, cardProperty, cardHealth)
        {

        }
    }
}