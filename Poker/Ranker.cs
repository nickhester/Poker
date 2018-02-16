using Poker.WinCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Ranker
    {
        public enum CompareResult
        {
            None,
            Win,
            Lose,
            Tie
        }

        // list of win criteria

        public Hand DetermineWinner(List<Hand> hands)
        {
            List<IWinCriteria> winCriteria = new List<IWinCriteria>()
            {
                new LikeOfAKind(5),     // fiveOfAKind,
                new LikeOfAKind(4),     // fourOfAKind,
                new LikeOfAKind(3, 2),  // fullHouse
                new Flush(),            // flush
                new LikeOfAKind(3),     // threeOfAKind,
                new LikeOfAKind(2, 2),  // two pair
                new LikeOfAKind(2)      // twoOfAKind
        };

            foreach (var criterion in winCriteria)
            {
                Hand winningHand = criterion.Compare(hands);

                // if there's a winning hand, return it
                if (winningHand != null)
                {
                    return winningHand;
                }
            }

            // no winning hand was found
            return null;
        }
    }
}
