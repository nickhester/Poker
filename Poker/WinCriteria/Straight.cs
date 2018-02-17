using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.WinCriteria
{
    //public class Straight : IWinCriteria
    //{
    //    public string WinName { get { return "Straight"; } set { } }

    //    public Hand Compare(List<Hand> handsToCompare)
    //    {
    //        Logger.Log($"Entering criteria check for {nameof(Straight)}.");

    //        // first check to see if each one qualifies at all
    //        for (int i = 0; i < handsToCompare.Count; i++)
    //        {
    //            CheckIfQualifies(handsToCompare[i]);
    //        }

    //        // next check if any won
    //        List<Hand> winningHands = handsToCompare.Where(x => x.Result == Ranker.CompareResult.Win).ToList();
    //        int numWinners = winningHands.Count();
    //        if (numWinners <= 0)       // if there are no winners, return null
    //        {
    //            Logger.Log($"Exiting criteria check for {nameof(Straight)} with no winner.");
    //            return null;
    //        }
    //        else if (numWinners == 1)  //  or if there's a single winner, return results
    //        {
    //            Logger.Log($"Exiting criteria check for {nameof(Straight)} with a winner (immediately).");
    //            return winningHands.Single();
    //        }

    //        // try to break the tie with best winning cards
    //        List<Hand> winningTiedHands = DetermineHighestWinners(winningHands);
    //        if (winningTiedHands.Count == 1)
    //        {
    //            Logger.Log($"Exiting criteria check for {nameof(Straight)} with a winner (tie breaker with higher cards).");
    //            return winningTiedHands.Single();
    //        }

    //        Logger.Log($"Exiting criteria check for {nameof(Straight)} with no winner.");
    //        return null;
    //    }

    //    // if it qualifies, this will re-arrange the cards in the hand in the order that
    //    // the cards should be compared in the case of a tie
    //    void CheckIfQualifies(Hand hand)
    //    {
    //        // sort hands low-to-high, and get non-joker cards
    //        List<Card> nonJokerCards = hand.Cards.Where(x => x.Number != Card.Numbers.Joker).ToList();
    //        nonJokerCards.Sort();
    //        int numJokers = hand.Cards.Count(x => x.Number == Card.Numbers.Joker);

    //        for (int i = 0; i < nonJokerCards.Count - 1; i++)
    //        {
    //            Card c1 = nonJokerCards[i];
    //            Card c2 = nonJokerCards[i + 1];

    //            // get value difference between two cards
    //            int valueDifference = (int)c2.Number - (int)c1.Number;

    //            // see if hand has a joker to fill the gap
    //            int posToInsertJack = 1;
    //            while (valueDifference > 1 && numJokers >= valueDifference - 1)
    //            {
    //                valueDifference--;
    //                numJokers--;

    //                // insert a card of the correct value where the joker is being used
    //                nonJokerCards.Insert(i + posToInsertJack, 
    //                    new Card((Card.Numbers)((int)nonJokerCards[i].Number + posToInsertJack), Card.Suits.Club));

    //                posToInsertJack++;
    //            }

    //            // if the difference between cards is still larger than 1, fail
    //            if (valueDifference > 1)
    //            {
    //                hand.Result = Ranker.CompareResult.Lose;
    //                return;
    //            }
    //        }

    //        hand.WinningCards = hand.Cards;
    //        hand.RemainingCards = nonJokerCards;    // put resolved cards (jokers replaced with numbers) into remaining cards list to be used for tie breaking
    //        hand.Result = Ranker.CompareResult.Win;
    //        return;
    //    }

    //    List<Hand> DetermineHighestWinners(List<Hand> hands)
    //    {
    //        // copy winning cards into remaining card hands, to break the tie as if they're the "remaining" cards
    //        hands.ForEach(x => { x.RemainingCards = x.WinningCards; });
    //        return WinCriteriaHelpers.FindHighestHandByRemainingCards(hands);
    //    }
    //}
}
