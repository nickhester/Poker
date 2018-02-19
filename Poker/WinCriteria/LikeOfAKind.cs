using System.Collections.Generic;
using System.Linq;

namespace Poker.WinCriteria
{
    // The LikeOfAKind will determine any hands that meet the criteria N cards of the same number, and return the highest
    public class LikeOfAKind : IWinCriteria
    {
        public string WinName
        {
            get
            {
                if (numberRequirement == 2 && numberRequirementSecond == -1)
                    return Ranker.WinType.OnePair.ToString();
                else if (numberRequirement == 3 && numberRequirementSecond == -1)
                    return Ranker.WinType.ThreeOfAKind.ToString();
                else if (numberRequirement == 4 && numberRequirementSecond == -1)
                    return Ranker.WinType.FourOfAKind.ToString();
                else if (numberRequirement == 5 && numberRequirementSecond == -1)
                    return Ranker.WinType.FiveOfAKind.ToString();
                else if (numberRequirement == 3 && numberRequirementSecond == 2)
                    return Ranker.WinType.FullHouse.ToString();
                else if (numberRequirement == 2 && numberRequirementSecond == 2)
                    return Ranker.WinType.TwoPair.ToString();
                else
                    return (numberRequirement + "of a kind");
            }
            set { }
        }

        int numberRequirement;
        int numberRequirementSecond;

        // "num" is the number of cards matching, and "numSecond" is whether to look for an optional match in the remaining cards
        public LikeOfAKind(int num, int numSecond = -1)
        {
            numberRequirement = num;
            numberRequirementSecond = numSecond;
        }

        public List<Hand> Compare(List<Hand> handsToCompare)
        {
            Logger.Log($"Entering criteria check for {WinName} with {handsToCompare.Count} hands.");

            // create the hand wrappers from the given hands
            List<HandWrapper> handWrappers = new List<HandWrapper>();
            handsToCompare.ForEach(x => handWrappers.Add(new HandWrapper(x)));

            // first check to see if each hand passes the match criteria
            for (int i = 0; i < handWrappers.Count; i++)
            {
                handWrappers[i].Result = Ranker.CompareResult.None;
                CheckIfQualifies(handWrappers[i], numberRequirement);
            }

            // next check if any met criteria
            handWrappers.RemoveAll(x => x.Result != Ranker.CompareResult.Win);
            if (!handWrappers.Any())       // if there are no winners, return null
            {
                Logger.Log($"Exiting criteria check for {WinName} with no winner.");
                return null;
            }
            else if (numberRequirementSecond > 0)   // if needs to look for a 2nd match in remaining cards...
            {
                Logger.Log($"Checking for secondary match of {numberRequirementSecond} cards.");

                // copy remaining cards from the already winning hands to a new temporary working card list
                List<HandWrapper> localCopyOfHands = new List<HandWrapper>();
                foreach (var winningHand in handWrappers)
                {
                    localCopyOfHands.Add(new HandWrapper(new Hand(winningHand.Hand.Name, winningHand.RemainingCards)));
                }

                // check to see if each one qualifies for the 2nd match
                for (int i = 0; i < localCopyOfHands.Count; i++)
                {
                    CheckIfQualifies(localCopyOfHands[i], numberRequirementSecond);
                }

                // remove any that didn't meet criteria
                localCopyOfHands.RemoveAll(x => x.Result != Ranker.CompareResult.Win);

                if (!localCopyOfHands.Any())
                {
                    Logger.Log($"Exiting criteria check for {WinName} with no winner.");
                    return null;
                }

                // remove any winningHandWrappers that don't have a matching localCopyOfHands
                handWrappers.RemoveAll(x => !localCopyOfHands.Any(y => y.Hand.Name == x.Hand.Name));

                // for each of the hands with a primary match
                foreach (var winningHandWrapper in handWrappers)
                {
                    HandWrapper secondaryHandWrapper = localCopyOfHands.Single(x => x.Hand.Name == winningHandWrapper.Hand.Name);

                    // put in its respective winning/remaining lists to be compared as a final tie-breaker
                    winningHandWrapper.WinningCards = winningHandWrapper.WinningCards.Where(x => x.Number != Card.Numbers.Joker).ToList();
                    winningHandWrapper.RemainingCards = secondaryHandWrapper.WinningCards;
                }
            }
            else if (handWrappers.Count() == 1)  //  or if there's a single winner, return results
            {
                Logger.Log($"Exiting criteria check for {WinName} with a winner (immediately).");
                return handWrappers.Select(x => x.Hand).ToList();
            }

            // try to break the tie with best winning cards
            List<HandWrapper> winningTiedHandWrappers = DetermineHighestWinners(handWrappers);
            if (winningTiedHandWrappers.Count == 1)
            {
                Logger.Log($"Exiting criteria check for {WinName} with a winner (tie breaker with higher match).");
                return winningTiedHandWrappers.Select(x => x.Hand).ToList();
            }

            // break the tie with remaining cards
            List<HandWrapper> winningRemainingTiedHandWrappers = WinCriteriaHelpers.FindHighestHandByRemainingCards(winningTiedHandWrappers);
            if (winningRemainingTiedHandWrappers.Count > 0)
            {
                Logger.Log($"Exiting criteria check for {WinName} with winner(s) (tie breaker with higher kickers).");
                return winningRemainingTiedHandWrappers.Select(x => x.Hand).ToList();
            }

            Logger.Log($"Exiting criteria check for {WinName} with no winner.");
            return null;
        }

        // if it qualifies, this will set the hand's "Result" to "Win", and will also 
        // re-arrange the cards in the hand in the order that the cards should be compared in the case of a tie
        void CheckIfQualifies(HandWrapper handWrapper, int numRequirement)
        {
            // first, check special case for all jokers (succeed)
            if (handWrapper.WorkingCards.All(x => x.Number == Card.Numbers.Joker))
            {
                handWrapper.Result = Ranker.CompareResult.Win;
                handWrapper.WinningCards = handWrapper.WorkingCards;
                handWrapper.RemainingCards = new List<Card>();
                return;
            }

            // sort highest first
            handWrapper.WorkingCards.Sort();
            handWrapper.WorkingCards.Reverse();

            foreach (var card in handWrapper.WorkingCards)
            {
                // don't start with a joker
                // (or else everything will say it's equivalent and you'll get a false-positive)
                if (card.Number == Card.Numbers.Joker)
                    continue;

                // if there's a match of the required number of cards
                List<Card> qualifyingCards = handWrapper.WorkingCards.Where(x => x == card).ToList();
                if (qualifyingCards.Count() >= numRequirement)
                {
                    handWrapper.Result = Ranker.CompareResult.Win;
                    // organize qualifying hand to check for tie later
                    handWrapper.WinningCards = qualifyingCards;
                    handWrapper.RemainingCards = handWrapper.WorkingCards.Where(x => x != card).ToList();
                    return;
                }
            }
            return;
        }

        List<HandWrapper> DetermineHighestWinners(List<HandWrapper> hands)
        {
            // get highest card
            Card highestCard = hands.Max(x => x.WinningCards[0]);
            // return any that match that highest value card
            return hands.Where(x => x.WinningCards[0] == highestCard).ToList();
        }
    }
}
