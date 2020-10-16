using Cards;
using Enums;

namespace MTCG.cards.spell
{
    public class WaterSpell : BaseCards
    {
        public WaterSpell() : base()
        {
            this.CardType = cardType.Spell;
            this.Element = elementType.Water;
        }
    }
}