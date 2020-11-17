using System;
using Cards;
using Enums;
using MTCG.Cards.monster;

namespace MTCG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Dragon dragon = new Dragon(CardType.Monster, ElementType.Fire, CardProperty.Dragon, 10, "Ich bimbs");
            Console.WriteLine(dragon.CardName);
        }
    }
}
