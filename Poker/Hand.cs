using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class Hand
    {
        public readonly string Name;
        public readonly List<Card> Cards = new List<Card>();
        
        public Hand(string name, List<Card> cards)
        {
            Name = name;
            Cards = cards;
        }

        public override string ToString()
        {
            return Name + "'s hand";
        }
    }
}
