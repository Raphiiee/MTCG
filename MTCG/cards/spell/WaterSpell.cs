using MTCG.cards.enums;

namespace MTCG.cards.spell
{
    public class WaterSpell : BaseCards
    {
        public WaterSpell(CardType cardType, ElementType element, int cardDamage, string cardName, CardProperty cardProperty, int cardId)
            : base(cardType, element, cardDamage, cardName, cardProperty, cardId)
        {
            
        }

        public int GetCardDamagePoints(BaseCards opponent)
        {
            if (opponent.CardProperty == CardProperty.Kraken)
            {
                return 0;
            }

            if (Effectiveness(opponent) == 1)
            {
                return this.CardDamage * 2;
            }
            else if (Effectiveness(opponent) == -1)
            {
                return this.CardDamage / 2;
            }

            return this.CardDamage;
        }
    }
}