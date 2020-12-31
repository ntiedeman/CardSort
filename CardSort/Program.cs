using System;
using System.Linq;

namespace CardSort
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public class Card
    {
        public char Value { get; }

        public Suit Suit { get; }

        public int Weight { get; }

        public override string ToString() => $"{Value} of {Suit}";

        private int CalculateWeight(char value)
        {
            switch (value)
            {
                case 'J':
                    return 10;
                case 'Q':
                    return 11;
                case 'K':
                    return 12;
                case 'A':
                    return 13;
                default:
                    int.TryParse(value.ToString(), out int weight);
                    if (weight < 2 || weight > 9)
                    {
                        throw new ArgumentException($"Invalid card value supplied: {value}");
                    }
                    return weight;
            }
        }

        public Card(char value, Suit suit)
        {
            Value = value;
            Suit = suit;
            Weight = CalculateWeight(value);
        }
    }

    class Program
    {
        static Card[] SortHand(Card[] hand, bool descending = false)
        {
            Card[] sortedHand;

            if (descending)
            {
                sortedHand = hand.OrderByDescending(c => c.Weight).ThenByDescending(c => c.Suit).ToArray();
            }
            else
            {
                sortedHand = hand.OrderBy(c => c.Weight).ThenBy(c => c.Suit).ToArray();
            }

            return sortedHand;
        }

        static void Main(string[] args)
        {
            var hand = new Card[] { new Card('7', Suit.Hearts),
                                    new Card('A', Suit.Hearts),
                                    new Card('A', Suit.Spades),
                                    new Card('3', Suit.Clubs)};

            Card[] sortedHand = SortHand(hand);

            foreach (Card card in sortedHand)
            {
                Console.WriteLine(card.ToString());
            }
            Console.Read();
        }
    }
}
