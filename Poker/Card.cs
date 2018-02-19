using System;

namespace Poker
{
    // this class represents a single card
    public class Card : IComparable
    {
        public Numbers Number;
        public Suits Suit;

        public enum Suits
        {
            Error,
            Wild,
            Diamond,
            Heart,
            Spade,
            Club
        }

        public enum Numbers
        {
            Error = 0,
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

        public Card(Numbers number, Suits suit)
        {
            Number = number;
            Suit = suit;
        }

        // this ctor will parse strings for a number and suit
        public Card(string number, string suit)
        {
            // trim ending 's' so user can use the plural
            suit = suit.TrimEnd(new char[] { 's', 'S' });

            Enum.TryParse(number, true, out Number);
            Enum.TryParse(suit, true, out Suit);

            if (Number == Numbers.Error || Suit == Suits.Error)
            {
                Console.WriteLine(number + " " + suit + " is not a valid card");
                throw new Exception();
            }
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
            if (c1.Number == Numbers.Joker && c2.Number == Numbers.Joker)
            {
                return false;
            }
            else if (c1.Number > c2.Number
                || c1.Number == Numbers.Joker
                || c2.Number == Numbers.Joker)
            {
                return true;
            }
            return false;
        }

        public static bool operator <(Card c1, Card c2)
        {
            if (c1.Number == Numbers.Joker && c2.Number == Numbers.Joker)
            {
                return false;
            }
            else if (c1.Number < c2.Number
                || c1.Number == Numbers.Joker
                || c2.Number == Numbers.Joker)
            {
                return true;
            }
            return false;
        }

        public int CompareTo(object obj)
        {
            // for the sake of sorting, just use the number value not the card operators
            // b/c considering Jokers as wild for the sake of sorting causes strange behavior
            int thisValue = (int)this.Number;
            int objValue = (int)(((Card)obj).Number);

            if (thisValue == objValue)
                return 0;
            else if (thisValue > objValue)
                return 1;

            return -1;
        }

        public override string ToString()
        {
            return Number.ToString() + " of " + Suit.ToString() + "s";
        }
    }
}
