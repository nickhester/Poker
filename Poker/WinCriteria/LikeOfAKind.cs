using System;
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

            // first check to see if each one qualifies at all
            for (int i = 0; i < handWrappers.Count; i++)
            {
                handWrappers[i].Result = Ranker.CompareResult.None;
                CheckIfQualifies(handWrappers[i], numberRequirement);
            }

            // next check if any met criteria
            List<HandWrapper> winningHandWrappers = handWrappers.Where(x => x.Result == Ranker.CompareResult.Win).ToList();
            int numWinners = winningHandWrappers.Count();
            if (numWinners <= 0)       // if there are no winners, return null
            {
                Logger.Log($"Exiting criteria check for {WinName} with no winner.");
                return null;
            }
            else if (numberRequirementSecond > 0)   // if should look for a 2nd match in remaining cards
            {
                Logger.Log($"Checking for secondary match of {numberRequirementSecond} cards.");

                // copy only remaining cards to working card list
                List<HandWrapper> localCopyOfHands = new List<HandWrapper>();
                foreach (var winningHand in winningHandWrappers)
                {
                    localCopyOfHands.Add(new HandWrapper(new Hand(winningHand.Hand.Name, winningHand.RemainingCards)));
                }

                // check to see if each one qualifies
                for (int i = 0; i < localCopyOfHands.Count; i++)
                {
                    CheckIfQualifies(localCopyOfHands[i], numberRequirementSecond);
                }
                // next check if any met criteria
                List<HandWrapper> secondaryWinningHandWrappers = localCopyOfHands.Where(x => x.Result == Ranker.CompareResult.Win).ToList();
                
                if (secondaryWinningHandWrappers.Count == 0)
                {
                    Logger.Log($"Exiting criteria check for {WinName} with no winner.");
                    return null;
                }

                numWinners = 0;
                for (int i = 0; i < winningHandWrappers.Count; i++)
                {
                    // if there's a primary and a secondary winning hand from the same player,
                    // put each one in its respective winning/remaining lists to be compared as a final tie-breaker
                    HandWrapper secondaryHandWrapper = secondaryWinningHandWrappers.SingleOrDefault(x => x.Hand.Name == winningHandWrappers[i].Hand.Name);
                    if (secondaryHandWrapper == null)
                    {
                        // remove from winning hand list if there isn't a matching secondary winning hand list
                        winningHandWrappers.RemoveAt(i);
                        i--;
                        continue;
                    }

                    numWinners++;
                    winningHandWrappers[i].WinningCards = new List<Card>()
                    {
                        winningHandWrappers[i].WinningCards.First(x => x.Number != Card.Numbers.Joker)
                    };
                    winningHandWrappers[i].RemainingCards = new List<Card>()
                    {
                        secondaryHandWrapper.WinningCards.First(x => x.Number != Card.Numbers.Joker)
                    };
                }
            }
            else if (numWinners == 1)  //  or if there's a single winner, return results
            {
                Logger.Log($"Exiting criteria check for {WinName} with a winner (immediately).");
                return winningHandWrappers.Select(x => x.Hand).ToList();
            }

            // try to break the tie with best winning cards
            List<HandWrapper> winningTiedHandWrappers = DetermineHighestWinners(winningHandWrappers);
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

        // if it qualifies, this will re-arrange the cards in the hand in the order that
        // the cards should be compared in the case of a tie
        void CheckIfQualifies(HandWrapper handWrapper, int numRequirement)
        {
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

            // check special case for all jokers
            if (handWrapper.WorkingCards.All(x => x.Number == Card.Numbers.Joker))
            {
                handWrapper.Result = Ranker.CompareResult.Win;
                handWrapper.WinningCards = handWrapper.WorkingCards;
                handWrapper.RemainingCards = new List<Card>();
                return;
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
