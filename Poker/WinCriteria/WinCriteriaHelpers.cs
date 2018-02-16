using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.WinCriteria
{
    public static class WinCriteriaHelpers
    {
        public static List<Hand> FindHighestHandByRemainingCards(List<Hand> hands)
        {
            // todo: figure out sort!
            // sort remaining cards
            //hands.ForEach(x => x.RemainingCards.OrderByDescending(y => y));

            //for (int i = 0; i < hands.Count; i++)
            //{
            //    hands[i].RemainingCards.Sort();
            //}
            
            // compare highest, then next highest, etc. (assumes same number in each list)
            for (int i = 0; i < hands.Count; i++)
            {
                Card highestCard = hands.Max(x => x.RemainingCards[i]);
                hands = hands.Where(x => x.RemainingCards[i] == highestCard).ToList();

                if (hands.Count == 1)
                    return hands;
            }
            return hands;
        }
    }
}
