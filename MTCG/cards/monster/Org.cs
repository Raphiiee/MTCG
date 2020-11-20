using Cards;
using MTCG.cards.enums;

namespace MTCG.Cards.monster
{
    public class Org : BaseCards
    {
        public Org(CardType cardType, ElementType element, int cardDamage, string cardName, CardProperty cardProperty, int cardHealth)
            : base(cardType, element, cardDamage, cardName, cardProperty, cardHealth)
        {

        }
    }
}