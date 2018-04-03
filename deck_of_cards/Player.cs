using System;
using System.Collections.Generic;
namespace deck_of_cards
{
    public class Player
    {
        string name;
        List<Card> hand = new List<Card>();
        
        public Player(string name)
        {
            this.name = name;
        }
        public Card drawCard(Deck deck)
        {
            Card drawnCard = deck.dealTopCard();
            hand.Add(drawnCard);
            Console.WriteLine($"{name} drew {drawnCard.stringVal} of {drawnCard.suit}!");
            return drawnCard;
        }

        public Card discardCard(int cardIdx)
        {
            if (cardIdx > hand.Count-1)
            {
                Console.WriteLine("Sorry! No card at that specified index. Cannot discard.");
                return null;
            }
            else
            {
            Card discardedCard = hand[cardIdx];
            Console.WriteLine("Discarded Card: {0} of {1}", hand[cardIdx].stringVal, hand[cardIdx].suit);
            hand.RemoveAt(cardIdx);
            return discardedCard;
            }
        }

        public void showHand()
        {
            Console.WriteLine("Hand:");
            foreach (Card card in hand)
            {
                Console.WriteLine("{0} of {1}", card.stringVal, card.suit);
            }
        }
    }
}