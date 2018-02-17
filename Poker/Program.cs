using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }

            string winType = "";
            List<Hand> winningHands = ranker.DetermineWinner(DataSets.GetHands_TwoOfAKindTieRemainingCards().Hands, ref winType);

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
                DataSets.GetHands_TwoOfAKind(),
                DataSets.GetHands_TwoOfAKindTieWinningCards(),
                DataSets.GetHands_TwoOfAKindTieRemainingCards(),
                DataSets.GetHands_TwoOfAKindWithJoker(),
                DataSets.GetHands_TwoOfAKindWithTie(),
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
                DataSets.GetHands_Straight(),
                DataSets.GetHands_StraightWithAJoker(),
                DataSets.GetHands_StraightWithTieBreaker()
            };

            for (int i = 0; i < dataSets.Count; i++)
            {
                string winType = "";
                List<Hand> testWinningHands = ranker.DetermineWinner(dataSets[i].Hands, ref winType);
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
