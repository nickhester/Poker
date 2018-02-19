using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    // this class represents a hand of one player
    public class Hand
    {
        public readonly string Name;
        public readonly List<Card> Cards = new List<Card>();
        
        public Hand(string name, List<Card> cards)
        {
            Name = name;
            Cards = cards;
        }

        // this ctor will parse a string for a list of cards to create a hand
        public Hand(string name, string cardNames)
        {
            Name = name;
            
            string[] cardNameLists = cardNames.Split(',');
            foreach (var cardName in cardNameLists)
            {
                if (!String.IsNullOrWhiteSpace(cardName))
                {
                    string trimmedCardName = cardName.Trim();
                    string[] cardNameSplit = trimmedCardName.Split(' ');

                    // if the card name split into more than two parts
                    if (cardNameSplit.Count() != 2)
                    {
                        Console.WriteLine("INPUT ERROR: " + trimmedCardName + " is not a valid card");
                        return;
                    }

                    Cards.Add(new Card(cardNameSplit[0].Trim(), cardNameSplit[1].Trim()));
                }
            }
        }

        public override string ToString()
        {
            string cards = string.Join(", ", Cards.Select(x => x.ToString()));
            return Name + "'s hand: " + cards;
        }
    }
}
