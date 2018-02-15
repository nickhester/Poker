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
            IWinCriteria fiveOfAKind = new LikeOfAKind(5);
            IWinCriteria fourOfAKind = new LikeOfAKind(4);
            IWinCriteria threeOfAKind = new LikeOfAKind(3);
            IWinCriteria twoOfAKind = new LikeOfAKind(2);

            List<IWinCriteria> winCriteria = new List<IWinCriteria>()
            {
                fiveOfAKind,
                fourOfAKind,
                threeOfAKind,
                twoOfAKind
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
