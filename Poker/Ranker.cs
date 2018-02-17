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

        public List<Hand> DetermineWinner(List<Hand> hands, ref string winType)
        {
            List<IWinCriteria> winCriteria = new List<IWinCriteria>()
            {
                new LikeOfAKind(5),     // fiveOfAKind,
                new LikeOfAKind(4),     // fourOfAKind,
                new LikeOfAKind(3, 2),  // fullHouse
                new Flush(),            // flush
                //new Straight(),         // straight
                new LikeOfAKind(3),     // threeOfAKind,
                new LikeOfAKind(2, 2),  // two pair
                new LikeOfAKind(2)      // twoOfAKind
        };

            foreach (var criterion in winCriteria)
            {
                List<Hand> winningHands = criterion.Compare(hands);

                // if there are winning hands, return them
                if (winningHands != null)
                {
                    winType = criterion.WinName;
                    return winningHands;
                }
            }

            // no winning hand was found
            return null;
        }
    }
}
