using System;
using System.Collections.Generic;
namespace card_hackathon
{
    public class Player
    {
        string name;
        int points;
        List<Card> hand = new List<Card>();
        
        public Player(string name)
        {
            this.name = name;
            points = 0;
        }

        public void addPoints(int points)
        {
            this.points += points;
        }

        public int calculateHandPts()
        {
            int handPoints = 0;
            foreach(Card card in hand)
            {
                if (card.val == 1 || card.val > 10)
                {
                    handPoints += 10;
                }
                else if (card.val == 8)
                {
                    handPoints += 50;
                }
                else 
                {
                    handPoints += card.val;
                }
            }
            return handPoints;
        }
        public Player drawCard(Deck deck)
        {
            Card drawnCard = deck.dealTopCard();
            hand.Add(drawnCard);
            Console.WriteLine($"{name} drew {drawnCard.stringVal} of {drawnCard.suit}!");
            return this;
        }

        public Player drawCard(Deck deck, int num)
        {
            for (var i = 0; i < num; i++)
            {
                drawCard(deck);
            }
            return this;
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

        public Player discardHand()
        {
            hand.Clear();
            return this;
        }

        public int getValFromHand(int cardIdx)
        {
            return (hand[cardIdx].val);
        }
        public string getSuitFromHand(int cardIdx)
        {
            return (hand[cardIdx].suit);
        }

        public void showHand()
        {
            Console.WriteLine("Hand:");
            for (var i = 0; i < hand.Count; i++)
            {
                Console.WriteLine($"{i+1}: {hand[i].stringVal} of {hand[i].suit}");
            }
        }
        public Player showPlayerInfo()
        {
            Console.WriteLine($"{name}, points: {points}");
            showHand();
            return this;
        }
        public List<Card> getHand()
        {
            return hand;
        }
        public int getHandSize()
        {
            return hand.Count;
        }
        public int getPlayerPoints()
        {
            return points;
        }
        public string getName()
        {
            return name;
        }
    }
}