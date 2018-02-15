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

        public static List<Hand> HighestRemainingCardValue(List<Hand> hands)
        {
            // sort remaining cards
            hands.ForEach(x => x.RemainingCards.Sort());
            // compare highest, then next highest, etc. (assumes same number in each list)
            for (int i = 0; i < hands.Count; i++)
            {
                //Card highestCard = hands.Max(x => x.WinningCards[0]);

                Card highestCard = hands.Max(x => x.RemainingCards[i]);
                hands = hands.Where(x => x.RemainingCards[i] == highestCard).ToList();

                if (hands.Count == 1)
                    return hands;
            }
            return hands;
        }
    }
}
