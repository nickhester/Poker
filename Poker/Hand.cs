using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Hand
    {
        public string Name;
        public List<Card> Cards = new List<Card>();

        public Ranker.CompareResult Result;
        public List<Card> WinningCards;
        public List<Card> RemainingCards;
        
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
