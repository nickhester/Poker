using System.Collections.Generic;
using System.Linq;

namespace Poker.WinCriteria
{
    // The Straight will determine any hands that meet the criteria that all card numbers can be ordered sequentially
    // and will return the hand(s) with the highest value
    public class Straight : IWinCriteria
    {
        public string WinName { get { return Ranker.WinType.Straight.ToString(); } set { } }

        public List<Hand> Compare(List<Hand> handsToCompare)
        {
            Logger.Log($"Entering criteria check for {nameof(Straight)}.");

            // create the hand wrappers from the given hands
            List<HandWrapper> handWrappers = new List<HandWrapper>();
            handsToCompare.ForEach(x => handWrappers.Add(new HandWrapper(x)));

            // first check to see if each one qualifies at all
            for (int i = 0; i < handWrappers.Count; i++)
            {
                handWrappers[i].Result = Ranker.CompareResult.None;
                CheckIfQualifies(handWrappers[i]);
            }

            // next check if any met criteria
            handWrappers.RemoveAll(x => x.Result != Ranker.CompareResult.Win);
            if (!handWrappers.Any())       // if there are no winners, return null
            {
                Logger.Log($"Exiting criteria check for {nameof(Straight)} with no winner.");
                return null;
            }
            else if (handWrappers.Count() == 1)  //  or if there's a single winner, return results
            {
                Logger.Log($"Exiting criteria check for {nameof(Straight)} with a winner (immediately).");
                return handWrappers.Select(x => x.Hand).ToList();
            }

            // try to break the tie with best winning cards
            List<HandWrapper> winningTiedHandWrappers = DetermineHighestWinners(handWrappers);
            if (winningTiedHandWrappers.Count > 0)
            {
                Logger.Log($"Exiting criteria check for {nameof(Straight)} with a winner (tie breaker with higher cards).");
                return winningTiedHandWrappers.Select(x => x.Hand).ToList();
            }

            Logger.Log($"Exiting criteria check for {nameof(Straight)} with no winner.");
            return null;
        }

        // if it qualifies, this will re-arrange the cards in the hand in the order that
        // the cards should be compared in the case of a tie
        void CheckIfQualifies(HandWrapper handWrapper)
        {
            // sort non-joker cards low-to-high, and count joker cards
            List<Card> nonJokerCards = handWrapper.WorkingCards.Where(x => x.Number != Card.Numbers.Joker).ToList();
            nonJokerCards.Sort();
            int numJokers = handWrapper.WorkingCards.Count(x => x.Number == Card.Numbers.Joker);

            for (int i = 0; i < nonJokerCards.Count - 1; i++)
            {
                Card c1 = nonJokerCards[i];
                Card c2 = nonJokerCards[i + 1];

                // get value difference between two cards
                int valueDifference = (int)c2.Number - (int)c1.Number;

                // if there's duplicate values, fail
                if (valueDifference == 0)
                {
                    handWrapper.Result = Ranker.CompareResult.Lose;
                    return;
                }

                // see if hand has joker(s) to fill the gap by adding jacks until it runs out
                int posToInsertJack = 1;
                while (valueDifference > 1 && numJokers >= valueDifference - 1)
                {
                    valueDifference--;
                    numJokers--;

                    // insert a card of the correct value where the joker is being used (suit doesn't matter)
                    nonJokerCards.Insert(i + posToInsertJack,
                        new Card((Card.Numbers)((int)nonJokerCards[i].Number + posToInsertJack), Card.Suits.Club));

                    posToInsertJack++;
                }

                // if the difference between cards is still larger than 1, fail
                if (valueDifference > 1)
                {
                    handWrapper.Result = Ranker.CompareResult.Lose;
                    return;
                }
            }

            handWrapper.WinningCards = handWrapper.WorkingCards;
            handWrapper.RemainingCards = nonJokerCards;    // put resolved cards (jokers replaced with numbers) into remaining cards list to be used for tie breaking
            handWrapper.Result = Ranker.CompareResult.Win;
            return;
        }

        List<HandWrapper> DetermineHighestWinners(List<HandWrapper> hands)
        {
            // copy winning cards into remaining card hands, to break the tie as if they're the "remaining" cards
            hands.ForEach(x => { x.RemainingCards = x.WinningCards; });
            return WinCriteriaHelpers.FindHighestHandByRemainingCards(hands);
        }
    }
}
