using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.WinCriteria
{
    public class LikeOfAKind : IWinCriteria
    {
        public string WinName
        {
            get
            {
                if (numberRequirement == 2 && numberRequirementSecond == -1)
                    return "OnePair";
                else if (numberRequirement == 3 && numberRequirementSecond == -1)
                    return "ThreeOfAKind";
                else if (numberRequirement == 4 && numberRequirementSecond == -1)
                    return "FourOfAKind";
                else if (numberRequirement == 5 && numberRequirementSecond == -1)
                    return "FiveOfAKind";
                else if (numberRequirement == 3 && numberRequirementSecond == 2)
                    return "FullHouse";
                else if (numberRequirement == 2 && numberRequirementSecond == 2)
                    return "TwoPair";
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

            // first check to see if each one qualifies at all
            for (int i = 0; i < handsToCompare.Count; i++)
            {
                handsToCompare[i].Result = Ranker.CompareResult.None;
                CheckIfQualifies(handsToCompare[i], numberRequirement);
            }

            // next check if any met criteria
            List<Hand> winningHands = handsToCompare.Where(x => x.Result == Ranker.CompareResult.Win).ToList();
            int numWinners = winningHands.Count();
            if (numWinners <= 0)       // if there are no winners, return null
            {
                Logger.Log($"Exiting criteria check for {WinName} with no winner.");
                return null;
            }
            else if (numberRequirementSecond > 0)   // if should look for a 2nd match in remaining cards
            {
                Logger.Log($"Checking for secondary match of {numberRequirementSecond} cards.");

                // new copy of hands, but using the remaining cards as the primary cards
                List<Hand> localCopyOfHands = new List<Hand>();
                foreach (var winningHand in winningHands)
                {
                    localCopyOfHands.Add(new Hand(winningHand.Name, winningHand.RemainingCards));
                }
                // check to see if each one qualifies
                for (int i = 0; i < localCopyOfHands.Count; i++)
                {
                    localCopyOfHands[i].Result = Ranker.CompareResult.None;
                    CheckIfQualifies(localCopyOfHands[i], numberRequirementSecond);
                }
                // next check if any met criteria
                List<Hand> secondaryWinningHands = localCopyOfHands.Where(x => x.Result == Ranker.CompareResult.Win).ToList();
                
                if (secondaryWinningHands.Count == 0)
                {
                    Logger.Log($"Exiting criteria check for {WinName} with no winner.");
                    return null;
                }

                numWinners = 0;
                for (int i = 0; i < winningHands.Count; i++)
                {
                    // if there's a primary and a secondary winning hand from the same player,
                    // put each one in its respective winning/remaining lists to be compared as a final tie-breaker
                    Hand secondaryHand = secondaryWinningHands.SingleOrDefault(x => x.Name == winningHands[i].Name);
                    if (secondaryHand == null)
                    {
                        // remove from winning hand list if there isn't a matching secondary winning hand list
                        winningHands.RemoveAt(i);
                        i--;
                        continue;
                    }

                    numWinners++;
                    winningHands[i].WinningCards = new List<Card>()
                    {
                        winningHands[i].WinningCards.First(x => x.Number != Card.Numbers.Joker)
                    };
                    winningHands[i].RemainingCards = new List<Card>()
                    {
                        secondaryHand.WinningCards.First(x => x.Number != Card.Numbers.Joker)
                    };
                }
            }
            else if (numWinners == 1)  //  or if there's a single winner, return results
            {
                Logger.Log($"Exiting criteria check for {WinName} with a winner (immediately).");
                return winningHands;
            }

            // try to break the tie with best winning cards
            List<Hand> winningTiedHands = DetermineHighestWinners(winningHands);
            if (winningTiedHands.Count == 1)
            {
                Logger.Log($"Exiting criteria check for {WinName} with a winner (tie breaker with higher match).");
                return winningTiedHands;
            }

            // break the tie with remaining cards
            List<Hand> winningRemainingTiedHands = WinCriteriaHelpers.FindHighestHandByRemainingCards(winningTiedHands);
            if (winningRemainingTiedHands.Count > 0)
            {
                Logger.Log($"Exiting criteria check for {WinName} with winner(s) (tie breaker with higher kickers).");
                return winningRemainingTiedHands;
            }

            Logger.Log($"Exiting criteria check for {WinName} with no winner.");
            return null;
        }

        // if it qualifies, this will re-arrange the cards in the hand in the order that
        // the cards should be compared in the case of a tie
        void CheckIfQualifies(Hand hand, int numRequirement)
        {
            // sort highest first
            hand.Cards.Sort();
            hand.Cards.Reverse();

            foreach (var card in hand.Cards)
            {
                // don't start with a joker
                // (or else everything will say it's equivalent and you'll get a false-positive)
                if (card.Number == Card.Numbers.Joker)
                    continue;

                // if there's a match of the required number of cards
                List<Card> qualifyingCards = hand.Cards.Where(x => x == card).ToList();
                if (qualifyingCards.Count() >= numRequirement)
                {
                    hand.Result = Ranker.CompareResult.Win;
                    // organize qualifying hand to check for tie later
                    hand.WinningCards = qualifyingCards;
                    hand.RemainingCards = hand.Cards.Where(x => x != card).ToList();
                    return;
                }
            }

            // check special case for all jokers
            if (hand.Cards.All(x => x.Number == Card.Numbers.Joker))
            {
                hand.Result = Ranker.CompareResult.Win;
                hand.WinningCards = hand.Cards;
                hand.RemainingCards = new List<Card>();
                return;
            }

            return;
        }

        List<Hand> DetermineHighestWinners(List<Hand> hands)
        {
            // get highest card
            Card highestCard = hands.Max(x => x.WinningCards[0]);
            // return any that match that highest value card
            return hands.Where(x => x.WinningCards[0] == highestCard).ToList();
        }
    }
}
