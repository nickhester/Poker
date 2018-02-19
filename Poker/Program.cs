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

            Console.WriteLine("1. Enter Cards\n2. Run Tests");
            int answer;
            int.TryParse(Console.ReadLine(), out answer);

            Console.WriteLine("Use verbose logging? (Y/N)");
            string answerLogging = Console.ReadLine().ToUpper();

            // disable debug logging
            Logger.LogDebug = answerLogging == "Y";

            if (answer == 1)
            {
                Console.WriteLine("\n\nEnter Player's Cards, each card separated by a comma, and each player separated by a period." +
                    "\n\nexample: Two Heart, Five Diamond, Jack Spade, Joker Wild, Ace Club. " +
                    "Seven Diamond, Six Heart, Seven Club, Six Spade, Joker Wild.\n");

                List<Hand> handsFromPlayer = ParseUserHands(Console.ReadLine());

                if (handsFromPlayer == null)
                {
                    Console.WriteLine("Exiting program.");
                    Console.ReadLine();
                    return;
                }

                string winType = "";
                List<Hand> winningHands = ranker.DetermineWinner(handsFromPlayer, ref winType);

                if (winningHands == null)
                {
                    Console.WriteLine($"Sorry, no winning hand could be determined.");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine($"\n--The Hands:--\n{string.Join("\n", handsFromPlayer)}");
                Console.WriteLine($"\nThe winner is: {string.Join(" & ", winningHands.Select(x => x.Name))} with a {winType}!");

                Console.ReadLine();
            }
            else if (answer == 2)
            {
                // run test data sets
                RunTests(ranker);
                Console.ReadLine();
                return;
            }
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

        // This method is for manual testing. It's a super quick-and-dirty console user interface that
        // does not account for all possible defensive scenarios. Don't try to break it.
        static List<Hand> ParseUserHands(string userHands)
        {
            try
            {
                string[] userHandList = userHands.Split('.');
                List<Hand> returnHands = new List<Hand>();
                for (int i = 0; i < userHandList.Count(); i++)
                {
                    if (!String.IsNullOrWhiteSpace(userHandList[i]))
                        returnHands.Add(new Hand("Player " + (i + 1), userHandList[i].Trim()));
                }

                // remove any empty hands
                returnHands.RemoveAll(x => x.Cards.Count < 1);

                // validate that there was at least one hand created, and that all hands are the same length
                if (returnHands.Count < 1)
                {
                    Console.WriteLine("Need at least one valid hand.");
                }
                else if (!returnHands.All(x => x.Cards.Count == returnHands[0].Cards.Count))
                {
                    Console.WriteLine("Hands must be of equal size.");
                }
                else
                {
                    if (returnHands[0].Cards.Count != 5)
                        Console.WriteLine("The hands are of a non-standard size. Unexpected results may occur. Have fun. :)");

                    return returnHands;
                }
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Does not compute. Invalid input.");
                return null;
            }
        }
    }
}
