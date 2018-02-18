using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Ranker ranker = new Ranker();

            // run test data sets
            bool runTests = true;
            Logger.LogDebug = false;

            if (runTests)
            {
                RunTests(ranker);
                Console.ReadLine();
                return;
            }

            string winType = "";
            List<Hand> winningHands = ranker.DetermineWinner(DataSets.GetHands_OnePairTieRemainingCards().Hands, ref winType);

            if (winningHands == null)
            {
                Console.WriteLine($"Sorry, no winning hand could be determined.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Congratulations, the winner is: {string.Join(",", winningHands.Select(x => x.Name))}! It was a {winType}");

            Console.ReadLine();
        }

        static void RunTests(Ranker ranker)
        {
            List<DataSet> dataSets = new List<DataSet>()
            {
                DataSets.GetHands_OnePair(),
                DataSets.GetHands_OnePairTieWinningCards(),
                DataSets.GetHands_OnePairTieRemainingCards(),
                DataSets.GetHands_OnePairWithJoker(),
                DataSets.GetHands_OnePairWithTie(),
                DataSets.GetHands_ThreeOfAKind(),
                DataSets.GetHands_FourOfAKind(),
                DataSets.GetHands_FiveOfAKind(),
                DataSets.GetHands_FiveOfAKindWithAllJokers(),
                DataSets.GetHands_FullHouse(),
                DataSets.GetHands_FullHouseTieBreaker(),        // 10
                DataSets.GetHands_FullHouseWithAJoker(),
                DataSets.GetHands_TwoPair(),
                DataSets.GetHands_Flush(),
                DataSets.GetHands_FlushWithTieBreaker(),
                DataSets.GetHands_FlushWithAJoker(),
                DataSets.GetHands_FlushWithTie(),
                DataSets.GetHands_Straight(),
                DataSets.GetHands_StraightWithAJoker(),
                DataSets.GetHands_StraightWithTieBreaker(),
                DataSets.GetHands_StraightWithTie(),            // 20
                DataSets.GetHands_StraightFlush(),
                DataSets.GetHands_StraightFlushWithTieBreaker(),
                DataSets.GetHands_StraightFlushWithTie(),
                DataSets.GetHands_HighCard(),
                DataSets.GetHands_HighCardTieBreaker(),
                DataSets.GetHands_HighCardTie(),
                DataSets.GetHands_OneHand(),
                DataSets.GetHands_TwoCards(),
                DataSets.GetHands_OneCard(),
                DataSets.GetHands_TenCards()                    // 30
            };

            for (int i = 0; i < dataSets.Count; i++)
            {
                string winType = "";
                List<Hand> testWinningHands = ranker.DetermineWinner(dataSets[i].Hands, ref winType);

                if (testWinningHands == null || !testWinningHands.Any())
                {
                    Console.WriteLine($"Test Run {i}: FAIL - name: {dataSets[i].Winners}/NONE - " +
                        $"type: {dataSets[i].IntendedWin}/NONE");
                    continue;
                }

                string result;
                string winningNames = string.Join(",", testWinningHands.Select(x => x.Name));
                if (winningNames == dataSets[i].Winners && dataSets[i].IntendedWin == winType)
                    result = "SUCCESS";
                else
                    result = "FAIL";

                // print intended/actual
                Console.WriteLine($"Test Run {i}: {result} - name: {dataSets[i].Winners}/{winningNames} - " +
                    $"type: {dataSets[i].IntendedWin}/{winType}");
            }
        }
    }
}
