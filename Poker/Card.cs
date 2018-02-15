using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Card : IComparable
    {
        public enum Suits
        {
            Diamond,
            Heart,
            Spade,
            Club
        }

        public enum Numbers
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
            Ace = 14,
            Joker = 15,
        }

        public Suits Suit;
        public Numbers Number;

        public Card(Numbers number, Suits suit)
        {
            Number = number;
            Suit = suit;
        }

        // These operator overloads deal in card value only. They do not consider Suit
        public static bool operator ==(Card c1, Card c2)
        {
            if (c1.Number == c2.Number
                || c1.Number == Numbers.Joker
                || c2.Number == Numbers.Joker)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Card c1, Card c2)
        {
            if (c1.Number != c2.Number
                && c1.Number != Numbers.Joker
                && c2.Number != Numbers.Joker)
            {
                return true;
            }
            return false;
        }

        public static bool operator >(Card c1, Card c2)
        {
            if (c1.Number > c2.Number
                || c1.Number == Numbers.Joker
                || c2.Number == Numbers.Joker)
            {
                return true;
            }
            return false;
        }

        public static bool operator <(Card c1, Card c2)
        {
            if (c1.Number < c2.Number
                || c1.Number == Numbers.Joker
                || c2.Number == Numbers.Joker)
            {
                return true;
            }
            return false;
        }

        public int CompareTo(object obj)
        {
            if ((Card)this == (Card)obj)
                return 0;
            else if ((Card)this > (Card)obj)
                return 1;

            return -1;
        }

        public override string ToString()
        {
            return Number.ToString() + " of " + Suit.ToString() + "s";
        }
    }
}
