using Cards;
using MTCG.cards.enums;

namespace MTCG.cards.spell
{
    public class WaterSpell : BaseCards
    {
        public WaterSpell(CardType cardType, ElementType element, int cardDamage, string cardName, CardProperty cardProperty = 0)
            : base(cardType, element, cardProperty, cardDamage, cardName)
        {
            
        }
    }
}